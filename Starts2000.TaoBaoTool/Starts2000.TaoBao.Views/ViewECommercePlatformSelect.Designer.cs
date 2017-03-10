namespace Starts2000.TaoBao.Views
{
    partial class ViewECommercePlatformSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewECommercePlatformSelect));
            this.srbTaoBao = new CCWin.SkinControl.SkinRadioButton();
            this.srb1688Ali = new CCWin.SkinControl.SkinRadioButton();
            this.sbtnOk = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.SuspendLayout();
            // 
            // srbTaoBao
            // 
            this.srbTaoBao.AutoSize = true;
            this.srbTaoBao.BackColor = System.Drawing.Color.Transparent;
            this.srbTaoBao.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.srbTaoBao.Checked = true;
            this.srbTaoBao.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.srbTaoBao.DownBack = null;
            this.srbTaoBao.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.srbTaoBao.Location = new System.Drawing.Point(45, 55);
            this.srbTaoBao.MouseBack = null;
            this.srbTaoBao.Name = "srbTaoBao";
            this.srbTaoBao.NormlBack = null;
            this.srbTaoBao.SelectedDownBack = null;
            this.srbTaoBao.SelectedMouseBack = null;
            this.srbTaoBao.SelectedNormlBack = null;
            this.srbTaoBao.Size = new System.Drawing.Size(62, 21);
            this.srbTaoBao.TabIndex = 0;
            this.srbTaoBao.TabStop = true;
            this.srbTaoBao.Text = "淘宝店";
            this.srbTaoBao.UseVisualStyleBackColor = false;
            // 
            // srb1688Ali
            // 
            this.srb1688Ali.AutoSize = true;
            this.srb1688Ali.BackColor = System.Drawing.Color.Transparent;
            this.srb1688Ali.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.srb1688Ali.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.srb1688Ali.DownBack = null;
            this.srb1688Ali.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.srb1688Ali.Location = new System.Drawing.Point(132, 55);
            this.srb1688Ali.MouseBack = null;
            this.srb1688Ali.Name = "srb1688Ali";
            this.srb1688Ali.NormlBack = null;
            this.srb1688Ali.SelectedDownBack = null;
            this.srb1688Ali.SelectedMouseBack = null;
            this.srb1688Ali.SelectedNormlBack = null;
            this.srb1688Ali.Size = new System.Drawing.Size(90, 21);
            this.srb1688Ali.TabIndex = 0;
            this.srb1688Ali.Text = "1688阿里店";
            this.srb1688Ali.UseVisualStyleBackColor = false;
            // 
            // sbtnOk
            // 
            this.sbtnOk.BackColor = System.Drawing.Color.Transparent;
            this.sbtnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnOk.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.DownBack")));
            this.sbtnOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnOk.Location = new System.Drawing.Point(96, 104);
            this.sbtnOk.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.MouseBack")));
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnOk.NormlBack")));
            this.sbtnOk.Palace = true;
            this.sbtnOk.Size = new System.Drawing.Size(75, 25);
            this.sbtnOk.TabIndex = 1;
            this.sbtnOk.Text = "确    定";
            this.sbtnOk.UseVisualStyleBackColor = false;
            // 
            // ViewECommercePlatformSelect
            // 
            this.AcceptButton = this.sbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(267, 134);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.srb1688Ali);
            this.Controls.Add(this.srbTaoBao);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewECommercePlatformSelect";
            this.Text = "电商平台选择";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinRadioButton srbTaoBao;
        private CCWin.SkinControl.SkinRadioButton srb1688Ali;
        private SkinButtonEx sbtnOk;
    }
}