namespace Starts2000.TaoBao.Views
{
    partial class ViewConfirmReceipt
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewConfirmReceipt));
            this.timerInputKey = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser = new Starts2000.TaoBao.Views.WebBrowserEx();
            this.stbUrl = new CCWin.SkinControl.SkinTextBox();
            this.sbtnInpuPassword = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.sbtnBrowserSet = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.sbtnGoto = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.stbUrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerInputKey
            // 
            this.timerInputKey.Interval = 3000;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(140, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "点击按钮后，需立即把光标放到密码输入框中。";
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(4, 65);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(625, 337);
            this.webBrowser.TabIndex = 2;
            // 
            // stbUrl
            // 
            this.stbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stbUrl.BackColor = System.Drawing.Color.Transparent;
            this.stbUrl.Icon = null;
            this.stbUrl.IconIsButton = false;
            this.stbUrl.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbUrl.Location = new System.Drawing.Point(4, 34);
            this.stbUrl.Margin = new System.Windows.Forms.Padding(0);
            this.stbUrl.MinimumSize = new System.Drawing.Size(28, 28);
            this.stbUrl.MouseBack = null;
            this.stbUrl.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbUrl.Name = "stbUrl";
            this.stbUrl.NormlBack = null;
            this.stbUrl.Padding = new System.Windows.Forms.Padding(5);
            this.stbUrl.Size = new System.Drawing.Size(475, 28);
            // 
            // stbUrl.BaseText
            // 
            this.stbUrl.SkinTxt.BackColor = System.Drawing.Color.White;
            this.stbUrl.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stbUrl.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stbUrl.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stbUrl.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stbUrl.SkinTxt.Name = "BaseText";
            this.stbUrl.SkinTxt.Size = new System.Drawing.Size(465, 18);
            this.stbUrl.SkinTxt.TabIndex = 0;
            this.stbUrl.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stbUrl.SkinTxt.WaterText = "";
            this.stbUrl.TabIndex = 0;
            // 
            // sbtnInpuPassword
            // 
            this.sbtnInpuPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbtnInpuPassword.BackColor = System.Drawing.Color.Transparent;
            this.sbtnInpuPassword.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnInpuPassword.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnInpuPassword.DownBack")));
            this.sbtnInpuPassword.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnInpuPassword.Location = new System.Drawing.Point(143, 264);
            this.sbtnInpuPassword.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnInpuPassword.MouseBack")));
            this.sbtnInpuPassword.Name = "sbtnInpuPassword";
            this.sbtnInpuPassword.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnInpuPassword.NormlBack")));
            this.sbtnInpuPassword.Palace = true;
            this.sbtnInpuPassword.Size = new System.Drawing.Size(97, 25);
            this.sbtnInpuPassword.TabIndex = 3;
            this.sbtnInpuPassword.Text = "输入支付密码";
            this.sbtnInpuPassword.UseVisualStyleBackColor = false;
            // 
            // sbtnBrowserSet
            // 
            this.sbtnBrowserSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnBrowserSet.BackColor = System.Drawing.Color.Transparent;
            this.sbtnBrowserSet.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnBrowserSet.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnBrowserSet.DownBack")));
            this.sbtnBrowserSet.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnBrowserSet.Location = new System.Drawing.Point(547, 34);
            this.sbtnBrowserSet.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnBrowserSet.MouseBack")));
            this.sbtnBrowserSet.Name = "sbtnBrowserSet";
            this.sbtnBrowserSet.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnBrowserSet.NormlBack")));
            this.sbtnBrowserSet.Palace = true;
            this.sbtnBrowserSet.Size = new System.Drawing.Size(82, 25);
            this.sbtnBrowserSet.TabIndex = 1;
            this.sbtnBrowserSet.Text = "浏览器设置";
            this.sbtnBrowserSet.UseVisualStyleBackColor = false;
            // 
            // sbtnGoto
            // 
            this.sbtnGoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnGoto.BackColor = System.Drawing.Color.Transparent;
            this.sbtnGoto.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnGoto.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnGoto.DownBack")));
            this.sbtnGoto.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnGoto.Location = new System.Drawing.Point(482, 34);
            this.sbtnGoto.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnGoto.MouseBack")));
            this.sbtnGoto.Name = "sbtnGoto";
            this.sbtnGoto.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnGoto.NormlBack")));
            this.sbtnGoto.Palace = true;
            this.sbtnGoto.Size = new System.Drawing.Size(59, 25);
            this.sbtnGoto.TabIndex = 1;
            this.sbtnGoto.Text = "转  到";
            this.sbtnGoto.UseVisualStyleBackColor = false;
            // 
            // ViewConfirmReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 409);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sbtnInpuPassword);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.sbtnBrowserSet);
            this.Controls.Add(this.sbtnGoto);
            this.Controls.Add(this.stbUrl);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ViewConfirmReceipt";
            this.Text = "收货评价";
            this.stbUrl.ResumeLayout(false);
            this.stbUrl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox stbUrl;
        private SkinButtonEx sbtnGoto;
        private SkinButtonEx sbtnBrowserSet;
        private WebBrowserEx webBrowser;
        private SkinButtonEx sbtnInpuPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerInputKey;
    }
}