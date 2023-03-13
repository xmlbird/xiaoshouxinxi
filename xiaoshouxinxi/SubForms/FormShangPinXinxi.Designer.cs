/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/20
 * 时间: 20:43
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xiaoshouxinxi
{
	partial class FormShangPinXinxi
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader trueid;
		private System.Windows.Forms.ColumnHeader id;
		private System.Windows.Forms.ColumnHeader name;
		private System.Windows.Forms.ColumnHeader danjia;
		private System.Windows.Forms.TextBox TxtName;
		private System.Windows.Forms.TextBox TxtDanjia;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BtnAdd;
		private System.Windows.Forms.Button BtnXiuGai;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button BtnQueDing;
		private System.Windows.Forms.Button BtnQuXiao;
		private System.Windows.Forms.GroupBox groupBox1;
		
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.trueid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.danjia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtDanjia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnXiuGai = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BtnQueDing = new System.Windows.Forms.Button();
            this.BtnQuXiao = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.trueid,
            this.id,
            this.name,
            this.danjia});
            this.listView1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(345, 393);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // trueid
            // 
            this.trueid.Text = "trueid";
            this.trueid.Width = 0;
            // 
            // id
            // 
            this.id.Text = "序号";
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // name
            // 
            this.name.Text = "名称";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name.Width = 170;
            // 
            // danjia
            // 
            this.danjia.Text = "单价";
            this.danjia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.danjia.Width = 100;
            // 
            // TxtName
            // 
            this.TxtName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtName.Location = new System.Drawing.Point(453, 53);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(206, 26);
            this.TxtName.TabIndex = 1;
            // 
            // TxtDanjia
            // 
            this.TxtDanjia.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtDanjia.Location = new System.Drawing.Point(453, 112);
            this.TxtDanjia.MaxLength = 8;
            this.TxtDanjia.Name = "TxtDanjia";
            this.TxtDanjia.Size = new System.Drawing.Size(131, 26);
            this.TxtDanjia.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(375, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "商品名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(375, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "单    价";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAdd.Location = new System.Drawing.Point(385, 182);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(274, 43);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Text = "添    加";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // BtnXiuGai
            // 
            this.BtnXiuGai.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnXiuGai.Location = new System.Drawing.Point(6, 26);
            this.BtnXiuGai.Name = "BtnXiuGai";
            this.BtnXiuGai.Size = new System.Drawing.Size(73, 43);
            this.BtnXiuGai.TabIndex = 3;
            this.BtnXiuGai.Text = "修  改";
            this.BtnXiuGai.UseVisualStyleBackColor = true;
            this.BtnXiuGai.Click += new System.EventHandler(this.BtnXiuGaiClick);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(385, 347);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(274, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "删    除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // BtnQueDing
            // 
            this.BtnQueDing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnQueDing.Location = new System.Drawing.Point(100, 26);
            this.BtnQueDing.Name = "BtnQueDing";
            this.BtnQueDing.Size = new System.Drawing.Size(79, 43);
            this.BtnQueDing.TabIndex = 3;
            this.BtnQueDing.Text = "确  定";
            this.BtnQueDing.UseVisualStyleBackColor = true;
            this.BtnQueDing.Click += new System.EventHandler(this.BtnQueDingClick);
            // 
            // BtnQuXiao
            // 
            this.BtnQuXiao.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnQuXiao.Location = new System.Drawing.Point(200, 26);
            this.BtnQuXiao.Name = "BtnQuXiao";
            this.BtnQuXiao.Size = new System.Drawing.Size(73, 43);
            this.BtnQuXiao.TabIndex = 3;
            this.BtnQuXiao.Text = "取  消";
            this.BtnQuXiao.UseVisualStyleBackColor = true;
            this.BtnQuXiao.Click += new System.EventHandler(this.BtnQuXiaoClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnXiuGai);
            this.groupBox1.Controls.Add(this.BtnQueDing);
            this.groupBox1.Controls.Add(this.BtnQuXiao);
            this.groupBox1.Location = new System.Drawing.Point(385, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 83);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改";
            // 
            // FormShangPinXinxi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDanjia);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.listView1);
            this.Name = "FormShangPinXinxi";
            this.Text = "商品信息";
            this.Load += new System.EventHandler(this.FormShangPinXinxiLoad);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
