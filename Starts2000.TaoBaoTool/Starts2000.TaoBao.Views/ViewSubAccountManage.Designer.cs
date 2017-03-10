namespace Starts2000.TaoBao.Views
{
    partial class ViewSubAccountManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSubAccountManage));
            this.sdgvSubAccountList = new CCWin.SkinControl.SkinDataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTaoBaoAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRealName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColMobile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColAudit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sbtnDelete = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.sbtnAdd = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.sbtnExit = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.sbtnUpdate = new Starts2000.TaoBao.Views.SkinButtonEx();
            ((System.ComponentModel.ISupportInitialize)(this.sdgvSubAccountList)).BeginInit();
            this.SuspendLayout();
            // 
            // sdgvSubAccountList
            // 
            this.sdgvSubAccountList.AllowUserToAddRows = false;
            this.sdgvSubAccountList.AllowUserToDeleteRows = false;
            this.sdgvSubAccountList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.sdgvSubAccountList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.sdgvSubAccountList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sdgvSubAccountList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sdgvSubAccountList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sdgvSubAccountList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sdgvSubAccountList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sdgvSubAccountList.ColumnHeadersHeight = 26;
            this.sdgvSubAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sdgvSubAccountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColTaoBaoAccount,
            this.ColLevel,
            this.ColRealName,
            this.ColMobile,
            this.ColEnabled,
            this.ColAudit});
            this.sdgvSubAccountList.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sdgvSubAccountList.DefaultCellStyle = dataGridViewCellStyle4;
            this.sdgvSubAccountList.EnableHeadersVisualStyles = false;
            this.sdgvSubAccountList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sdgvSubAccountList.Location = new System.Drawing.Point(1, 31);
            this.sdgvSubAccountList.Name = "sdgvSubAccountList";
            this.sdgvSubAccountList.ReadOnly = true;
            this.sdgvSubAccountList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sdgvSubAccountList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.sdgvSubAccountList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.sdgvSubAccountList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.sdgvSubAccountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sdgvSubAccountList.Size = new System.Drawing.Size(667, 348);
            this.sdgvSubAccountList.TabIndex = 0;
            // 
            // ColId
            // 
            this.ColId.DataPropertyName = "Id";
            this.ColId.HeaderText = "Id";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            // 
            // ColTaoBaoAccount
            // 
            this.ColTaoBaoAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTaoBaoAccount.DataPropertyName = "TaoBaoAccount";
            this.ColTaoBaoAccount.HeaderText = "淘宝帐号";
            this.ColTaoBaoAccount.Name = "ColTaoBaoAccount";
            this.ColTaoBaoAccount.ReadOnly = true;
            // 
            // ColLevel
            // 
            this.ColLevel.DataPropertyName = "Level";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColLevel.HeaderText = "等级";
            this.ColLevel.Name = "ColLevel";
            this.ColLevel.ReadOnly = true;
            this.ColLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColRealName
            // 
            this.ColRealName.DataPropertyName = "IsRealName";
            this.ColRealName.HeaderText = "实名";
            this.ColRealName.Name = "ColRealName";
            this.ColRealName.ReadOnly = true;
            this.ColRealName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColRealName.Width = 80;
            // 
            // ColMobile
            // 
            this.ColMobile.DataPropertyName = "IsBindingMobile";
            this.ColMobile.HeaderText = "手机绑定";
            this.ColMobile.Name = "ColMobile";
            this.ColMobile.ReadOnly = true;
            this.ColMobile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColMobile.Width = 80;
            // 
            // ColEnabled
            // 
            this.ColEnabled.DataPropertyName = "IsEnabled";
            this.ColEnabled.HeaderText = "启用";
            this.ColEnabled.Name = "ColEnabled";
            this.ColEnabled.ReadOnly = true;
            this.ColEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEnabled.Width = 80;
            // 
            // ColAudit
            // 
            this.ColAudit.DataPropertyName = "IsAudit";
            this.ColAudit.HeaderText = "审核";
            this.ColAudit.Name = "ColAudit";
            this.ColAudit.ReadOnly = true;
            this.ColAudit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColAudit.Width = 80;
            // 
            // sbtnDelete
            // 
            this.sbtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDelete.BackColor = System.Drawing.Color.Transparent;
            this.sbtnDelete.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnDelete.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnDelete.DownBack")));
            this.sbtnDelete.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnDelete.Location = new System.Drawing.Point(266, 388);
            this.sbtnDelete.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnDelete.MouseBack")));
            this.sbtnDelete.Name = "sbtnDelete";
            this.sbtnDelete.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnDelete.NormlBack")));
            this.sbtnDelete.Palace = true;
            this.sbtnDelete.Size = new System.Drawing.Size(75, 25);
            this.sbtnDelete.TabIndex = 2;
            this.sbtnDelete.Text = "删  除";
            this.sbtnDelete.UseVisualStyleBackColor = false;
            this.sbtnDelete.Visible = false;
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnAdd.BackColor = System.Drawing.Color.Transparent;
            this.sbtnAdd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnAdd.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnAdd.DownBack")));
            this.sbtnAdd.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnAdd.Location = new System.Drawing.Point(424, 388);
            this.sbtnAdd.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnAdd.MouseBack")));
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnAdd.NormlBack")));
            this.sbtnAdd.Palace = true;
            this.sbtnAdd.Size = new System.Drawing.Size(75, 25);
            this.sbtnAdd.TabIndex = 1;
            this.sbtnAdd.Text = "添  加";
            this.sbtnAdd.UseVisualStyleBackColor = false;
            // 
            // sbtnExit
            // 
            this.sbtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnExit.BackColor = System.Drawing.Color.Transparent;
            this.sbtnExit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnExit.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnExit.DownBack")));
            this.sbtnExit.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnExit.Location = new System.Drawing.Point(586, 388);
            this.sbtnExit.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnExit.MouseBack")));
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnExit.NormlBack")));
            this.sbtnExit.Palace = true;
            this.sbtnExit.Size = new System.Drawing.Size(75, 25);
            this.sbtnExit.TabIndex = 3;
            this.sbtnExit.Text = "退  出";
            this.sbtnExit.UseVisualStyleBackColor = false;
            // 
            // sbtnUpdate
            // 
            this.sbtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.sbtnUpdate.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnUpdate.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnUpdate.DownBack")));
            this.sbtnUpdate.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnUpdate.Location = new System.Drawing.Point(505, 388);
            this.sbtnUpdate.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnUpdate.MouseBack")));
            this.sbtnUpdate.Name = "sbtnUpdate";
            this.sbtnUpdate.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnUpdate.NormlBack")));
            this.sbtnUpdate.Palace = true;
            this.sbtnUpdate.Size = new System.Drawing.Size(75, 25);
            this.sbtnUpdate.TabIndex = 2;
            this.sbtnUpdate.Text = "修  改";
            this.sbtnUpdate.UseVisualStyleBackColor = false;
            // 
            // ViewSubAccountManage
            // 
            this.AcceptButton = this.sbtnAdd;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.sbtnExit;
            this.ClientSize = new System.Drawing.Size(669, 420);
            this.Controls.Add(this.sbtnExit);
            this.Controls.Add(this.sbtnUpdate);
            this.Controls.Add(this.sbtnAdd);
            this.Controls.Add(this.sbtnDelete);
            this.Controls.Add(this.sdgvSubAccountList);
            this.MinimumSize = new System.Drawing.Size(640, 420);
            this.Name = "ViewSubAccountManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "小号管理";
            ((System.ComponentModel.ISupportInitialize)(this.sdgvSubAccountList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinDataGridView sdgvSubAccountList;
        private SkinButtonEx sbtnDelete;
        private SkinButtonEx sbtnAdd;
        private SkinButtonEx sbtnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTaoBaoAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLevel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColRealName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColMobile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColEnabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColAudit;
        private SkinButtonEx sbtnUpdate;
    }
}