namespace Server
{
    partial class ServerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.buttonClosing = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.NickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPerson = new System.Windows.Forms.Button();
            this.buttonAnimal = new System.Windows.Forms.Button();
            this.buttonFood = new System.Windows.Forms.Button();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonGameStart = new System.Windows.Forms.Button();
            this.textSend = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.TalkTimer = new System.Windows.Forms.Timer(this.components);
            this.textTimer = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClosing
            // 
            this.buttonClosing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClosing.FlatAppearance.BorderSize = 0;
            this.buttonClosing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClosing.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonClosing.ForeColor = System.Drawing.Color.White;
            this.buttonClosing.Image = ((System.Drawing.Image)(resources.GetObject("buttonClosing.Image")));
            this.buttonClosing.Location = new System.Drawing.Point(528, 2);
            this.buttonClosing.Name = "buttonClosing";
            this.buttonClosing.Size = new System.Drawing.Size(39, 36);
            this.buttonClosing.TabIndex = 3;
            this.buttonClosing.UseVisualStyleBackColor = false;
            this.buttonClosing.Click += new System.EventHandler(this.buttonClosing_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.Gray;
            this.buttonConnect.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonConnect.ForeColor = System.Drawing.Color.White;
            this.buttonConnect.Location = new System.Drawing.Point(276, 3);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 30);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "방만들기";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textStatus
            // 
            this.textStatus.BackColor = System.Drawing.Color.DarkGray;
            this.textStatus.Location = new System.Drawing.Point(3, 126);
            this.textStatus.Multiline = true;
            this.textStatus.Name = "textStatus";
            this.textStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textStatus.Size = new System.Drawing.Size(547, 419);
            this.textStatus.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.buttonPerson);
            this.panel1.Controls.Add(this.buttonAnimal);
            this.panel1.Controls.Add(this.buttonFood);
            this.panel1.Controls.Add(this.labelPort);
            this.panel1.Controls.Add(this.labelAddress);
            this.panel1.Controls.Add(this.textPort);
            this.panel1.Controls.Add(this.textAddress);
            this.panel1.Controls.Add(this.buttonDisconnect);
            this.panel1.Controls.Add(this.textStatus);
            this.panel1.Controls.Add(this.buttonConnect);
            this.panel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(5, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 534);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NickName});
            this.dataGridView.Location = new System.Drawing.Point(381, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(169, 115);
            this.dataGridView.TabIndex = 13;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // NickName
            // 
            this.NickName.HeaderText = "닉네임";
            this.NickName.Name = "NickName";
            this.NickName.ReadOnly = true;
            // 
            // buttonPerson
            // 
            this.buttonPerson.BackColor = System.Drawing.Color.Gray;
            this.buttonPerson.FlatAppearance.BorderSize = 2;
            this.buttonPerson.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonPerson.ForeColor = System.Drawing.Color.White;
            this.buttonPerson.Location = new System.Drawing.Point(260, 82);
            this.buttonPerson.Name = "buttonPerson";
            this.buttonPerson.Size = new System.Drawing.Size(91, 38);
            this.buttonPerson.TabIndex = 12;
            this.buttonPerson.Text = "인물";
            this.buttonPerson.UseVisualStyleBackColor = false;
            this.buttonPerson.Click += new System.EventHandler(this.buttonPerson_Click);
            // 
            // buttonAnimal
            // 
            this.buttonAnimal.BackColor = System.Drawing.Color.Gray;
            this.buttonAnimal.FlatAppearance.BorderSize = 2;
            this.buttonAnimal.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonAnimal.ForeColor = System.Drawing.Color.White;
            this.buttonAnimal.Location = new System.Drawing.Point(136, 82);
            this.buttonAnimal.Name = "buttonAnimal";
            this.buttonAnimal.Size = new System.Drawing.Size(91, 38);
            this.buttonAnimal.TabIndex = 11;
            this.buttonAnimal.Text = "동물";
            this.buttonAnimal.UseVisualStyleBackColor = false;
            this.buttonAnimal.Click += new System.EventHandler(this.buttonAnimal_Click);
            // 
            // buttonFood
            // 
            this.buttonFood.BackColor = System.Drawing.Color.Gray;
            this.buttonFood.FlatAppearance.BorderSize = 2;
            this.buttonFood.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonFood.ForeColor = System.Drawing.Color.White;
            this.buttonFood.Location = new System.Drawing.Point(7, 82);
            this.buttonFood.Name = "buttonFood";
            this.buttonFood.Size = new System.Drawing.Size(91, 38);
            this.buttonFood.TabIndex = 11;
            this.buttonFood.Text = "음식";
            this.buttonFood.UseVisualStyleBackColor = false;
            this.buttonFood.Click += new System.EventHandler(this.buttonFood_Click);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPort.ForeColor = System.Drawing.Color.White;
            this.labelPort.Location = new System.Drawing.Point(13, 38);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(95, 25);
            this.labelPort.TabIndex = 8;
            this.labelPort.Text = "포트 번호";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelAddress.ForeColor = System.Drawing.Color.White;
            this.labelAddress.Location = new System.Drawing.Point(13, 8);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(50, 25);
            this.labelAddress.TabIndex = 7;
            this.labelAddress.Text = "주소";
            // 
            // textPort
            // 
            this.textPort.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPort.Location = new System.Drawing.Point(115, 36);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(146, 26);
            this.textPort.TabIndex = 6;
            this.textPort.Text = "8080";
            // 
            // textAddress
            // 
            this.textAddress.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textAddress.Location = new System.Drawing.Point(68, 5);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(193, 26);
            this.textAddress.TabIndex = 5;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.Color.Gray;
            this.buttonDisconnect.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonDisconnect.ForeColor = System.Drawing.Color.White;
            this.buttonDisconnect.Location = new System.Drawing.Point(276, 34);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 30);
            this.buttonDisconnect.TabIndex = 4;
            this.buttonDisconnect.Text = "종료";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonGameStart
            // 
            this.buttonGameStart.BackColor = System.Drawing.Color.Gray;
            this.buttonGameStart.FlatAppearance.BorderSize = 2;
            this.buttonGameStart.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonGameStart.ForeColor = System.Drawing.Color.White;
            this.buttonGameStart.Location = new System.Drawing.Point(467, 134);
            this.buttonGameStart.Name = "buttonGameStart";
            this.buttonGameStart.Size = new System.Drawing.Size(91, 38);
            this.buttonGameStart.TabIndex = 3;
            this.buttonGameStart.Text = "게임시작";
            this.buttonGameStart.UseVisualStyleBackColor = false;
            this.buttonGameStart.Click += new System.EventHandler(this.buttonGameStart_Click);
            // 
            // textSend
            // 
            this.textSend.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textSend.Location = new System.Drawing.Point(7, 720);
            this.textSend.Name = "textSend";
            this.textSend.Size = new System.Drawing.Size(455, 32);
            this.textSend.TabIndex = 9;
            this.textSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSend_KeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.Gray;
            this.buttonSend.FlatAppearance.BorderSize = 2;
            this.buttonSend.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonSend.ForeColor = System.Drawing.Color.White;
            this.buttonSend.Location = new System.Drawing.Point(467, 718);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(91, 38);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "보내기";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // TalkTimer
            // 
            this.TalkTimer.Interval = 1000;
            // 
            // textTimer
            // 
            this.textTimer.Font = new System.Drawing.Font("굴림", 12F);
            this.textTimer.Location = new System.Drawing.Point(361, 144);
            this.textTimer.Name = "textTimer";
            this.textTimer.Size = new System.Drawing.Size(100, 26);
            this.textTimer.TabIndex = 11;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(568, 761);
            this.Controls.Add(this.textTimer);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textSend);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonGameStart);
            this.Controls.Add(this.buttonClosing);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiarGame";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonClosing;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonGameStart;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Button buttonAnimal;
        private System.Windows.Forms.Button buttonFood;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textSend;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonPerson;
        private System.Windows.Forms.Timer TalkTimer;
        private System.Windows.Forms.TextBox textTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NickName;
    }
}

