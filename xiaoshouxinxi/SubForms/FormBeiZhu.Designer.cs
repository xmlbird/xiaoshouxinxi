/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/3/8
 * 时间: 11:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xiaoshouxinxi
{
	partial class FormBeiZhu
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button BtnDelete;
		private System.Windows.Forms.ListView LsvBeiZhu;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.BtnDelete = new System.Windows.Forms.Button();
			this.LsvBeiZhu = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox1.Location = new System.Drawing.Point(32, 261);
			this.textBox1.MaxLength = 3;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(61, 26);
			this.textBox1.TabIndex = 7;
			// 
			// BtnDelete
			// 
			this.BtnDelete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtnDelete.Location = new System.Drawing.Point(129, 257);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.Size = new System.Drawing.Size(66, 30);
			this.BtnDelete.TabIndex = 6;
			this.BtnDelete.Text = "删除";
			this.BtnDelete.UseVisualStyleBackColor = true;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
			// 
			// LsvBeiZhu
			// 
			this.LsvBeiZhu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader3,
			this.columnHeader1,
			this.columnHeader2});
			this.LsvBeiZhu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LsvBeiZhu.FullRowSelect = true;
			this.LsvBeiZhu.GridLines = true;
			this.LsvBeiZhu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LsvBeiZhu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.LsvBeiZhu.Location = new System.Drawing.Point(12, 12);
			this.LsvBeiZhu.MultiSelect = false;
			this.LsvBeiZhu.Name = "LsvBeiZhu";
			this.LsvBeiZhu.Size = new System.Drawing.Size(210, 235);
			this.LsvBeiZhu.TabIndex = 5;
			this.LsvBeiZhu.UseCompatibleStateImageBehavior = false;
			this.LsvBeiZhu.View = System.Windows.Forms.View.Details;
			this.LsvBeiZhu.SelectedIndexChanged += new System.EventHandler(this.LsvBeiZhuSelectedIndexChanged);
			this.LsvBeiZhu.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LsvBeiZhuMouseDoubleClick);
			// 
			// columnHeader3
			// 
			this.columnHeader3.DisplayIndex = 2;
			this.columnHeader3.Text = "id";
			this.columnHeader3.Width = 0;
			// 
			// columnHeader1
			// 
			this.columnHeader1.DisplayIndex = 0;
			this.columnHeader1.Text = "编号";
			this.columnHeader1.Width = 50;
			// 
			// columnHeader2
			// 
			this.columnHeader2.DisplayIndex = 1;
			this.columnHeader2.Text = "内容";
			this.columnHeader2.Width = 190;
			// 
			// FormBeiZhu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(231, 303);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.BtnDelete);
			this.Controls.Add(this.LsvBeiZhu);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormBeiZhu";
			this.Text = "备注";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBeiZhuFormClosing);
			this.Load += new System.EventHandler(this.FormBeiZhuLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
