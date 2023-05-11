using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Runtime.Remoting.Messaging;

namespace Server
{
    public partial class ServerForm : Form
    {
        delegate void AppendTextDelegate(string s); // delegate : 반환형이랑 매개변수 타입이 같은 메소드들을 서로 호환해서 불러쓸 수 있음.
        AppendTextDelegate textAppender; // AppendTextDelegate 인스턴스로 textAppender 생성
        Socket serverSocket; // Socket 클래스의 serverSocket 인스턴스 생성
        IPAddress thisAddress; // IPAddress 클래스의 thisAddress 인스턴스 생성
        List<Socket> connectClientList; // 소켓리스트의 connectClientList 인스턴스 생성, 연결된사용자리스트
        protected string _s_testTime;
        bool On;
        Point Pos;

        public ServerForm()
        {
            InitializeComponent();
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            // AppendTextDelegate 가 AppendText 함수를 가리킴 -> textAppender는 AppendText 호출
            textAppender = new AppendTextDelegate(AppendText);
            // 소켓을 리스트로 받아들임 <> : 제네릭
            connectClientList = new List<Socket>();

            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            // hostEntry.AddressList 에서 IPAddress 자료형 addr을 하나씩 뽑아서
            foreach (IPAddress addr in hostEntry.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    thisAddress = addr;
                    break;
                }
            }

            if (thisAddress == null)
            {
                thisAddress = IPAddress.Loopback;
            }
            textAddress.Text = thisAddress.ToString();
            dataGridView.ReadOnly = true;
        }

        // X 버튼 클릭 시
        private void buttonClosing_Click(object sender, EventArgs e)
        {
            ServerForm.ActiveForm.Close();
        }

