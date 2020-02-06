namespace TCPServer
{
    partial class ServerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.BtnSendAll = new System.Windows.Forms.Button();
            this.TxtMsg = new System.Windows.Forms.TextBox();
            this.ChkLbClients = new System.Windows.Forms.CheckedListBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.BtnDisConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(650, 9);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "开始";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Location = new System.Drawing.Point(731, 9);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // TxtLog
            // 
            this.TxtLog.Location = new System.Drawing.Point(278, 50);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLog.Size = new System.Drawing.Size(528, 436);
            this.TxtLog.TabIndex = 2;
            // 
            // BtnSendAll
            // 
            this.BtnSendAll.Location = new System.Drawing.Point(600, 496);
            this.BtnSendAll.Name = "BtnSendAll";
            this.BtnSendAll.Size = new System.Drawing.Size(75, 23);
            this.BtnSendAll.TabIndex = 3;
            this.BtnSendAll.Text = "发送给所有";
            this.BtnSendAll.UseVisualStyleBackColor = true;
            this.BtnSendAll.Click += new System.EventHandler(this.BtnSendAll_Click);
            // 
            // TxtMsg
            // 
            this.TxtMsg.Location = new System.Drawing.Point(14, 498);
            this.TxtMsg.Name = "TxtMsg";
            this.TxtMsg.Size = new System.Drawing.Size(580, 21);
            this.TxtMsg.TabIndex = 4;
            // 
            // ChkLbClients
            // 
            this.ChkLbClients.FormattingEnabled = true;
            this.ChkLbClients.Location = new System.Drawing.Point(14, 50);
            this.ChkLbClients.Name = "ChkLbClients";
            this.ChkLbClients.Size = new System.Drawing.Size(258, 436);
            this.ChkLbClients.TabIndex = 5;
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(681, 496);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(121, 23);
            this.BtnSend.TabIndex = 6;
            this.BtnSend.Text = "发送给选中客户端";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // BtnDisConnection
            // 
            this.BtnDisConnection.Location = new System.Drawing.Point(507, 9);
            this.BtnDisConnection.Name = "BtnDisConnection";
            this.BtnDisConnection.Size = new System.Drawing.Size(137, 23);
            this.BtnDisConnection.TabIndex = 7;
            this.BtnDisConnection.Text = "断开选中客户端的连接";
            this.BtnDisConnection.UseVisualStyleBackColor = true;
            this.BtnDisConnection.Click += new System.EventHandler(this.BtnDisConnection_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(825, 550);
            this.Controls.Add(this.BtnDisConnection);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.ChkLbClients);
            this.Controls.Add(this.TxtMsg);
            this.Controls.Add(this.BtnSendAll);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TextBox TxtLog;
        private System.Windows.Forms.Button BtnSendAll;
        private System.Windows.Forms.TextBox TxtMsg;
        private System.Windows.Forms.CheckedListBox ChkLbClients;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Button BtnDisConnection;
    }
}

