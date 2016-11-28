namespace OVCS
{
    partial class WhiteBoardPanel
    {
        /// <summary> 
        /// 必需的设计器变量.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源.
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false.</param>
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
        /// 使用代码编辑器修改此方法的内容.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhiteBoardPanel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_progress = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripButton_end = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_next = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_totalCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_pre = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_first = new System.Windows.Forms.ToolStripButton();
            this.whiteBoardConnector1 = new OMCS.Passive.WhiteBoard.WhiteBoardConnector();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_progress,
            this.toolStripProgressBar1,
            this.toolStripButton_end,
            this.toolStripButton_next,
            this.toolStripLabel_totalCount,
            this.toolStripButton_pre,
            this.toolStripButton_first});
            this.toolStrip1.Location = new System.Drawing.Point(0, 498);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(783, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel_progress
            // 
            this.toolStripLabel_progress.Name = "toolStripLabel_progress";
            this.toolStripLabel_progress.Size = new System.Drawing.Size(216, 28);
            this.toolStripLabel_progress.Text = "Download Courseware ：1/4";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 28);
            // 
            // toolStripButton_end
            // 
            this.toolStripButton_end.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_end.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_end.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_end.Image")));
            this.toolStripButton_end.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_end.Name = "toolStripButton_end";
            this.toolStripButton_end.Size = new System.Drawing.Size(23, 28);
            this.toolStripButton_end.Text = "末页";
            // 
            // toolStripButton_next
            // 
            this.toolStripButton_next.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_next.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_next.Image")));
            this.toolStripButton_next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_next.Name = "toolStripButton_next";
            this.toolStripButton_next.Size = new System.Drawing.Size(23, 28);
            this.toolStripButton_next.Text = "下一页";
            // 
            // toolStripLabel_totalCount
            // 
            this.toolStripLabel_totalCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_totalCount.Name = "toolStripLabel_totalCount";
            this.toolStripLabel_totalCount.Size = new System.Drawing.Size(45, 28);
            this.toolStripLabel_totalCount.Text = "1 / 6 ";
            // 
            // toolStripButton_pre
            // 
            this.toolStripButton_pre.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_pre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_pre.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_pre.Image")));
            this.toolStripButton_pre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_pre.Name = "toolStripButton_pre";
            this.toolStripButton_pre.Size = new System.Drawing.Size(23, 28);
            this.toolStripButton_pre.Text = "上一页";
            // 
            // toolStripButton_first
            // 
            this.toolStripButton_first.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_first.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_first.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_first.Image")));
            this.toolStripButton_first.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_first.Name = "toolStripButton_first";
            this.toolStripButton_first.Size = new System.Drawing.Size(23, 28);
            this.toolStripButton_first.Text = "首页";
            // 
            // whiteBoardConnector1
            // 
            this.whiteBoardConnector1.AutoReconnect = false;           
            this.whiteBoardConnector1.BackImageOfPage = null;
            this.whiteBoardConnector1.ContextMenuEnglish = true;
            this.whiteBoardConnector1.CoursewareEnabled = true;
            this.whiteBoardConnector1.Cursor = System.Windows.Forms.Cursors.No;
            this.whiteBoardConnector1.DisplayPageBorder = false;
            this.whiteBoardConnector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whiteBoardConnector1.FocusOnNewViewByOther = true;
            this.whiteBoardConnector1.IsManager = true;
            this.whiteBoardConnector1.Location = new System.Drawing.Point(0, 0);
            this.whiteBoardConnector1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.whiteBoardConnector1.MinimumSize = new System.Drawing.Size(943, 312);
            this.whiteBoardConnector1.Name = "whiteBoardConnector1";
            this.whiteBoardConnector1.PageSize = new System.Drawing.Size(800, 600);
            this.whiteBoardConnector1.Size = new System.Drawing.Size(943, 498);
            this.whiteBoardConnector1.TabIndex = 1;
            this.whiteBoardConnector1.Timeout4LoadContent = 120;
            this.whiteBoardConnector1.ToolBarVisiable = true;
            this.whiteBoardConnector1.WaitOwnerOnlineSpanInSecs = 0;
            this.whiteBoardConnector1.WatchingOnly = false;
            this.whiteBoardConnector1.ZoomFactor = OMCS.Passive.WhiteBoard.WhiteBoardZoomFactor.Percent100;
            // 
            // WhiteBoardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.whiteBoardConnector1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WhiteBoardPanel";
            this.Size = new System.Drawing.Size(783, 529);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_progress;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton toolStripButton_end;
        private System.Windows.Forms.ToolStripButton toolStripButton_next;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_totalCount;
        private System.Windows.Forms.ToolStripButton toolStripButton_pre;
        private System.Windows.Forms.ToolStripButton toolStripButton_first;
        private OMCS.Passive.WhiteBoard.WhiteBoardConnector whiteBoardConnector1;
    }
}
