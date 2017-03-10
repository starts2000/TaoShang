namespace Starts2000.TaoBao.Views
{
    partial class ViewShopManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewShopManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sdgvShopList = new CCWin.SkinControl.SkinDataGridView();
            this.sbtnDelete = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.sbtnAdd = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.sbtnExit = new Starts2000.TaoBao.Views.SkinButtonEx();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTaoBaoAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColShopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColShopLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColShopUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAudit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sdgvShopList)).BeginInit();
            this.SuspendLayout();
            // 
            // sdgvShopList
            // 
            this.sdgvShopList.AllowUserToAddRows = false;
            this.sdgvShopList.AllowUserToDeleteRows = false;
            this.sdgvShopList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.sdgvShopList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.sdgvShopList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sdgvShopList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sdgvShopList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sdgvShopList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sdgvShopList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sdgvShopList.ColumnHeadersHeight = 26;
            this.sdgvShopList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sdgvShopList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColUserId,
            this.ColTaoBaoAccount,
            this.ColShopName,
            this.ColShopLevel,
            this.ColShopUrl,
            this.ColAudit});
            this.sdgvShopList.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sdgvShopList.DefaultCellStyle = dataGridViewCellStyle4;
            this.sdgvShopList.EnableHeadersVisualStyles = false;
            this.sdgvShopList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sdgvShopList.Location = new System.Drawing.Point(1, 31);
            this.sdgvShopList.MultiSelect = false;
            this.sdgvShopList.Name = "sdgvShopList";
            this.sdgvShopList.ReadOnly = true;
            this.sdgvShopList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sdgvShopList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.sdgvShopList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.sdgvShopList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.sdgvShopList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sdgvShopList.Size = new System.Drawing.Size(667, 348);
            this.sdgvShopList.TabIndex = 0;
            // 
            // sbtnDelete
            // 
            this.sbtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDelete.BackColor = System.Drawing.Color.Transparent;
            this.sbtnDelete.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnDelete.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnDelete.DownBack")));
            this.sbtnDelete.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnDelete.Location = new System.Drawing.Point(275, 388);
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
            this.sbtnAdd.Location = new System.Drawing.Point(505, 388);
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
            // ColId
            // 
            this.ColId.DataPropertyName = "Id";
            this.ColId.HeaderText = "Id";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            // 
            // ColUserId
            // 
            this.ColUserId.DataPropertyName = "UserId";
            this.ColUserId.HeaderText = "UserId";
            this.ColUserId.Name = "ColUserId";
            this.ColUserId.ReadOnly = true;
            this.ColUserId.Visible = false;
            // 
            // ColTaoBaoAccount
            // 
            this.ColTaoBaoAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTaoBaoAccount.DataPropertyName = "WangWangAccount";
            this.ColTaoBaoAccount.FillWeight = 30F;
            this.ColTaoBaoAccount.HeaderText = "淘宝旺旺号";
            this.ColTaoBaoAccount.Name = "ColTaoBaoAccount";
            this.ColTaoBaoAccount.ReadOnly = true;
            // 
            // ColShopName
            // 
            this.ColShopName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColShopName.DataPropertyName = "ShopName";
            this.ColShopName.FillWeight = 30F;
            this.ColShopName.HeaderText = "店铺名";
            this.ColShopName.Name = "ColShopName";
            this.ColShopName.ReadOnly = true;
            this.ColShopName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColShopLevel
            // 
            this.ColShopLevel.DataPropertyName = "ShopLevel";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColShopLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColShopLevel.HeaderText = "店铺等级";
            this.ColShopLevel.Name = "ColShopLevel";
            this.ColShopLevel.ReadOnly = true;
            this.ColShopLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColShopLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColShopUrl
            // 
            this.ColShopUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColShopUrl.DataPropertyName = "ShopUrl";
            this.ColShopUrl.FillWeight = 40F;
            this.ColShopUrl.HeaderText = "店铺网址";
            this.ColShopUrl.Name = "ColShopUrl";
            this.ColShopUrl.ReadOnly = true;
            this.ColShopUrl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColShopUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColAudit
            // 
            this.ColAudit.DataPropertyName = "Audit";
            this.ColAudit.HeaderText = "审核";
            this.ColAudit.Name = "ColAudit";
            this.ColAudit.ReadOnly = true;
            this.ColAudit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColAudit.Width = 80;
            // 
            // ViewShopManage
            // 
            this.AcceptButton = this.sbtnAdd;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.sbtnExit;
            this.ClientSize = new System.Drawing.Size(669, 420);
            this.Controls.Add(this.sbtnExit);
            this.Controls.Add(this.sbtnAdd);
            this.Controls.Add(this.sbtnDelete);
            this.Controls.Add(this.sdgvShopList);
            this.MinimumSize = new System.Drawing.Size(640, 420);
            this.Name = "ViewShopManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "店铺管理";
            ((System.ComponentModel.ISupportInitialize)(this.sdgvShopList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinDataGridView sdgvShopList;
        private SkinButtonEx sbtnDelete;
        private SkinButtonEx sbtnAdd;
        private SkinButtonEx sbtnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTaoBaoAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColShopName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColShopLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColShopUrl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColAudit;
    }
}