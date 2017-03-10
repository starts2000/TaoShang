namespace Starts2000.TaobaoPlatform.Manager.Client
{
    partial class FormUpdateShop
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
            this.tbShopName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbShopUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbShopLevel = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTaobaoAccount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店铺名称：";
            // 
            // tbShopName
            // 
            this.tbShopName.Location = new System.Drawing.Point(122, 47);
            this.tbShopName.Name = "tbShopName";
            this.tbShopName.Size = new System.Drawing.Size(258, 21);
            this.tbShopName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "店铺网址：";
            // 
            // tbShopUrl
            // 
            this.tbShopUrl.Location = new System.Drawing.Point(122, 77);
            this.tbShopUrl.Name = "tbShopUrl";
            this.tbShopUrl.Size = new System.Drawing.Size(258, 21);
            this.tbShopUrl.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "店铺等级：";
            // 
            // cbShopLevel
            // 
            this.cbShopLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShopLevel.FormattingEnabled = true;
            this.cbShopLevel.Items.AddRange(new object[] {
            "一心",
            "二心",
            "三心",
            "四心",
            "五心",
            "一蓝砖",
            "二蓝砖",
            "三蓝砖",
            "四蓝砖",
            "五蓝砖",
            "一皇冠",
            "二皇冠",
            "三皇冠",
            "四皇冠",
            "五皇冠",
            "一金冠",
            "二金冠",
            "三金冠",
            "四金冠",
            "五金冠"});
            this.cbShopLevel.Location = new System.Drawing.Point(122, 107);
            this.cbShopLevel.Name = "cbShopLevel";
            this.cbShopLevel.Size = new System.Drawing.Size(258, 20);
            this.cbShopLevel.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpdate.Location = new System.Drawing.Point(136, 148);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "修  改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(217, 148);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退  出";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "淘宝旺旺号：";
            // 
            // tbTaobaoAccount
            // 
            this.tbTaobaoAccount.Location = new System.Drawing.Point(122, 17);
            this.tbTaobaoAccount.Name = "tbTaobaoAccount";
            this.tbTaobaoAccount.ReadOnly = true;
            this.tbTaobaoAccount.Size = new System.Drawing.Size(258, 21);
            this.tbTaobaoAccount.TabIndex = 1;
            this.tbTaobaoAccount.TabStop = false;
            // 
            // FormUpdateShop
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(419, 182);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cbShopLevel);
            this.Controls.Add(this.tbShopUrl);
            this.Controls.Add(this.tbTaobaoAccount);
            this.Controls.Add(this.tbShopName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormUpdateShop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改店铺信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbShopName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbShopUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbShopLevel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTaobaoAccount;
    }
}