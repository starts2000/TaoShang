namespace Starts2000.TaoBao.Views
{
    partial class ViewOrderRecordInfoOpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewOrderRecordInfoOpt));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scbOrderState = new CCWin.SkinControl.SkinComboBox();
            this.scbShopAccount = new CCWin.SkinControl.SkinComboBox();
            this.stbOrderNum = new CCWin.SkinControl.SkinTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sbtnOk = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.stbSubAcount = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbStartDateTime = new System.Windows.Forms.Label();
            this.lbEndDateTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.scbOrderType = new CCWin.SkinControl.SkinComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbLastDateTime = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.stbOrderNum.SuspendLayout();
            this.stbSubAcount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(44, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "刷单状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(44, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "店铺掌柜：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(56, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "订单号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(44, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "旺旺小号：";
            // 
            // scbOrderState
            // 
            this.scbOrderState.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbOrderState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbOrderState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scbOrderState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scbOrderState.FormattingEnabled = true;
            this.scbOrderState.Location = new System.Drawing.Point(115, 43);
            this.scbOrderState.Name = "scbOrderState";
            this.scbOrderState.Size = new System.Drawing.Size(254, 24);
            this.scbOrderState.TabIndex = 1;
            this.scbOrderState.WaterText = "";
            // 
            // scbShopAccount
            // 
            this.scbShopAccount.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbShopAccount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbShopAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scbShopAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scbShopAccount.FormattingEnabled = true;
            this.scbShopAccount.Location = new System.Drawing.Point(115, 92);
            this.scbShopAccount.Name = "scbShopAccount";
            this.scbShopAccount.Size = new System.Drawing.Size(254, 24);
            this.scbShopAccount.TabIndex = 2;
            this.scbShopAccount.WaterText = "";
            // 
            // stbOrderNum
            // 
            this.stbOrderNum.BackColor = System.Drawing.Color.Transparent;
            this.stbOrderNum.Icon = null;
            this.stbOrderNum.IconIsButton = false;
            this.stbOrderNum.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbOrderNum.Location = new System.Drawing.Point(115, 221);
            this.stbOrderNum.Margin = new System.Windows.Forms.Padding(0);
            this.stbOrderNum.MinimumSize = new System.Drawing.Size(28, 28);
            this.stbOrderNum.MouseBack = null;
            this.stbOrderNum.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbOrderNum.Name = "stbOrderNum";
            this.stbOrderNum.NormlBack = null;
            this.stbOrderNum.Padding = new System.Windows.Forms.Padding(5);
            this.stbOrderNum.Size = new System.Drawing.Size(254, 28);
            // 
            // stbOrderNum.BaseText
            // 
            this.stbOrderNum.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stbOrderNum.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stbOrderNum.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stbOrderNum.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stbOrderNum.SkinTxt.Name = "BaseText";
            this.stbOrderNum.SkinTxt.Size = new System.Drawing.Size(244, 18);
            this.stbOrderNum.SkinTxt.TabIndex = 0;
            this.stbOrderNum.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stbOrderNum.SkinTxt.WaterText = "";
            this.stbOrderNum.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(112, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "* 此状态不可逆，请谨慎选择";
            // 
            // sbtnOk
            // 
            this.sbtnOk.BackColor = System.Drawing.Color.Transparent;
            this.sbtnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnOk.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.DownBack")));
            this.sbtnOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnOk.Location = new System.Drawing.Point(178, 371);
            this.sbtnOk.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.MouseBack")));
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.NormlBack")));
            this.sbtnOk.Palace = true;
            this.sbtnOk.Size = new System.Drawing.Size(75, 25);
            this.sbtnOk.TabIndex = 6;
            this.sbtnOk.Text = "确    定";
            this.sbtnOk.UseVisualStyleBackColor = false;
            // 
            // stbSubAcount
            // 
            this.stbSubAcount.BackColor = System.Drawing.Color.Transparent;
            this.stbSubAcount.Enabled = false;
            this.stbSubAcount.Icon = null;
            this.stbSubAcount.IconIsButton = false;
            this.stbSubAcount.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbSubAcount.Location = new System.Drawing.Point(115, 130);
            this.stbSubAcount.Margin = new System.Windows.Forms.Padding(0);
            this.stbSubAcount.MinimumSize = new System.Drawing.Size(28, 28);
            this.stbSubAcount.MouseBack = null;
            this.stbSubAcount.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stbSubAcount.Name = "stbSubAcount";
            this.stbSubAcount.NormlBack = null;
            this.stbSubAcount.Padding = new System.Windows.Forms.Padding(5);
            this.stbSubAcount.Size = new System.Drawing.Size(254, 28);
            // 
            // stbSubAcount.BaseText
            // 
            this.stbSubAcount.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stbSubAcount.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stbSubAcount.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stbSubAcount.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stbSubAcount.SkinTxt.Name = "BaseText";
            this.stbSubAcount.SkinTxt.Size = new System.Drawing.Size(244, 18);
            this.stbSubAcount.SkinTxt.TabIndex = 0;
            this.stbSubAcount.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stbSubAcount.SkinTxt.WaterText = "";
            this.stbSubAcount.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(44, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(44, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "到期时间：";
            // 
            // lbStartDateTime
            // 
            this.lbStartDateTime.AutoSize = true;
            this.lbStartDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lbStartDateTime.Location = new System.Drawing.Point(112, 261);
            this.lbStartDateTime.Name = "lbStartDateTime";
            this.lbStartDateTime.Size = new System.Drawing.Size(20, 17);
            this.lbStartDateTime.TabIndex = 0;
            this.lbStartDateTime.Text = "   ";
            // 
            // lbEndDateTime
            // 
            this.lbEndDateTime.AutoSize = true;
            this.lbEndDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lbEndDateTime.ForeColor = System.Drawing.Color.Red;
            this.lbEndDateTime.Location = new System.Drawing.Point(112, 313);
            this.lbEndDateTime.Name = "lbEndDateTime";
            this.lbEndDateTime.Size = new System.Drawing.Size(20, 17);
            this.lbEndDateTime.TabIndex = 0;
            this.lbEndDateTime.Text = "   ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(127, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "* 刷单开始后，需30天内完成。";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(44, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "刷单类别：";
            // 
            // scbOrderType
            // 
            this.scbOrderType.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbOrderType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbOrderType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scbOrderType.FormattingEnabled = true;
            this.scbOrderType.Location = new System.Drawing.Point(115, 173);
            this.scbOrderType.Name = "scbOrderType";
            this.scbOrderType.Size = new System.Drawing.Size(254, 24);
            this.scbOrderType.TabIndex = 2;
            this.scbOrderType.WaterText = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(20, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "最近操作时间：";
            // 
            // lbLastDateTime
            // 
            this.lbLastDateTime.AutoSize = true;
            this.lbLastDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lbLastDateTime.Location = new System.Drawing.Point(112, 287);
            this.lbLastDateTime.Name = "lbLastDateTime";
            this.lbLastDateTime.Size = new System.Drawing.Size(20, 17);
            this.lbLastDateTime.TabIndex = 0;
            this.lbLastDateTime.Text = "   ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(112, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(257, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "* 请选择正确的类别，以便大家获得真实信息。";
            // 
            // ViewOrderRecordInfoOpt
            // 
            this.AcceptButton = this.sbtnOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(430, 403);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.stbSubAcount);
            this.Controls.Add(this.stbOrderNum);
            this.Controls.Add(this.scbOrderType);
            this.Controls.Add(this.scbShopAccount);
            this.Controls.Add(this.scbOrderState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbEndDateTime);
            this.Controls.Add(this.lbLastDateTime);
            this.Controls.Add(this.lbStartDateTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewOrderRecordInfoOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "刷单信息";
            this.stbOrderNum.ResumeLayout(false);
            this.stbOrderNum.PerformLayout();
            this.stbSubAcount.ResumeLayout(false);
            this.stbSubAcount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CCWin.SkinControl.SkinComboBox scbOrderState;
        private CCWin.SkinControl.SkinComboBox scbShopAccount;
        private CCWin.SkinControl.SkinTextBox stbOrderNum;
        private System.Windows.Forms.Label label8;
        private SkinButtonEx sbtnOk;
        private CCWin.SkinControl.SkinTextBox stbSubAcount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbStartDateTime;
        private System.Windows.Forms.Label lbEndDateTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private CCWin.SkinControl.SkinComboBox scbOrderType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbLastDateTime;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label11;
    }
}