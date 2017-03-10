namespace Starts2000.SmartUpdate
{
    partial class UpdateClientMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateClientMainForm));
            CSharpWin.Controls.ProgressBarColorTable progressBarColorTable2 = new CSharpWin.Controls.ProgressBarColorTable();
            this.label1 = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lineControl1 = new CSharpWin.LineControl();
            this.rtbUpdateInfo = new System.Windows.Forms.RichTextBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pbDownload = new CSharpWin.Controls.ProgressBarEx();
            this.lbDownloadInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "最新版本：";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(245, 35);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(0, 12);
            this.lbVersion.TabIndex = 1;
            // 
            // lineControl1
            // 
            this.lineControl1.Location = new System.Drawing.Point(176, 50);
            this.lineControl1.Name = "lineControl1";
            this.lineControl1.Size = new System.Drawing.Size(279, 12);
            this.lineControl1.TabIndex = 2;
            this.lineControl1.TabStop = false;
            // 
            // rtbUpdateInfo
            // 
            this.rtbUpdateInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rtbUpdateInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbUpdateInfo.Location = new System.Drawing.Point(176, 66);
            this.rtbUpdateInfo.Name = "rtbUpdateInfo";
            this.rtbUpdateInfo.ReadOnly = true;
            this.rtbUpdateInfo.Size = new System.Drawing.Size(267, 196);
            this.rtbUpdateInfo.TabIndex = 3;
            this.rtbUpdateInfo.Text = "";
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(3, 35);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(165, 270);
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            // 
            // pbDownload
            // 
            this.pbDownload.ColorTable = progressBarColorTable2;
            this.pbDownload.Location = new System.Drawing.Point(174, 270);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(275, 18);
            this.pbDownload.TabIndex = 5;
            // 
            // lbDownloadInfo
            // 
            this.lbDownloadInfo.Location = new System.Drawing.Point(172, 293);
            this.lbDownloadInfo.Name = "lbDownloadInfo";
            this.lbDownloadInfo.Size = new System.Drawing.Size(277, 12);
            this.lbDownloadInfo.TabIndex = 0;
            this.lbDownloadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UpdateClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 313);
            this.ControlBox = false;
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.rtbUpdateInfo);
            this.Controls.Add(this.lineControl1);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lbDownloadInfo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateClientMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序更新";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbVersion;
        private CSharpWin.LineControl lineControl1;
        private System.Windows.Forms.RichTextBox rtbUpdateInfo;
        private System.Windows.Forms.PictureBox picLogo;
        private CSharpWin.Controls.ProgressBarEx pbDownload;
        private System.Windows.Forms.Label lbDownloadInfo;

    }
}

