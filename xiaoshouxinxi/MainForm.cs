/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/16
 * 时间: 18:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data.OleDb;
using System.Windows.Forms;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		//关闭所有子窗体
		public void  closeMdiChild(){
		  if (this.MdiChildren.Length > 0) {
            foreach (Form myForm in this.MdiChildren)
         myForm.Close(); 
       } 
		}
			
		//窗体加载	
		void MainFormLoad(object sender, EventArgs e)
		{
	        DataHelper helper = new DataHelper ();
		}
		
		//加载各个子窗体
		void 客户信息ToolStripMenuItemClick(object sender, EventArgs e)
		{
			closeMdiChild();
			FormKeHuXinXi kehuxinxi = new FormKeHuXinXi ();
			kehuxinxi .MdiParent = this ;
			kehuxinxi .WindowState = FormWindowState .Maximized ;
			kehuxinxi .Show ();
			
			
		}
		void 商品信息ToolStripMenuItemClick(object sender, EventArgs e)
		{
	        closeMdiChild();
	        FormShangPinXinxi shangpinxinxi = new FormShangPinXinxi ();
			shangpinxinxi  .MdiParent = this ;
			shangpinxinxi .WindowState = FormWindowState .Maximized ;
			shangpinxinxi .StartPosition =  FormStartPosition .CenterParent ;
			shangpinxinxi.Show();
			
		}
		void 销售信息ToolStripMenuItemClick(object sender, EventArgs e)
		{
	        closeMdiChild();
	        FormXiaoShou  xiaoshou = new FormXiaoShou  ();
			xiaoshou  .MdiParent = this ;
			xiaoshou .WindowState = FormWindowState .Maximized ;
			xiaoshou.Show();
		}
		void 销售查询ToolStripMenuItemClick(object sender, EventArgs e)
		{
			closeMdiChild ();
			FormDaoru  Daoru = new FormDaoru ();
			Daoru.ShowDialog ();
		}

        private void 数据库备份ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
			FormBackup formbackup = new FormBackup();
            formbackup.Show();
        }

        private void 数据库恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormRestore formrestore = new FormRestore();
			formrestore.Show();
        }
    }
	
	
	
	
	
}
