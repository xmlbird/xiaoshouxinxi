/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/28
 * 时间: 10:49
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of FormDaochuQuery.
	/// </summary>
	public partial class FormDaochuQuery : Form
	{
		public FormDaochuQuery()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			radioButton1 .Checked = true;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			   chuandi .ifName =true ;
			   if (!radioButton1 .Checked ) {
				chuandi .ifName = false ;
				}

			   this.Close();
		}
	}
}
