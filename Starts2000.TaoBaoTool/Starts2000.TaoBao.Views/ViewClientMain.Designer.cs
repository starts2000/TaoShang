namespace Starts2000.TaoBao.Views
{
    partial class ViewClientMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewClientMain));
            this.sbtnHangUpOpt = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRemoteConnectInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnectStartTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnectStartTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnectEndTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnectEndTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbtnConfirmReceipt = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.lbSubAccountInfo = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbtnHangUpOpt
            // 
            this.sbtnHangUpOpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnHangUpOpt.BackColor = System.Drawing.Color.Transparent;
            this.sbtnHangUpOpt.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnHangUpOpt.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnHangUpOpt.DownBack")));
            this.sbtnHangUpOpt.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnHangUpOpt.Location = new System.Drawing.Point(517, 183);
            this.sbtnHangUpOpt.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnHangUpOpt.MouseBack")));
            this.sbtnHangUpOpt.Name = "sbtnHangUpOpt";
            this.sbtnHangUpOpt.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnHangUpOpt.NormlBack")));
            this.sbtnHangUpOpt.Palace = true;
            this.sbtnHangUpOpt.Size = new System.Drawing.Size(75, 25);
            this.sbtnHangUpOpt.TabIndex = 1;
            this.sbtnHangUpOpt.Text = "取消挂机";
            this.sbtnHangUpOpt.UseVisualStyleBackColor = false;
            this.sbtnHangUpOpt.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslRemoteConnectInfo,
            this.tsslConnectStartTimeLabel,
            this.tsslConnectStartTime,
            this.tsslConnectEndTimeLabel,
            this.tsslConnectEndTime});
            this.statusStrip.Location = new System.Drawing.Point(4, 220);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(672, 26);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 21);
            this.toolStripStatusLabel1.Text = "远程状态：";
            // 
            // tsslRemoteConnectInfo
            // 
            this.tsslRemoteConnectInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslRemoteConnectInfo.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslRemoteConnectInfo.Name = "tsslRemoteConnectInfo";
            this.tsslRemoteConnectInfo.Size = new System.Drawing.Size(69, 21);
            this.tsslRemoteConnectInfo.Text = "等待连接...";
            // 
            // tsslConnectStartTimeLabel
            // 
            this.tsslConnectStartTimeLabel.Name = "tsslConnectStartTimeLabel";
            this.tsslConnectStartTimeLabel.Size = new System.Drawing.Size(68, 21);
            this.tsslConnectStartTimeLabel.Text = "开始时间：";
            this.tsslConnectStartTimeLabel.Visible = false;
            // 
            // tsslConnectStartTime
            // 
            this.tsslConnectStartTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslConnectStartTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslConnectStartTime.Name = "tsslConnectStartTime";
            this.tsslConnectStartTime.Size = new System.Drawing.Size(4, 21);
            this.tsslConnectStartTime.Visible = false;
            // 
            // tsslConnectEndTimeLabel
            // 
            this.tsslConnectEndTimeLabel.Name = "tsslConnectEndTimeLabel";
            this.tsslConnectEndTimeLabel.Size = new System.Drawing.Size(68, 21);
            this.tsslConnectEndTimeLabel.Text = "到期时间：";
            this.tsslConnectEndTimeLabel.Visible = false;
            // 
            // tsslConnectEndTime
            // 
            this.tsslConnectEndTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslConnectEndTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslConnectEndTime.ForeColor = System.Drawing.Color.Red;
            this.tsslConnectEndTime.Name = "tsslConnectEndTime";
            this.tsslConnectEndTime.Size = new System.Drawing.Size(4, 21);
            this.tsslConnectEndTime.Visible = false;
            // 
            // sbtnConfirmReceipt
            // 
            this.sbtnConfirmReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnConfirmReceipt.BackColor = System.Drawing.Color.Transparent;
            this.sbtnConfirmReceipt.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnConfirmReceipt.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnConfirmReceipt.DownBack")));
            this.sbtnConfirmReceipt.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnConfirmReceipt.Location = new System.Drawing.Point(598, 183);
            this.sbtnConfirmReceipt.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnConfirmReceipt.MouseBack")));
            this.sbtnConfirmReceipt.Name = "sbtnConfirmReceipt";
            this.sbtnConfirmReceipt.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnConfirmReceipt.NormlBack")));
            this.sbtnConfirmReceipt.Palace = true;
            this.sbtnConfirmReceipt.Size = new System.Drawing.Size(75, 25);
            this.sbtnConfirmReceipt.TabIndex = 2;
            this.sbtnConfirmReceipt.Text = "确认收货";
            this.sbtnConfirmReceipt.UseVisualStyleBackColor = false;
            // 
            // lbSubAccountInfo
            // 
            this.lbSubAccountInfo.AutoEllipsis = true;
            this.lbSubAccountInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbSubAccountInfo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSubAccountInfo.ForeColor = System.Drawing.Color.Red;
            this.lbSubAccountInfo.Location = new System.Drawing.Point(50, 62);
            this.lbSubAccountInfo.Name = "lbSubAccountInfo";
            this.lbSubAccountInfo.Size = new System.Drawing.Size(556, 113);
            this.lbSubAccountInfo.TabIndex = 3;
            this.lbSubAccountInfo.Text = "  ";
            // 
            // ViewClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(680, 250);
            this.Controls.Add(this.lbSubAccountInfo);
            this.Controls.Add(this.sbtnConfirmReceipt);
            this.Controls.Add(this.sbtnHangUpOpt);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 250);
            this.Name = "ViewClientMain";
            this.Text = "ViewClient";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslRemoteConnectInfo;
        private SkinButtonEx sbtnHangUpOpt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnectStartTimeLabel;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnectStartTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnectEndTimeLabel;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnectEndTime;
        private SkinButtonEx sbtnConfirmReceipt;
        private System.Windows.Forms.Label lbSubAccountInfo;
    }
}