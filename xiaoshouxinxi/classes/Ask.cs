/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/24
 * 时间: 10:23
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of Ask.
	/// </summary>
	static class Ask
{
	static public bool YesOrNot(string str)
	{
		DialogResult a = MessageBox .Show(str,"注意",MessageBoxButtons .YesNo ,MessageBoxIcon .Question ,MessageBoxDefaultButton .Button1 );
	if (a == DialogResult.No )
	{return false;}
	else
	{return true;}
	}
}
}
