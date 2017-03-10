namespace Starts2000.TaoBao.Views
{
    partial class Pagination
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbReload = new System.Windows.Forms.Label();
            this.lbNext = new System.Windows.Forms.Label();
            this.stbPageIndex = new System.Windows.Forms.TextBox();
            this.lbPrev = new System.Windows.Forms.Label();
            this.lbFirst = new System.Windows.Forms.Label();
            this.lbPageNum = new System.Windows.Forms.Label();
            this.lbLast = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPageSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 14;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.lbReload, 7, 0);
            this.tableLayoutPanel.Controls.Add(this.lbNext, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.stbPageIndex, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.lbPrev, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lbFirst, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lbPageNum, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.lbLast, 6, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.label2, 9, 0);
            this.tableLayoutPanel.Controls.Add(this.lbPageSize, 10, 0);
            this.tableLayoutPanel.Controls.Add(this.label4, 11, 0);
            this.tableLayoutPanel.Controls.Add(this.lbCount, 12, 0);
            this.tableLayoutPanel.Controls.Add(this.label6, 13, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(502, 30);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // lbReload
            // 
            this.lbReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbReload.Location = new System.Drawing.Point(182, 0);
            this.lbReload.Name = "lbReload";
            this.lbReload.Size = new System.Drawing.Size(14, 30);
            this.lbReload.TabIndex = 13;
            this.toolTip.SetToolTip(this.lbReload, "刷新");
            // 
            // lbNext
            // 
            this.lbNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNext.Location = new System.Drawing.Point(142, 0);
            this.lbNext.Name = "lbNext";
            this.lbNext.Size = new System.Drawing.Size(14, 30);
            this.lbNext.TabIndex = 5;
            this.toolTip.SetToolTip(this.lbNext, "下一页");
            // 
            // stbPageIndex
            // 
            this.stbPageIndex.Location = new System.Drawing.Point(43, 1);
            this.stbPageIndex.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.stbPageIndex.MinimumSize = new System.Drawing.Size(28, 28);
            this.stbPageIndex.Name = "stbPageIndex";
            this.stbPageIndex.Size = new System.Drawing.Size(65, 28);
            this.stbPageIndex.TabIndex = 2;
            // 
            // lbPrev
            // 
            this.lbPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPrev.Enabled = false;
            this.lbPrev.Location = new System.Drawing.Point(23, 0);
            this.lbPrev.Name = "lbPrev";
            this.lbPrev.Size = new System.Drawing.Size(14, 30);
            this.lbPrev.TabIndex = 1;
            this.toolTip.SetToolTip(this.lbPrev, "上一页");
            // 
            // lbFirst
            // 
            this.lbFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFirst.Enabled = false;
            this.lbFirst.Location = new System.Drawing.Point(3, 0);
            this.lbFirst.Name = "lbFirst";
            this.lbFirst.Size = new System.Drawing.Size(14, 30);
            this.lbFirst.TabIndex = 0;
            this.toolTip.SetToolTip(this.lbFirst, "首页");
            // 
            // lbPageNum
            // 
            this.lbPageNum.AutoSize = true;
            this.lbPageNum.Location = new System.Drawing.Point(124, 6);
            this.lbPageNum.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lbPageNum.Name = "lbPageNum";
            this.lbPageNum.Size = new System.Drawing.Size(15, 17);
            this.lbPageNum.TabIndex = 4;
            this.lbPageNum.Text = "0";
            this.lbPageNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLast
            // 
            this.lbLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLast.Location = new System.Drawing.Point(162, 0);
            this.lbLast.Name = "lbLast";
            this.lbLast.Size = new System.Drawing.Size(14, 30);
            this.lbLast.TabIndex = 6;
            this.toolTip.SetToolTip(this.lbLast, "末页");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "每页";
            // 
            // lbPageSize
            // 
            this.lbPageSize.AutoSize = true;
            this.lbPageSize.Location = new System.Drawing.Point(408, 6);
            this.lbPageSize.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lbPageSize.Name = "lbPageSize";
            this.lbPageSize.Size = new System.Drawing.Size(15, 17);
            this.lbPageSize.TabIndex = 9;
            this.lbPageSize.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "条，共";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(467, 6);
            this.lbCount.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(15, 17);
            this.lbCount.TabIndex = 11;
            this.lbCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(482, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "条";
            // 
            // Pagination
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "Pagination";
            this.Size = new System.Drawing.Size(502, 30);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lbNext;
        private System.Windows.Forms.TextBox stbPageIndex;
        private System.Windows.Forms.Label lbPrev;
        private System.Windows.Forms.Label lbFirst;
        private System.Windows.Forms.Label lbPageNum;
        private System.Windows.Forms.Label lbLast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPageSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lbReload;
    }
}
