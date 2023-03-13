/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/3/4
 * 时间: 21:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System .Data ;
using System .Data .OleDb ;
using System .Data.SqlClient ;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of FormNeiRong.
	/// </summary>
	public partial class FormNeiRong : Form
	{
		
		public delegate DataSet DeleDataSet();
		public FormNeiRong()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	    public Control Ctr { get; set; }
	    
		public FormNeiRong(Control  ctr1):this()
		{
			Ctr = ctr1 ;
		
		}
		void Button2Click(object sender, EventArgs e)
		{
			if ( LsvNeiRong.SelectedItems .Count == 0 ) return ;
			
			int s = Convert.ToInt32 (LsvNeiRong.SelectedItems[0].SubItems[0].Text .Trim () );
			
			DataExec .DE ("delete from neirong where id = " + s);
						
			LsvNeiRong.Items .Remove (LsvNeiRong.SelectedItems [0]);
			
			chuandi .GxDS .Tables ["neirong"].Clear ();
			
			chuandi.adp.SelectCommand.CommandText = "select * from neirong";
			
			chuandi.adp.Fill (chuandi .GxDS ,"neirong");
				
		}
		
		void FormNeiRongLoad(object sender, EventArgs e)
		{
			
		}
		
	
		void FormNeiRongFormClosing(object sender, FormClosingEventArgs e)
		{
			chuandi .FormShuo  = false ;
		}
		
		
		public void InitShow()
		{
			LsvNeiRong.Items .Clear ();
			string[] st;
			for (int i = 0; i < chuandi .Lsr .Count ; i++) {
				st = chuandi .Lsr[i].Split('?');
				ListViewItem ls = new ListViewItem (st[0]);
				ls.SubItems.Add (st[1]);
				ls.SubItems.Add (st[2]);
				LsvNeiRong.Items .Add (ls);
			}
			LsvNeiRong .EndUpdate ();
		   
		}
		void LsvNeiRongSelectedIndexChanged(object sender, EventArgs e)
		{
	
		}
		void LsvNeiRongMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(LsvNeiRong .SelectedItems.Count == 0)return ;
			Ctr.Text = LsvNeiRong.SelectedItems[0].SubItems[2].Text.Trim ();
	          
		}
			
		public string  FullBlank(string str){
			
			for (int i = 0; i < LsvNeiRong .Items .Count ; i++) {
				if (LsvNeiRong .Items[i].SubItems[1].Text == str ) {
					return LsvNeiRong .Items[i].SubItems[2].Text ;
				}
		
			}
		
			return string.Empty ;
			
				
				
				
		}
		
		}
	}
