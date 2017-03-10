namespace Starts2000.TaoBao.Views
{
    partial class ViewBrowserSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewBrowserSet));
            this.label1 = new System.Windows.Forms.Label();
            this.lbIEVer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scbIEVer = new CCWin.SkinControl.SkinComboBox();
            this.sbtnSet = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.stbExit = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "默认浏览器：";
            // 
            // lbIEVer
            // 
            this.lbIEVer.AutoSize = true;
            this.lbIEVer.BackColor = System.Drawing.Color.Transparent;
            this.lbIEVer.Location = new System.Drawing.Point(93, 39);
            this.lbIEVer.Name = "lbIEVer";
            this.lbIEVer.Size = new System.Drawing.Size(16, 17);
            this.lbIEVer.TabIndex = 1;
            this.lbIEVer.Text = "  ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(303, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "浏览器版本：";
            // 
            // scbIEVer
            // 
            this.scbIEVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scbIEVer.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbIEVer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbIEVer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scbIEVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scbIEVer.FormattingEnabled = true;
            this.scbIEVer.Location = new System.Drawing.Point(389, 36);
            this.scbIEVer.Name = "scbIEVer";
            this.scbIEVer.Size = new System.Drawing.Size(114, 24);
            this.scbIEVer.TabIndex = 2;
            this.scbIEVer.WaterText = "";
            // 
            // sbtnSet
            // 
            this.sbtnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnSet.BackColor = System.Drawing.Color.Transparent;
            this.sbtnSet.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnSet.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnSet.DownBack")));
            this.sbtnSet.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnSet.Location = new System.Drawing.Point(509, 35);
            this.sbtnSet.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnSet.MouseBack")));
            this.sbtnSet.Name = "sbtnSet";
            this.sbtnSet.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnSet.NormlBack")));
            this.sbtnSet.Palace = true;
            this.sbtnSet.Size = new System.Drawing.Size(75, 25);
            this.sbtnSet.TabIndex = 3;
            this.sbtnSet.Text = "设  置";
            this.sbtnSet.UseVisualStyleBackColor = false;
            // 
            // stbExit
            // 
            this.stbExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stbExit.BackColor = System.Drawing.Color.Transparent;
            this.stbExit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.stbExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.stbExit.DownBack = ((System.Drawing.Image)(resources.GetObject("stbExit.DownBack")));
            this.stbExit.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.stbExit.Location = new System.Drawing.Point(590, 35);
            this.stbExit.MouseBack = ((System.Drawing.Image)(resources.GetObject("stbExit.MouseBack")));
            this.stbExit.Name = "stbExit";
            this.stbExit.NormlBack = ((System.Drawing.Image)(resources.GetObject("stbExit.NormlBack")));
            this.stbExit.Palace = true;
            this.stbExit.Size = new System.Drawing.Size(75, 25);
            this.stbExit.TabIndex = 3;
            this.stbExit.Text = "退  出";
            this.stbExit.UseVisualStyleBackColor = false;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(7, 66);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(663, 335);
            this.webBrowser.TabIndex = 4;
            // 
            // ViewBrowserSet
            // 
            this.AcceptButton = this.sbtnSet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.stbExit;
            this.ClientSize = new System.Drawing.Size(677, 408);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.stbExit);
            this.Controls.Add(this.sbtnSet);
            this.Controls.Add(this.scbIEVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbIEVer);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ViewBrowserSet";
            this.Text = "默认浏览器设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbIEVer;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinComboBox scbIEVer;
        private SkinButtonEx sbtnSet;
        private SkinButtonEx stbExit;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}