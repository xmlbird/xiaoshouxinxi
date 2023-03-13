/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/26
 * 时间: 19:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System .Windows .Forms ;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of CDataGridView.
	/// </summary>
	public class CDataGridView
	{
		public DataGridViewCellStyle DsNormal()
		{
			DataGridViewCellStyle ds = new DataGridViewCellStyle();
			ds.Alignment =  DataGridViewContentAlignment.MiddleCenter;
			ds.ForeColor  = System .Drawing .Color .Black;
			return ds;
		}
		
		public DataGridViewCellStyle DsRed()
		{
			DataGridViewCellStyle ds = new DataGridViewCellStyle();
			ds.Alignment =  DataGridViewContentAlignment.MiddleCenter;
			ds.ForeColor  = System .Drawing .Color .Red;
			return ds;
		}

        public DataGridViewCellStyle DsLeft()
        {
            DataGridViewCellStyle ds = new DataGridViewCellStyle();
            ds.Alignment = DataGridViewContentAlignment.MiddleLeft ;
            ds.ForeColor = System.Drawing.Color.Black;
            return ds;
        }

        public DataGridViewCellStyle DsRedLeft()
        {
            DataGridViewCellStyle ds = new DataGridViewCellStyle();
            ds.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ds.ForeColor = System.Drawing.Color.Red;
            return ds;
        }



    }
}
