namespace Starts2000.TaoBao.Views
{
    partial class ViewMainCloseConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewMainCloseConfirm));
            this.label1 = new System.Windows.Forms.Label();
            this.stbPassword = new CCWin.SkinControl.SkinTextBox();
            this.sbtnOk = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.sbtnCancel = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.stbPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(68, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "密  码：";
            // 
            // stbPassword
            // 
            this.stbPassword.BackColor = System.Drawing.Color.Transparent;
            this.stbPassword.Icon = null;
            this.stbPassword.IconIsButton = false;
            this.stbPassword.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbPassword.Location = new System.Drawing.Point(123, 67);
            this.stbPassword.Margin = new System.Windows.Forms.Padding(0);
            this.stbPassword.MinimumSize = new System.Drawing.Size(28, 28);
            this.stbPassword.MouseBack = null;
            this.stbPassword.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbPassword.Name = "stbPassword";
            this.stbPassword.NormlBack = null;
            this.stbPassword.Padding = new System.Windows.Forms.Padding(5);
            this.stbPassword.Size = new System.Drawing.Size(228, 28);
            // 
            // stbPassword.BaseText
            // 
            this.stbPassword.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stbPassword.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stbPassword.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stbPassword.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stbPassword.SkinTxt.Name = "BaseText";
            this.stbPassword.SkinTxt.Size = new System.Drawing.Size(218, 18);
            this.stbPassword.SkinTxt.TabIndex = 0;
            this.stbPassword.SkinTxt.UseSystemPasswordChar = true;
            this.stbPassword.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stbPassword.SkinTxt.WaterText = "";
            this.stbPassword.TabIndex = 1;
            // 
            // sbtnOk
            // 
            this.sbtnOk.BackColor = System.Drawing.Color.Transparent;
            this.sbtnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnOk.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.DownBack")));
            this.sbtnOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnOk.Location = new System.Drawing.Point(131, 133);
            this.sbtnOk.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.MouseBack")));
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.NormlBack")));
            this.sbtnOk.Palace = true;
            this.sbtnOk.Size = new System.Drawing.Size(75, 25);
            this.sbtnOk.TabIndex = 2;
            this.sbtnOk.Text = "确  定";
            this.sbtnOk.UseVisualStyleBackColor = false;
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.sbtnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnCancel.DownBack")));
            this.sbtnCancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnCancel.Location = new System.Drawing.Point(212, 133);
            this.sbtnCancel.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnCancel.MouseBack")));
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnCancel.NormlBack")));
            this.sbtnCancel.Palace = true;
            this.sbtnCancel.Size = new System.Drawing.Size(75, 25);
            this.sbtnCancel.TabIndex = 2;
            this.sbtnCancel.Text = "取  消";
            this.sbtnCancel.UseVisualStyleBackColor = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ViewMainCloseConfirm
            // 
            this.AcceptButton = this.sbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.sbtnCancel;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(418, 163);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.stbPassword);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewMainCloseConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "退出程序";
            this.stbPassword.ResumeLayout(false);
            this.stbPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinTextBox stbPassword;
        private SkinButtonEx sbtnOk;
        private SkinButtonEx sbtnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}