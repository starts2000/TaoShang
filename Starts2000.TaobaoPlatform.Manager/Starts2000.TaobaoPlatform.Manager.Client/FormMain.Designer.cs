namespace Starts2000.TaobaoPlatform.Manager.Client
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddHangupTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddGold = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSubAccountManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShopManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.paginationUserList = new Starts2000.TaoBao.Views.Pagination();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRestPassword = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUserList
            // 
            this.dgvUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserList.ContextMenuStrip = this.contextMenuStrip;
            this.dgvUserList.Location = new System.Drawing.Point(-1, 53);
            this.dgvUserList.Margin = new System.Windows.Forms.Padding(5);
            this.dgvUserList.MultiSelect = false;
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.ReadOnly = true;
            this.dgvUserList.RowTemplate.Height = 23;
            this.dgvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserList.Size = new System.Drawing.Size(633, 289);
            this.dgvUserList.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAudit,
            this.tsmiAddHangupTime,
            this.tsmiAddGold,
            this.toolStripSeparator1,
            this.tsmiSubAccountManager,
            this.tsmiShopManager,
            this.toolStripSeparator2,
            this.tsmiRestPassword});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 170);
            // 
            // tsmiAudit
            // 
            this.tsmiAudit.Name = "tsmiAudit";
            this.tsmiAudit.Size = new System.Drawing.Size(152, 22);
            this.tsmiAudit.Text = "帐号审核";
            // 
            // tsmiAddHangupTime
            // 
            this.tsmiAddHangupTime.Name = "tsmiAddHangupTime";
            this.tsmiAddHangupTime.Size = new System.Drawing.Size(152, 22);
            this.tsmiAddHangupTime.Text = "增加挂机时间";
            // 
            // tsmiAddGold
            // 
            this.tsmiAddGold.Name = "tsmiAddGold";
            this.tsmiAddGold.Size = new System.Drawing.Size(152, 22);
            this.tsmiAddGold.Text = "增加金币";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiSubAccountManager
            // 
            this.tsmiSubAccountManager.Name = "tsmiSubAccountManager";
            this.tsmiSubAccountManager.Size = new System.Drawing.Size(152, 22);
            this.tsmiSubAccountManager.Text = "小号管理";
            // 
            // tsmiShopManager
            // 
            this.tsmiShopManager.Name = "tsmiShopManager";
            this.tsmiShopManager.Size = new System.Drawing.Size(152, 22);
            this.tsmiShopManager.Text = "店铺管理";
            // 
            // tbAccount
            // 
            this.tbAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAccount.Location = new System.Drawing.Point(369, 12);
            this.tbAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(173, 26);
            this.tbAccount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名：";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(548, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查  询";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // paginationUserList
            // 
            this.paginationUserList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paginationUserList.Location = new System.Drawing.Point(2, 351);
            this.paginationUserList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.paginationUserList.Name = "paginationUserList";
            this.paginationUserList.Size = new System.Drawing.Size(630, 31);
            this.paginationUserList.TabIndex = 1;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiRestPassword
            // 
            this.tsmiRestPassword.Name = "tsmiRestPassword";
            this.tsmiRestPassword.Size = new System.Drawing.Size(152, 22);
            this.tsmiRestPassword.Text = "重置密码";
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(633, 382);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAccount);
            this.Controls.Add(this.paginationUserList);
            this.Controls.Add(this.dgvUserList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "淘商助手后台管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserList;
        private TaoBao.Views.Pagination paginationUserList;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiAudit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddHangupTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddGold;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSubAccountManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiShopManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestPassword;
    }
}

