namespace Starts2000.TaoBao.Views
{
    partial class ViewLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewLogin));
            this.skinPanelAvatar = new CCWin.SkinControl.SkinPanel();
            this.picBoxAvatar = new System.Windows.Forms.PictureBox();
            this.btnLogin = new CCWin.SkinControl.SkinButton();
            this.stbAccount = new CCWin.SkinControl.SkinTextBox();
            this.checkBoxRememberPwd = new CCWin.SkinControl.SkinCheckBox();
            this.checkBoxAutoLogin = new CCWin.SkinControl.SkinCheckBox();
            this.stbPassword = new CCWin.SkinControl.SkinTextBox();
            this.btnRegister = new System.Windows.Forms.Label();
            this.btnForgotPassword = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.skinPanelAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAvatar)).BeginInit();
            this.stbAccount.SuspendLayout();
            this.stbPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanelAvatar
            // 
            this.skinPanelAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skinPanelAvatar.BackColor = System.Drawing.Color.Transparent;
            this.skinPanelAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.skinPanelAvatar.Controls.Add(this.picBoxAvatar);
            this.skinPanelAvatar.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanelAvatar.DownBack = null;
            this.skinPanelAvatar.Location = new System.Drawing.Point(23, 88);
            this.skinPanelAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.skinPanelAvatar.MouseBack = null;
            this.skinPanelAvatar.Name = "skinPanelAvatar";
            this.skinPanelAvatar.NormlBack = null;
            this.skinPanelAvatar.Padding = new System.Windows.Forms.Padding(10);
            this.skinPanelAvatar.Palace = true;
            this.skinPanelAvatar.Size = new System.Drawing.Size(95, 95);
            this.skinPanelAvatar.TabIndex = 162;
            // 
            // picBoxAvatar
            // 
            this.picBoxAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxAvatar.Location = new System.Drawing.Point(10, 10);
            this.picBoxAvatar.Name = "picBoxAvatar";
            this.picBoxAvatar.Size = new System.Drawing.Size(75, 75);
            this.picBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxAvatar.TabIndex = 0;
            this.picBoxAvatar.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.btnLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(118)))), ((int)(((byte)(156)))));
            this.btnLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLogin.Create = true;
            this.btnLogin.DownBack = null;
            this.btnLogin.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.errorProvider.SetIconPadding(this.btnLogin, 2);
            this.btnLogin.Location = new System.Drawing.Point(138, 217);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.MouseBack = null;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormlBack = null;
            this.btnLogin.Palace = true;
            this.btnLogin.Size = new System.Drawing.Size(193, 49);
            this.btnLogin.TabIndex = 161;
            this.btnLogin.Text = "登        录";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // stbAccount
            // 
            this.stbAccount.BackColor = System.Drawing.Color.Transparent;
            this.stbAccount.Icon = null;
            this.errorProvider.SetIconAlignment(this.stbAccount, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.stbAccount.IconIsButton = false;
            this.stbAccount.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.errorProvider.SetIconPadding(this.stbAccount, 2);
            this.stbAccount.Location = new System.Drawing.Point(138, 92);
            this.stbAccount.Margin = new System.Windows.Forms.Padding(0);
            this.stbAccount.MinimumSize = new System.Drawing.Size(28, 28);
            this.stbAccount.MouseBack = null;
            this.stbAccount.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbAccount.Name = "stbAccount";
            this.stbAccount.NormlBack = null;
            this.stbAccount.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.stbAccount.Size = new System.Drawing.Size(193, 28);
            // 
            // stbAccount.BaseText
            // 
            this.stbAccount.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stbAccount.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stbAccount.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stbAccount.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stbAccount.SkinTxt.Name = "BaseText";
            this.stbAccount.SkinTxt.Size = new System.Drawing.Size(160, 18);
            this.stbAccount.SkinTxt.TabIndex = 0;
            this.stbAccount.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stbAccount.SkinTxt.WaterText = "帐号";
            this.stbAccount.TabIndex = 159;
            // 
            // checkBoxRememberPwd
            // 
            this.checkBoxRememberPwd.AutoSize = true;
            this.checkBoxRememberPwd.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRememberPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBoxRememberPwd.DefaultCheckButtonWidth = 15;
            this.checkBoxRememberPwd.DownBack = null;
            this.checkBoxRememberPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxRememberPwd.ForeColor = System.Drawing.Color.Black;
            this.checkBoxRememberPwd.LightEffect = false;
            this.checkBoxRememberPwd.Location = new System.Drawing.Point(138, 160);
            this.checkBoxRememberPwd.MouseBack = null;
            this.checkBoxRememberPwd.Name = "checkBoxRememberPwd";
            this.checkBoxRememberPwd.NormlBack = ((System.Drawing.Image)(resources.GetObject("checkBoxRememberPwd.NormlBack")));
            this.checkBoxRememberPwd.SelectedDownBack = null;
            this.checkBoxRememberPwd.SelectedMouseBack = null;
            this.checkBoxRememberPwd.SelectedNormlBack = null;
            this.checkBoxRememberPwd.Size = new System.Drawing.Size(75, 21);
            this.checkBoxRememberPwd.TabIndex = 156;
            this.checkBoxRememberPwd.Text = "记住密码";
            this.checkBoxRememberPwd.UseVisualStyleBackColor = false;
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxAutoLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBoxAutoLogin.DefaultCheckButtonWidth = 15;
            this.checkBoxAutoLogin.DownBack = null;
            this.checkBoxAutoLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBoxAutoLogin.ForeColor = System.Drawing.Color.Black;
            this.checkBoxAutoLogin.LightEffect = false;
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(256, 160);
            this.checkBoxAutoLogin.MouseBack = null;
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.NormlBack = ((System.Drawing.Image)(resources.GetObject("checkBoxAutoLogin.NormlBack")));
            this.checkBoxAutoLogin.SelectedDownBack = null;
            this.checkBoxAutoLogin.SelectedMouseBack = null;
            this.checkBoxAutoLogin.SelectedNormlBack = null;
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(75, 21);
            this.checkBoxAutoLogin.TabIndex = 157;
            this.checkBoxAutoLogin.Text = "自动登录";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = false;
            // 
            // stbPassword
            // 
            this.stbPassword.BackColor = System.Drawing.Color.Transparent;
            this.stbPassword.Icon = null;
            this.errorProvider.SetIconAlignment(this.stbPassword, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.stbPassword.IconIsButton = true;
            this.stbPassword.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.errorProvider.SetIconPadding(this.stbPassword, 2);
            this.stbPassword.Location = new System.Drawing.Point(138, 129);
            this.stbPassword.Margin = new System.Windows.Forms.Padding(0);
            this.stbPassword.MinimumSize = new System.Drawing.Size(0, 28);
            this.stbPassword.MouseBack = null;
            this.stbPassword.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbPassword.Name = "stbPassword";
            this.stbPassword.NormlBack = null;
            this.stbPassword.Padding = new System.Windows.Forms.Padding(5, 5, 37, 5);
            this.stbPassword.Size = new System.Drawing.Size(193, 28);
            // 
            // stbPassword.BaseText
            // 
            this.stbPassword.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stbPassword.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stbPassword.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stbPassword.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stbPassword.SkinTxt.Name = "BaseText";
            this.stbPassword.SkinTxt.PasswordChar = '●';
            this.stbPassword.SkinTxt.Size = new System.Drawing.Size(151, 18);
            this.stbPassword.SkinTxt.TabIndex = 0;
            this.stbPassword.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stbPassword.SkinTxt.WaterText = "密码";
            this.stbPassword.TabIndex = 160;
            // 
            // btnRegister
            // 
            this.btnRegister.AutoSize = true;
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(134)))), ((int)(((byte)(228)))));
            this.btnRegister.Location = new System.Drawing.Point(334, 98);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(52, 16);
            this.btnRegister.TabIndex = 163;
            this.btnRegister.Text = "注册帐号";
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.AutoSize = true;
            this.btnForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForgotPassword.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnForgotPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(134)))), ((int)(((byte)(228)))));
            this.btnForgotPassword.Location = new System.Drawing.Point(334, 136);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(52, 16);
            this.btnForgotPassword.TabIndex = 163;
            this.btnForgotPassword.Text = "找回密码";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ViewLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 14.25F);
            this.ClientSize = new System.Drawing.Size(417, 280);
            this.Controls.Add(this.btnForgotPassword);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.skinPanelAvatar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.stbAccount);
            this.Controls.Add(this.checkBoxRememberPwd);
            this.Controls.Add(this.checkBoxAutoLogin);
            this.Controls.Add(this.stbPassword);
            this.EffectWidth = 4;
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.MaximizeBox = false;
            this.Name = "ViewLogin";
            this.ShowDrawIcon = false;
            this.Text = "操作端登录";
            this.TitleOffset = new System.Drawing.Point(5, 15);
            this.TopMost = true;
            this.skinPanelAvatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAvatar)).EndInit();
            this.stbAccount.ResumeLayout(false);
            this.stbAccount.PerformLayout();
            this.stbPassword.ResumeLayout(false);
            this.stbPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanelAvatar;
        private System.Windows.Forms.PictureBox picBoxAvatar;
        private CCWin.SkinControl.SkinButton btnLogin;
        private CCWin.SkinControl.SkinTextBox stbAccount;
        private CCWin.SkinControl.SkinCheckBox checkBoxRememberPwd;
        private CCWin.SkinControl.SkinCheckBox checkBoxAutoLogin;
        private CCWin.SkinControl.SkinTextBox stbPassword;
        private System.Windows.Forms.Label btnRegister;
        private System.Windows.Forms.Label btnForgotPassword;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}