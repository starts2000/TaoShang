namespace Starts2000.TaoBao.Views
{
    partial class OrderRecordListControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderRecordListControl));
            this.PaginationOrderRecordList = new Starts2000.TaoBao.Views.Pagination();
            this.SdgvOrderRecordList = new CCWin.SkinControl.SkinDataGridView();
            this.ColShopTaoBaoAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.scbShop = new CCWin.SkinControl.SkinComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scbOrderState = new CCWin.SkinControl.SkinComboBox();
            this.sbtnSearch = new Starts2000.TaoBao.Views.SkinButtonEx();
            ((System.ComponentModel.ISupportInitialize)(this.SdgvOrderRecordList)).BeginInit();
            this.SuspendLayout();
            // 
            // PaginationOrderRecordList
            // 
            this.PaginationOrderRecordList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PaginationOrderRecordList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PaginationOrderRecordList.Location = new System.Drawing.Point(0, 236);
            this.PaginationOrderRecordList.Margin = new System.Windows.Forms.Padding(0);
            this.PaginationOrderRecordList.Name = "PaginationOrderRecordList";
            this.PaginationOrderRecordList.Size = new System.Drawing.Size(758, 30);
            this.PaginationOrderRecordList.TabIndex = 8;
            // 
            // SdgvOrderRecordList
            // 
            this.SdgvOrderRecordList.AllowUserToAddRows = false;
            this.SdgvOrderRecordList.AllowUserToDeleteRows = false;
            this.SdgvOrderRecordList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.SdgvOrderRecordList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SdgvOrderRecordList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SdgvOrderRecordList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.SdgvOrderRecordList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SdgvOrderRecordList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SdgvOrderRecordList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SdgvOrderRecordList.ColumnHeadersHeight = 26;
            this.SdgvOrderRecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.SdgvOrderRecordList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColShopTaoBaoAccount,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Column1,
            this.dataGridViewButtonColumn1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.SdgvOrderRecordList.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SdgvOrderRecordList.DefaultCellStyle = dataGridViewCellStyle9;
            this.SdgvOrderRecordList.EnableHeadersVisualStyles = false;
            this.SdgvOrderRecordList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SdgvOrderRecordList.Location = new System.Drawing.Point(0, 45);
            this.SdgvOrderRecordList.MultiSelect = false;
            this.SdgvOrderRecordList.Name = "SdgvOrderRecordList";
            this.SdgvOrderRecordList.ReadOnly = true;
            this.SdgvOrderRecordList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SdgvOrderRecordList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.SdgvOrderRecordList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.SdgvOrderRecordList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.SdgvOrderRecordList.RowTemplate.Height = 28;
            this.SdgvOrderRecordList.RowTemplate.ReadOnly = true;
            this.SdgvOrderRecordList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SdgvOrderRecordList.Size = new System.Drawing.Size(758, 191);
            this.SdgvOrderRecordList.TabIndex = 9;
            // 
            // ColShopTaoBaoAccount
            // 
            this.ColShopTaoBaoAccount.DataPropertyName = "UserShopWangWangAccount";
            this.ColShopTaoBaoAccount.HeaderText = "店铺掌柜";
            this.ColShopTaoBaoAccount.Name = "ColShopTaoBaoAccount";
            this.ColShopTaoBaoAccount.ReadOnly = true;
            this.ColShopTaoBaoAccount.Width = 110;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ClientUserAccount";
            this.dataGridViewTextBoxColumn3.HeaderText = "挂机会员";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ClientUserSubAccount";
            this.dataGridViewTextBoxColumn4.HeaderText = "挂机会员小号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "OrderStateId";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "刷单状态";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StartDateTime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn7.FillWeight = 27F;
            this.dataGridViewTextBoxColumn7.HeaderText = "开始时间";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "LastUpdateDateTime";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.FillWeight = 27F;
            this.Column1.HeaderText = "最后操作时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewButtonColumn1.FillWeight = 27F;
            this.dataGridViewButtonColumn1.HeaderText = "到期时间";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ClientUserLogin";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column2.HeaderText = "挂机状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column3.HeaderText = "连接状态";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "操作";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 80;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "店铺掌柜：";
            // 
            // scbShop
            // 
            this.scbShop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scbShop.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbShop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbShop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scbShop.FormattingEnabled = true;
            this.scbShop.Location = new System.Drawing.Point(334, 12);
            this.scbShop.Name = "scbShop";
            this.scbShop.Size = new System.Drawing.Size(120, 22);
            this.scbShop.TabIndex = 11;
            this.scbShop.WaterText = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "刷单状态：";
            // 
            // scbOrderState
            // 
            this.scbOrderState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scbOrderState.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbOrderState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.scbOrderState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scbOrderState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scbOrderState.FormattingEnabled = true;
            this.scbOrderState.Location = new System.Drawing.Point(541, 12);
            this.scbOrderState.Name = "scbOrderState";
            this.scbOrderState.Size = new System.Drawing.Size(120, 22);
            this.scbOrderState.TabIndex = 11;
            this.scbOrderState.WaterText = "";
            // 
            // sbtnSearch
            // 
            this.sbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnSearch.BackColor = System.Drawing.Color.Transparent;
            this.sbtnSearch.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sbtnSearch.DownBack = ((System.Drawing.Image)(resources.GetObject("sbtnSearch.DownBack")));
            this.sbtnSearch.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.sbtnSearch.Location = new System.Drawing.Point(677, 10);
            this.sbtnSearch.MouseBack = ((System.Drawing.Image)(resources.GetObject("sbtnSearch.MouseBack")));
            this.sbtnSearch.Name = "sbtnSearch";
            this.sbtnSearch.NormlBack = ((System.Drawing.Image)(resources.GetObject("sbtnSearch.NormlBack")));
            this.sbtnSearch.Palace = true;
            this.sbtnSearch.Size = new System.Drawing.Size(75, 25);
            this.sbtnSearch.TabIndex = 12;
            this.sbtnSearch.Text = "查  询";
            this.sbtnSearch.UseVisualStyleBackColor = false;
            // 
            // OrderRecordListControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.sbtnSearch);
            this.Controls.Add(this.scbOrderState);
            this.Controls.Add(this.scbShop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SdgvOrderRecordList);
            this.Controls.Add(this.PaginationOrderRecordList);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OrderRecordListControl";
            this.Size = new System.Drawing.Size(758, 266);
            ((System.ComponentModel.ISupportInitialize)(this.SdgvOrderRecordList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Pagination PaginationOrderRecordList;
        public CCWin.SkinControl.SkinDataGridView SdgvOrderRecordList;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinComboBox scbShop;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinComboBox scbOrderState;
        private SkinButtonEx sbtnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColShopTaoBaoAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;

    }
}
