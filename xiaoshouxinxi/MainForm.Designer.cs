/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/16
 * 时间: 18:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xiaoshouxinxi
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 客户信息ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 商品信息ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 销售信息ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 销售查询ToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.客户信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.销售信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.销售查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库备份ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库恢复ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.客户信息ToolStripMenuItem,
            this.商品信息ToolStripMenuItem,
            this.销售信息ToolStripMenuItem,
            this.销售查询ToolStripMenuItem,
            this.数据库管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 客户信息ToolStripMenuItem
            // 
            this.客户信息ToolStripMenuItem.Name = "客户信息ToolStripMenuItem";
            this.客户信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.客户信息ToolStripMenuItem.Text = "客户信息";
            this.客户信息ToolStripMenuItem.Click += new System.EventHandler(this.客户信息ToolStripMenuItemClick);
            // 
            // 商品信息ToolStripMenuItem
            // 
            this.商品信息ToolStripMenuItem.Name = "商品信息ToolStripMenuItem";
            this.商品信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.商品信息ToolStripMenuItem.Text = "商品信息";
            this.商品信息ToolStripMenuItem.Click += new System.EventHandler(this.商品信息ToolStripMenuItemClick);
            // 
            // 销售信息ToolStripMenuItem
            // 
            this.销售信息ToolStripMenuItem.Name = "销售信息ToolStripMenuItem";
            this.销售信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.销售信息ToolStripMenuItem.Text = "销售信息";
            this.销售信息ToolStripMenuItem.Click += new System.EventHandler(this.销售信息ToolStripMenuItemClick);
            // 
            // 销售查询ToolStripMenuItem
            // 
            this.销售查询ToolStripMenuItem.Name = "销售查询ToolStripMenuItem";
            this.销售查询ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.销售查询ToolStripMenuItem.Text = "使用EXCEL生成";
            this.销售查询ToolStripMenuItem.Click += new System.EventHandler(this.销售查询ToolStripMenuItemClick);
            // 
            // 数据库管理ToolStripMenuItem
            // 
            this.数据库管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库备份ToolStripMenuItem1,
            this.数据库恢复ToolStripMenuItem});
            this.数据库管理ToolStripMenuItem.Name = "数据库管理ToolStripMenuItem";
            this.数据库管理ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.数据库管理ToolStripMenuItem.Text = "数据库管理";
            // 
            // 数据库备份ToolStripMenuItem1
            // 
            this.数据库备份ToolStripMenuItem1.Name = "数据库备份ToolStripMenuItem1";
            this.数据库备份ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.数据库备份ToolStripMenuItem1.Text = "数据库备份";
            this.数据库备份ToolStripMenuItem1.Click += new System.EventHandler(this.数据库备份ToolStripMenuItem1_Click);
            // 
            // 数据库恢复ToolStripMenuItem
            // 
            this.数据库恢复ToolStripMenuItem.Name = "数据库恢复ToolStripMenuItem";
            this.数据库恢复ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.数据库恢复ToolStripMenuItem.Text = "数据库恢复";
            this.数据库恢复ToolStripMenuItem.Click += new System.EventHandler(this.数据库恢复ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 691);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "销售单生成";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.ToolStripMenuItem 数据库管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库备份ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 数据库恢复ToolStripMenuItem;
    }
}
