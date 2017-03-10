namespace Starts2000.TaoBao.Views
{
    partial class ViewAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAbout));
            this.pbAbout = new System.Windows.Forms.PictureBox();
            this.sbtnExit = new Starts2000.TaoBao.Views.SkinButtonEx();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAbout
            // 
            this.pbAbout.Location = new System.Drawing.Point(2, 32);
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size(550, 357);
            this.pbAbout.TabIndex = 0;
            this.pbAbout.TabStop = false;
            // 
            // sbtnExit
            // 
            this.sbtnExit.BackColor = System.Drawing.Color.Transparent;
            this.sbtnExit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnExit.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnExit.DownBack")));
            this.sbtnExit.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnExit.Location = new System.Drawing.Point(240, 397);
            this.sbtnExit.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnExit.MouseBack")));
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnExit.NormlBack")));
            this.sbtnExit.Palace = true;
            this.sbtnExit.Size = new System.Drawing.Size(75, 25);
            this.sbtnExit.TabIndex = 1;
            this.sbtnExit.Text = "退  出";
            this.sbtnExit.UseVisualStyleBackColor = false;
            // 
            // ViewAbout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.sbtnExit;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(554, 427);
            this.Controls.Add(this.sbtnExit);
            this.Controls.Add(this.pbAbout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAbout";
            this.Text = "关于淘商助手";
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAbout;
        private SkinButtonEx sbtnExit;
    }
}