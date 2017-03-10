namespace Starts2000.TcpClientTest
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateClient = new System.Windows.Forms.Button();
            this.tbConnectCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLocalIp = new System.Windows.Forms.TextBox();
            this.lvSession = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.cbShowReceiveInfo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCreateClient
            // 
            this.btnCreateClient.Location = new System.Drawing.Point(651, 4);
            this.btnCreateClient.Name = "btnCreateClient";
            this.btnCreateClient.Size = new System.Drawing.Size(75, 23);
            this.btnCreateClient.TabIndex = 0;
            this.btnCreateClient.Text = "创建";
            this.btnCreateClient.UseVisualStyleBackColor = true;
            // 
            // tbConnectCount
            // 
            this.tbConnectCount.Location = new System.Drawing.Point(580, 6);
            this.tbConnectCount.Name = "tbConnectCount";
            this.tbConnectCount.Size = new System.Drawing.Size(54, 21);
            this.tbConnectCount.TabIndex = 19;
            this.tbConnectCount.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "客户端数：";
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(273, 6);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(131, 21);
            this.tbServerIp.TabIndex = 22;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(451, 6);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(52, 21);
            this.tbPort.TabIndex = 23;
            this.tbPort.Text = "9800";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "ServerIP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "LocalIP:";
            // 
            // tbLocalIp
            // 
            this.tbLocalIp.Location = new System.Drawing.Point(71, 6);
            this.tbLocalIp.Name = "tbLocalIp";
            this.tbLocalIp.Size = new System.Drawing.Size(131, 21);
            this.tbLocalIp.TabIndex = 22;
            // 
            // lvSession
            // 
            this.lvSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSession.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvSession.FullRowSelect = true;
            this.lvSession.GridLines = true;
            this.lvSession.Location = new System.Drawing.Point(14, 33);
            this.lvSession.MultiSelect = false;
            this.lvSession.Name = "lvSession";
            this.lvSession.Size = new System.Drawing.Size(787, 169);
            this.lvSession.TabIndex = 24;
            this.lvSession.UseCompatibleStateImageBehavior = false;
            this.lvSession.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Local";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Send";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Receive";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "State";
            this.columnHeader5.Width = 100;
            // 
            // rtbInfo
            // 
            this.rtbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInfo.Location = new System.Drawing.Point(14, 208);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(787, 194);
            this.rtbInfo.TabIndex = 25;
            this.rtbInfo.Text = "";
            // 
            // cbShowReceiveInfo
            // 
            this.cbShowReceiveInfo.AutoSize = true;
            this.cbShowReceiveInfo.Location = new System.Drawing.Point(732, 8);
            this.cbShowReceiveInfo.Name = "cbShowReceiveInfo";
            this.cbShowReceiveInfo.Size = new System.Drawing.Size(96, 16);
            this.cbShowReceiveInfo.TabIndex = 26;
            this.cbShowReceiveInfo.Text = "显示接收信息";
            this.cbShowReceiveInfo.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 414);
            this.Controls.Add(this.cbShowReceiveInfo);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.lvSession);
            this.Controls.Add(this.tbLocalIp);
            this.Controls.Add(this.tbServerIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbConnectCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateClient);
            this.Name = "FormMain";
            this.Text = "FormClientDemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateClient;
        private System.Windows.Forms.TextBox tbConnectCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLocalIp;
        private System.Windows.Forms.ListView lvSession;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.CheckBox cbShowReceiveInfo;
    }
}