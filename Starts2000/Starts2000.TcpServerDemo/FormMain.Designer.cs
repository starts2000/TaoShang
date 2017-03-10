namespace Starts2000.TcpServerDemo
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnectCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRecieveCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSendCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbShowReceiveInfo = new System.Windows.Forms.CheckBox();
            this.cbShowPacketCount = new System.Windows.Forms.CheckBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(264, 6);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(170, 21);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "9800";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP:";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(41, 6);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(170, 21);
            this.tbIP.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(466, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslConnectCount,
            this.toolStripStatusLabel3,
            this.tsslRecieveCount,
            this.toolStripStatusLabel2,
            this.tsslSendCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 446);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(896, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel1.Text = "当前连接数：";
            // 
            // tsslConnectCount
            // 
            this.tsslConnectCount.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslConnectCount.Name = "tsslConnectCount";
            this.tsslConnectCount.Size = new System.Drawing.Size(57, 17);
            this.tsslConnectCount.Text = "0000000";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel3.Text = "接收：";
            // 
            // tsslRecieveCount
            // 
            this.tsslRecieveCount.Name = "tsslRecieveCount";
            this.tsslRecieveCount.Size = new System.Drawing.Size(50, 17);
            this.tsslRecieveCount.Text = "000000";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel2.Text = "发送：";
            // 
            // tsslSendCount
            // 
            this.tsslSendCount.Name = "tsslSendCount";
            this.tsslSendCount.Size = new System.Drawing.Size(50, 17);
            this.tsslSendCount.Text = "000000";
            // 
            // rtbInfo
            // 
            this.rtbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInfo.Location = new System.Drawing.Point(14, 33);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(870, 410);
            this.rtbInfo.TabIndex = 5;
            this.rtbInfo.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(809, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "BufferTest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbShowReceiveInfo
            // 
            this.cbShowReceiveInfo.AutoSize = true;
            this.cbShowReceiveInfo.Location = new System.Drawing.Point(556, 8);
            this.cbShowReceiveInfo.Name = "cbShowReceiveInfo";
            this.cbShowReceiveInfo.Size = new System.Drawing.Size(96, 16);
            this.cbShowReceiveInfo.TabIndex = 7;
            this.cbShowReceiveInfo.Text = "显示接收信息";
            this.cbShowReceiveInfo.UseVisualStyleBackColor = true;
            // 
            // cbShowPacketCount
            // 
            this.cbShowPacketCount.AutoSize = true;
            this.cbShowPacketCount.Location = new System.Drawing.Point(658, 8);
            this.cbShowPacketCount.Name = "cbShowPacketCount";
            this.cbShowPacketCount.Size = new System.Drawing.Size(120, 16);
            this.cbShowPacketCount.TabIndex = 8;
            this.cbShowPacketCount.Text = "显示收发数据包数";
            this.cbShowPacketCount.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 468);
            this.Controls.Add(this.cbShowPacketCount);
            this.Controls.Add(this.cbShowReceiveInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "TcpServerDemo";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnectCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslRecieveCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslSendCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbShowReceiveInfo;
        private System.Windows.Forms.CheckBox cbShowPacketCount;
    }
}

