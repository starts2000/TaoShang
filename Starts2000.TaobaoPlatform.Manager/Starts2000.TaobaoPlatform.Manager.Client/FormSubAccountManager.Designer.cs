namespace Starts2000.TaobaoPlatform.Manager.Client
{
    partial class FormSubAccountManager
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
            this.dgvSubAccountList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancelAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubAccountList)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSubAccountList
            // 
            this.dgvSubAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubAccountList.ContextMenuStrip = this.contextMenuStrip;
            this.dgvSubAccountList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubAccountList.Location = new System.Drawing.Point(0, 0);
            this.dgvSubAccountList.MultiSelect = false;
            this.dgvSubAccountList.Name = "dgvSubAccountList";
            this.dgvSubAccountList.ReadOnly = true;
            this.dgvSubAccountList.RowTemplate.Height = 23;
            this.dgvSubAccountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubAccountList.Size = new System.Drawing.Size(825, 292);
            this.dgvSubAccountList.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAudit,
            this.tsmiCancelAudit,
            this.toolStripSeparator1,
            this.tsmiDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 76);
            // 
            // tsmiAudit
            // 
            this.tsmiAudit.Name = "tsmiAudit";
            this.tsmiAudit.Size = new System.Drawing.Size(124, 22);
            this.tsmiAudit.Text = "通过审核";
            // 
            // tsmiCancelAudit
            // 
            this.tsmiCancelAudit.Name = "tsmiCancelAudit";
            this.tsmiCancelAudit.Size = new System.Drawing.Size(124, 22);
            this.tsmiCancelAudit.Text = "取消审核";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(124, 22);
            this.tsmiDelete.Text = "删除小号";
            // 
            // FormSubAccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 292);
            this.Controls.Add(this.dgvSubAccountList);
            this.Name = "FormSubAccountManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "小号管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubAccountList)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubAccountList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiAudit;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelAudit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
    }
}