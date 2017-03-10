namespace Starts2000.TaoBao.Views
{
    partial class ViewUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUserInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAccount = new System.Windows.Forms.Label();
            this.lbGold = new System.Windows.Forms.Label();
            this.lbExpireDate = new System.Windows.Forms.Label();
            this.stbOk = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(64, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "帐  号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(64, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "金  币：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(48, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "到期时间：";
            // 
            // lbAccount
            // 
            this.lbAccount.AutoSize = true;
            this.lbAccount.BackColor = System.Drawing.Color.Transparent;
            this.lbAccount.Location = new System.Drawing.Point(122, 45);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(16, 17);
            this.lbAccount.TabIndex = 0;
            this.lbAccount.Text = "  ";
            // 
            // lbGold
            // 
            this.lbGold.AutoSize = true;
            this.lbGold.BackColor = System.Drawing.Color.Transparent;
            this.lbGold.Location = new System.Drawing.Point(122, 71);
            this.lbGold.Name = "lbGold";
            this.lbGold.Size = new System.Drawing.Size(16, 17);
            this.lbGold.TabIndex = 0;
            this.lbGold.Text = "  ";
            // 
            // lbExpireDate
            // 
            this.lbExpireDate.AutoSize = true;
            this.lbExpireDate.BackColor = System.Drawing.Color.Transparent;
            this.lbExpireDate.Location = new System.Drawing.Point(122, 97);
            this.lbExpireDate.Name = "lbExpireDate";
            this.lbExpireDate.Size = new System.Drawing.Size(16, 17);
            this.lbExpireDate.TabIndex = 0;
            this.lbExpireDate.Text = "  ";
            // 
            // stbOk
            // 
            this.stbOk.BackColor = System.Drawing.Color.Transparent;
            this.stbOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.stbOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.stbOk.DownBack = ((System.Drawing.Image)(resources.GetObject("stbOk.DownBack")));
            this.stbOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.stbOk.Location = new System.Drawing.Point(128, 131);
            this.stbOk.MouseBack = ((System.Drawing.Image)(resources.GetObject("stbOk.MouseBack")));
            this.stbOk.Name = "stbOk";
            this.stbOk.NormlBack = ((System.Drawing.Image)(resources.GetObject("stbOk.NormlBack")));
            this.stbOk.Palace = true;
            this.stbOk.Size = new System.Drawing.Size(75, 25);
            this.stbOk.TabIndex = 1;
            this.stbOk.Text = "确  定";
            this.stbOk.UseVisualStyleBackColor = false;
            // 
            // ViewUserInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.stbOk;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(330, 160);
            this.Controls.Add(this.stbOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbExpireDate);
            this.Controls.Add(this.lbGold);
            this.Controls.Add(this.lbAccount);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Label lbGold;
        private System.Windows.Forms.Label lbExpireDate;
        private SkinButtonEx stbOk;
    }
}