/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/3/8
 * 时间: 11:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of FormBeiZhu.
	/// </summary>
	public partial class FormBeiZhu : Form
	{
		public FormBeiZhu()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Control  Ctr { get; set; }
		
		public FormBeiZhu (Control ctr):this ()
		{
			Ctr = ctr;
		}
		void FormBeiZhuLoad(object sender, EventArgs e)
		{
			
		}
		
		
		public void InitShow()
		{
			LsvBeiZhu.Items .Clear ();
			string[] st;
			for (int i = 0; i < chuandi .Lsr .Count ; i++) {
				st = chuandi .Lsr[i].Split('?');
				ListViewItem ls = new ListViewItem (st[0]);
				ls.SubItems.Add (st[1]);
				ls.SubItems.Add (st[2]);
				LsvBeiZhu.Items .Add (ls);
			}
			LsvBeiZhu .EndUpdate ();
		   
		}
		void FormBeiZhuFormClosing(object sender, FormClosingEventArgs e)
		{
	         chuandi .FormShuo1  = false ;
		}
		
		void BtnDeleteClick(object sender, EventArgs e)
		{
			if ( LsvBeiZhu .SelectedItems .Count == 0 ) return ;
			
			int s = Convert.ToInt32 (LsvBeiZhu .SelectedItems[0].SubItems[0].Text .Trim () );
			
			DataExec .DE ("delete from beizhu where id = " + s);
						
			LsvBeiZhu .Items .Remove (LsvBeiZhu .SelectedItems [0]);
			
			chuandi .GxDS .Tables ["beizhu"].Clear ();
			
			chuandi.adp.SelectCommand.CommandText = "select * from beizhu";
			
			chuandi.adp.Fill (chuandi .GxDS ,"beizhu");
		}
		void LsvBeiZhuMouseDoubleClick(object sender, MouseEventArgs e)
		{
		
			if (LsvBeiZhu .SelectedItems.Count == 0) return ;
			Ctr.Text = LsvBeiZhu.SelectedItems[0].SubItems [2].Text.Trim ();
			
		}
		
		
		public string  FullBlank(string str){
			
			for (int i = 0; i < LsvBeiZhu .Items .Count ; i++) {
				if (LsvBeiZhu .Items[i].SubItems[1].Text == str ) {
					return LsvBeiZhu .Items[i].SubItems[2].Text ;
				}
		
			}
		
			return string.Empty ;
			
				
				
				
		}
		void LsvBeiZhuSelectedIndexChanged(object sender, EventArgs e)
		{
	
		}
		
	}
}
