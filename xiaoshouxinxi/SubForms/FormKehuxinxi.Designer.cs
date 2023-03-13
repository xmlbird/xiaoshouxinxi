/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/17
 * 时间: 8:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xiaoshouxinxi
{
	partial class FormKeHuXinXi
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader id;
		private System.Windows.Forms.ColumnHeader name;
		private System.Windows.Forms.TextBox TxtAdd;
		private System.Windows.Forms.Button BtnAdd;
		private System.Windows.Forms.Button BtnDelete;
		private System.Windows.Forms.ColumnHeader trueid;
		
		
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
		  private void InitializeComponent()   {
            this.listView1 = new System.Windows.Forms.ListView();
            this.trueid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtAdd = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.trueid,
            this.id,
            this.name});
            this.listView1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(205, 400);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // trueid
            // 
            this.trueid.DisplayIndex = 2;
            this.trueid.Text = "id1";
            this.trueid.Width = 0;
            // 
            // id
            // 
            this.id.DisplayIndex = 0;
            this.id.Text = "序号";
            // 
            // name
            // 
            this.name.DisplayIndex = 1;
            this.name.Text = "姓名";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name.Width = 120;
            // 
            // TxtAdd
            // 
            this.TxtAdd.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtAdd.Location = new System.Drawing.Point(252, 70);
            this.TxtAdd.MaxLength = 25;
            this.TxtAdd.Name = "TxtAdd";
            this.TxtAdd.Size = new System.Drawing.Size(134, 29);
            this.TxtAdd.TabIndex = 1;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAdd.Location = new System.Drawing.Point(252, 155);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(134, 44);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "添    加";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDelete.Location = new System.Drawing.Point(252, 258);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(134, 45);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "删    除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // FormKeHuXinXi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 423);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TxtAdd);
            this.Controls.Add(this.listView1);
            this.Name = "FormKeHuXinXi";
            this.Text = "客户信息";
            this.Load += new System.EventHandler(this.FormKeHuXinXiLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		  }
	}
}