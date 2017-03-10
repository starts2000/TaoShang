namespace Starts2000.TaobaoPlatform.Manager.Client
{
    partial class FormShopManager
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
            this.dgvShopList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancelAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopList)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvShopList
            // 
            this.dgvShopList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShopList.ContextMenuStrip = this.contextMenuStrip;
            this.dgvShopList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShopList.Location = new System.Drawing.Point(0, 0);
            this.dgvShopList.MultiSelect = false;
            this.dgvShopList.Name = "dgvShopList";
            this.dgvShopList.ReadOnly = true;
            this.dgvShopList.RowTemplate.Height = 23;
            this.dgvShopList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShopList.Size = new System.Drawing.Size(858, 328);
            this.dgvShopList.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAudit,
            this.tsmiCancelAudit,
            this.toolStripSeparator1,
            this.tsmiUpdate,
            this.tsmiDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(149, 98);
            // 
            // tsmiAudit
            // 
            this.tsmiAudit.Name = "tsmiAudit";
            this.tsmiAudit.Size = new System.Drawing.Size(148, 22);
            this.tsmiAudit.Text = "通过审核";
            // 
            // tsmiCancelAudit
            // 
            this.tsmiCancelAudit.Name = "tsmiCancelAudit";
            this.tsmiCancelAudit.Size = new System.Drawing.Size(148, 22);
            this.tsmiCancelAudit.Text = "取消审核";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(148, 22);
            this.tsmiDelete.Text = "删除店铺信息";
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(148, 22);
            this.tsmiUpdate.Text = "修改店铺信息";
            // 
            // FormShopManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 328);
            this.Controls.Add(this.dgvShopList);
            this.Name = "FormShopManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "店铺管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopList)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShopList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiAudit;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelAudit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
    }
}