        // 로그 전송
        public void turnon_log_dump()
        {
            try
            {
                //Log File이 저장될 경로 지정
                //아래와 같이 지정하면, 앱의 실행파일이 위치한 경로에 
                //logdump.txt이름으로 로그가 저장 된다.
                string _todaydate = DateTime.Now.Date.ToString("MMdd");
                string ExportFilePath = Path.GetDirectoryName(Application.ExecutablePath);
                string app_verification_log = String.Format(ExportFilePath + @"\{0}logdump.txt", _todaydate);
                //TextWriterTraceListener생성.
                //생성할 때 생성자의 인자로 로그 파일 경로 지정
                TextWriterTraceListener cListener = new TextWriterTraceListener(System.IO.File.Open(
                app_verification_log, FileMode.Append));

                //Trace의 리스너로 등록
                Trace.Listeners.Add(cListener);
                Trace.AutoFlush = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format("Full Stacktrace: {0}", e.ToString()));
            }
        }

        //시작 버튼 클릭 시 연결 시작
        private void buttonConnect_Click(object sender, EventArgs e)
        {

            this.turnon_log_dump();
            int port;
            if (serverSocket == null)
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                connectClientList = new List<Socket>();
            }
            try { port = Int32.Parse(textPort.Text); }
            catch
            {
                MessageBox.Show("포트 번호가 잘못 입력되었습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPort.Focus();
                textPort.SelectAll();
                return;
            }

            if (serverSocket.IsBound)
                MessageBox.Show("서버가 실행 중입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (port < 0 || port > 65535)
            {
                MessageBox.Show("포트 번호가 잘못 입력되었습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPort.Focus();
                textPort.SelectAll();
            }
            else
            {
                IPEndPoint endPoint = new IPEndPoint(thisAddress, port);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(20);



                serverSocket.BeginAccept(AcceptCallback, null);
                AppendText("서버 시작이 완료되었습니다.");

                _s_testTime = string.Format("{0:tt:hh:mm:ss}", System.DateTime.Now);
                Trace.WriteLine(string.Format("{0} [서버시작] 서버주소 {1}:{2}", _s_testTime, textAddress.Text, textPort.Text));
            }
        }

        //Client에서 연결 신호가 들어오면 시작되는 Callback
        private void AcceptCallback(IAsyncResult asyncResult)
        {
            try
            {
                Socket client = serverSocket.EndAccept(asyncResult);
                if (connectClientList.Count < 7) //만약 6명 초과해서 들어올시
                {
                    serverSocket.BeginAccept(AcceptCallback, null);

                    AsyncObject asyncObject = new AsyncObject(4096);
                    asyncObject.WorkingSocket = client;
                    connectClientList.Add(client);

                    AppendText("IP : " + client.RemoteEndPoint);
                    client.BeginReceive(asyncObject.Buffer, 0, 4096, 0, ReceiveData, asyncObject);
                }
                else
                {
                    AppendText("서버 최대인원이 되어 접속시도를 차단합니다.");
                    client.Close();
                }

            }
            catch { }
        }

        //Data를 받았을 때 시작되는 Callback
        private void ReceiveData(IAsyncResult asyncResult)
        {
            AsyncObject asyncObject = asyncResult.AsyncState as AsyncObject;
            try
            {
                asyncObject.WorkingSocket.EndReceive(asyncResult);
            }
            catch
            {
                asyncObject.WorkingSocket.Close();
                return;
            }

            string text = Encoding.UTF8.GetString(asyncObject.Buffer);
            string[] tokens = text.Split('\x01');
            try
            {
                if (tokens[1][0] == '\x02')
                {
                    AppendText(tokens[0] + "님이 입장하셨습니다. (현재 인원 : " + connectClientList.Count + "명)");
                    try
                    {
                        dataGridView.Rows.Add(new string[] { tokens[0] });
                    }
                    catch
                    {
                    }
                }
                else if (tokens[1][0] == '\x03')
                {
                    AppendText(tokens[0] + "님이 퇴장하셨습니다. (현재 인원 : " + (connectClientList.Count - 1) + "명)");
                    try
                    {
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            if (tokens[0] == dataGridView.Rows[i].Cells[0].Value as string)
                            {
                                dataGridView.Rows.RemoveAt(i);
                                break;
                            }
                            else Console.WriteLine(dataGridView.Rows[i].Cells[0].Value);
                        }
                    }
                    catch { }
                }
                else AppendText("[받음] " + tokens[0] + " : " + tokens[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            for (int i = connectClientList.Count - 1; i >= 0; i--)
            {
                Socket tempSocket = connectClientList[i];
                if (tempSocket != asyncObject.WorkingSocket)
                {
                    try
                    {
                        tempSocket.Send(asyncObject.Buffer);
                    }
                    catch
                    {
                        tempSocket.Close();
                        connectClientList.RemoveAt(i);
                    }
                }
            }

            asyncObject.ClearBuffer();
            try
            {
                asyncObject.WorkingSocket.BeginReceive(asyncObject.Buffer, 0, 4096, 0, ReceiveData, asyncObject);
            }
            catch
            {
                asyncObject.WorkingSocket.Close();
                connectClientList.Remove(asyncObject.WorkingSocket);
            }
        }

        //텍스트 보내기
        private void SendText(string message)
        {
            if (!serverSocket.IsBound)
            {
                MessageBox.Show("서버가 실행되고 있지 않습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("텍스트가 입력되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSend.Focus();
            }
            else
            {
                SendProcess(Encoding.UTF8.GetBytes("관리자\x01" + message));
                AppendText("[보냄] 관리자 : " + message);
                textSend.Clear();
                _s_testTime = string.Format("{0:tt:hh:mm:ss}", System.DateTime.Now);
                Trace.WriteLine(string.Format("{0} [보냄] 관리자 : {1}", _s_testTime, message));
            }
        }

        //각 Client들에게 텍스트 보내기
        private void SendProcess(byte[] byteData)
        {
            for (int i = connectClientList.Count - 1; i >= 0; i--)
            {
                Socket tempSocket = connectClientList[i];
                try
                {
                    tempSocket.Send(byteData);
                }
                catch
                {
                    tempSocket.Close();
                    connectClientList.RemoveAt(i);
                }
            }
        }

        //보내기 버튼 누를 때 텍스트 보내기
        // sender : 누가 이벤트를 부르고 있느냐에 대한 정보
        // 여러개의 버튼이 한가지 이벤트 함수를 공유하고 있을 때
        // 이벤트 함수가 어느 버튼에 의해서 유발되었는지를 알 수 있음
        // e : 이벤트 핸들러가 사용하는 파라미터
        // 예를 들어서 마우스 클릭 이벤트시에 마우스가 클릭된 곳의 좌표를 아고싶다던가
        // 마우스의 왼쪽 버튼인지, 오른쪽 버튼인지 알고 싶을 때 e의 내용을 참고
        // Event Handler : 이벤트에 바인딩되는 메서드
        // binding : 구체적인 값, 성격을 확정하는 것
        // 이벤트가 발생하면 이벤트와 연결된 이벤트 처리기의 코드가 실행됨
        // 모든 이벤트 처리기는 위와 같은 두 개의 매개변수(sender, e)를 전달
        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendText(textSend.Text.Trim()); // textBox의 text를 앞뒤 공백 제거후 SendText 함수의 인자로 보냄
        }

        //Enter 누를 때 텍스트 보내기
        // KeyEventArgs e : 키를 누르는 순간 e라는 객체를 통해서 무슨 키인지 값이 전달됨
        private void textSend_KeyDown(object sender, KeyEventArgs e)
        {
            // e.KeyCode : 이 안에 들어있는 값을 보고 어떤 키가 눌렸는지 알 수 있음
            // Keys.멤버 : 각 키에 대한 값
            if (e.KeyCode == Keys.Enter)
            {
                SendText(textSend.Text.Trim()); // textBox의 text를 앞뒤 공백 제거후 SendText 함수의 인자로 보냄
            }
        }
        //연결 종료
        private void Disconnect()
        {
            if (serverSocket != null && serverSocket.IsBound) // 서버소켓이 널이 아니고(AND) 특정 포트에 바인딩 되었다면
            {
                // 234, 180, 128, 235, 166, 172, 236, 158, 144, 1, 4
                // SendProcess 메소드의 인자로 위의 바이트배열을 보냄
                SendProcess(Encoding.UTF8.GetBytes("관리자\x01\x04"));
                serverSocket.Close(); // 소켓연결 닫고 연결된 리소스 해제
                // null 로 초기화 하는 이유 ?
                // null인 상태는 선언만 되고 값은 할당되지 않은 상태
                // 빈 값이라도 메모리를 할당받기 때문에
                // 사용을 하지 않을수도 있는 변수는 메모리 낭비를 막기위해서 null로 할당
                serverSocket = null;

                AppendText("서버 종료가 완료되었습니다."); // 서버종료 메세지 출력
                while (dataGridView.Rows.Count > 0)
                {
                    dataGridView.Rows.RemoveAt(0); // 참여자 목록이 다 없어질때까지 행 지움
                }
            }
        }

        //연결끊기 버튼 클릭 시 연결 종료
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect(); // Disconnect 함수 호출
        }

        //폼 종료 시 연결 종료
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect(); // Disconnect 함수 호출
        }

        delegate void CrossThreadSafetyAppendText(string message);

        //메시지, 상태 등의 내역 쓰기
        private void AppendText(string message)
        {
            // Control.InvokeRequired 속성! 해당 컨트롤에 '너, 다른 곳에서 요청한 작업을 막고있니?'라고 묻는 속성이다.
            // Control.InvokeRequired 값이 true일 경우, 막고있다는 뜻이므로 풀어달라고 요청한다.
            // Control.InvokeRequired 값이 false일 경우, 해당 컨트롤에 접근하여 수행할 작업을 할 수 있다.
            if (textStatus.InvokeRequired)
            {
                textStatus.Invoke(new CrossThreadSafetyAppendText(AppendText), message);
            }
            else
            {
                textStatus.Text += "\r\n" + message; // \n 유닉스 줄바꿈, \r 맥 줄바꿈, \r\n 윈도우 줄바꿈.
            }
            // 자동으로 스크롤 내리기
            textStatus.Select(textStatus.Text.Length, 0);
            textStatus.ScrollToCaret();
        }
        private void Lier_game()
        {
            // 1. random 0~n을 통해 n번째 클라가 lier 지정
            Random rand = new Random();
            int lier = rand.Next(0, connectClientList.Count);
            string word = "사과";
            // 2. 각 클라이언트에게 lier 또는 단어 보내기
            for (int i = connectClientList.Count - 1; i >= 0; i--)
            {
                Socket tempSocket = connectClientList[i];
                try
                {
                    byte[] byteData = Encoding.UTF8.GetBytes("관리자\x01" + word);
                    if (i == lier) byteData = Encoding.UTF8.GetBytes("관리자\x01" + "lier");
                    AppendText(string.Format("{0}에 단어 {1}가 전달되었습니다.", tempSocket.RemoteEndPoint, byteData));
                    tempSocket.Send(byteData);
                }
                catch
                {
                    tempSocket.Close();
                    
                }
            }
            // 3. 타이머 시작
            // 4. 투표시간

            // 4-2 라이어가 지목시 정답 입력시간
            // 5 결과 표시 및 종료
        }



        //Callback에 대한 내용 저장을 위한 Class
        public class AsyncObject
        {
            public byte[] Buffer;
            public Socket WorkingSocket;
            public readonly int BufferSize;

            public AsyncObject(int bufferSize)
            {
                BufferSize = bufferSize;
                Buffer = new byte[BufferSize];
            }

            public AsyncObject(int buffersize, Socket tempSocket) : this(buffersize)
            {
                WorkingSocket = tempSocket;
            }

            public void ClearBuffer()
            {
                Array.Clear(Buffer, 0, BufferSize);
            }
        }

        private void buttonFood_Click(object sender, EventArgs e)
        {
            string ImportFilePath = Path.GetDirectoryName(Application.ExecutablePath);
            string app_verification_log = String.Format(ImportFilePath + @"\food.txt");
            string[] food_list = System.IO.File.ReadAllLines(app_verification_log);
            Random_Shuffle(ref food_list);
            Console.WriteLine(food_list[0]);
        }

        private void buttonAnimal_Click(object sender, EventArgs e)
        {
            string ImportFilePath = Path.GetDirectoryName(Application.ExecutablePath);
            string app_verification_log = String.Format(ImportFilePath + @"\animal.txt");
            string[] animal_list = System.IO.File.ReadAllLines(app_verification_log);
            Random_Shuffle(ref animal_list);
            Console.WriteLine(animal_list[0]);

        }

        private void buttonPerson_Click(object sender, EventArgs e)
        {
            string ImportFilePath = Path.GetDirectoryName(Application.ExecutablePath);
            string app_verification_log = String.Format(ImportFilePath + @"\person.txt");
            string[] person_list = System.IO.File.ReadAllLines(app_verification_log);
            Random_Shuffle(ref person_list);
            Console.WriteLine(person_list[0]);

        }

        private void Random_Shuffle(ref string[] array)
        {
            //string[] list = array;

            ///* You can use either for loop for while loop */
            //for (int i = list.Length - 1; i > 0; i--)
            //{
            //    Random random = new Random();
            //    int randomIndex = random.Next(0, i + 1);
            //    string temp = list[i];
            //    list[i] = list[randomIndex];
            //    list[randomIndex] = temp;
            //}

            Random rnd = new Random();
            array = array.OrderBy(x => rnd.Next()).ToArray();
        }

        private void buttonGameStart_Click(object sender, EventArgs e)
        {
            Lier_game();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
