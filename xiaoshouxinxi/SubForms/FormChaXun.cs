/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/26
 * 时间: 17:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb ;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of FormChaXun.
	/// </summary>
	public partial class FormChaXun : Form
	{
		public FormChaXun()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormChaXunLoad(object sender, EventArgs e)
		{
			chuandi .StrBack = "";
			
			DataHelper helper = new DataHelper ();
			string str = "select name from kehu";
			helper .open();
			OleDbDataReader reader = helper .dataread (str);
			if (reader.HasRows == true)
			{
				while (reader.Read() )
				{
					CmbName .Items .Add (reader[0].ToString ());
				}
			}
			helper .close ();
		}
		void Button1Click(object sender, EventArgs e)
		{
			
//		     str1 = ;
//			string str2 = string.Format("{0,yyyy-MM-dd}",dateTimePicker1 .Value );
			if(myvalidate .ifblank (CmbName .Text.Trim () ))
			   {
				chuandi .ifName = false;
				chuandi.StrBack = string.Format("select * from xiaoshou where time1 between  # {0}# and #{1}# order by id",string.Format("{0:yyyy-MM-dd} 00:00:00", dateTimePicker1 .Value ),string.Format("{0:yyyy-MM-dd} 23:59:59", dateTimePicker2 .Value ))  ;
			   }
			   else
			   {
			   	chuandi .ifName = true;
			   	string Name1 = CmbName .Text.Trim ();
			   	chuandi.StrBack = string.Format("select * from xiaoshou where  kehu = '{0}' and time1 between # {1}# and #{2}# order by id",Name1,string.Format("{0:yyyy-MM-dd} 00:00:00", dateTimePicker1 .Value ), string.Format("{0:yyyy-MM-dd} 23:59:59", dateTimePicker2 .Value ))  ;
			   }
		
			   this.Close ();
		
		}
		
		
		
		
	}
}
