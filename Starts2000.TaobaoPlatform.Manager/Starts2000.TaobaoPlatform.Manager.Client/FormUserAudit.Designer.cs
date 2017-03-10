namespace Starts2000.TaobaoPlatform.Manager.Client
{
    partial class FormUserAudit
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAudit = new System.Windows.Forms.CheckBox();
            this.cbLock = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(143, 6);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.ReadOnly = true;
            this.tbAccount.Size = new System.Drawing.Size(208, 21);
            this.tbAccount.TabIndex = 1;
            this.tbAccount.TabStop = false;
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.Location = new System.Drawing.Point(143, 33);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Size = new System.Drawing.Size(208, 21);
            this.dtpExpireDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "到期时间：";
            // 
            // cbAudit
            // 
            this.cbAudit.AutoSize = true;
            this.cbAudit.Location = new System.Drawing.Point(225, 75);
            this.cbAudit.Name = "cbAudit";
            this.cbAudit.Size = new System.Drawing.Size(48, 16);
            this.cbAudit.TabIndex = 4;
            this.cbAudit.Text = "审核";
            this.cbAudit.UseVisualStyleBackColor = true;
            // 
            // cbLock
            // 
            this.cbLock.AutoSize = true;
            this.cbLock.Location = new System.Drawing.Point(279, 75);
            this.cbLock.Name = "cbLock";
            this.cbLock.Size = new System.Drawing.Size(72, 16);
            this.cbLock.TabIndex = 4;
            this.cbLock.Text = "锁定账户";
            this.cbLock.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(133, 111);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确  定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(214, 111);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退  出";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // FormUserAudit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(423, 146);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbLock);
            this.Controls.Add(this.cbAudit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpExpireDate);
            this.Controls.Add(this.tbAccount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserAudit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户审核";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.DateTimePicker dtpExpireDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAudit;
        private System.Windows.Forms.CheckBox cbLock;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnExit;
    }
}