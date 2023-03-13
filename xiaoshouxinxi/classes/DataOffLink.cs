/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/3/9
 * 时间: 9:59
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System .Data ;
using System .Data .OleDb ;
using System .Data .SqlClient;
using System .Windows .Forms ;

public class DataOffLink{
    
	
	    #region  增加一个记录，同时增加DataTable和数据库
		/// <summary>
		/// 填充DataTable
		/// </summary>
		/// /// <param name="Dt">数据表</param>
		/// <param name="field">列名</param>
		/// <param name="TxtNeiRongOrBeiZhu">内容或备注</param>
		/// <param name="Txt">编号文本框的内容</param>
		/// <param name="s">适配器的选择符串</param>
		public void AddTable(DataTable Dt, string field, int BianHao ,string TxtNeiRongOrBeiZhu ){
			
			DataRow row = Dt .NewRow ();
            
			row["bianhao"] = BianHao;
			
			row[field] = TxtNeiRongOrBeiZhu .Trim ();
			
			Dt.Rows.Add (row);
			
			chuandi.adp.SelectCommand .CommandText = string.Format ("select * from {0}",Dt.TableName );;
			
			OleDbCommandBuilder cd =new OleDbCommandBuilder(chuandi.adp );
			
			chuandi.adp.Update (Dt );
		}
		
		   
		#endregion
	

	
	#region   删除内容和备注
	     /// <summary>
        /// 删除内容和备注
        /// </summary>
        /// <param name="Dt">要删除的表</param>
        /// <param name="id">根据id</param>
	    public void DeleteTable (DataTable Dt, int id)
        {
        	DataRow[] Dr = Dt.Select ("id = " + id);
        	
        	if (Dr.Length == 0) return ;
        	
        	Dr[0].Delete ();
        	       	
        	chuandi.adp.SelectCommand .CommandText = string.Format("select * from {0}",Dt.TableName);

        	OleDbCommandBuilder cd =new OleDbCommandBuilder(chuandi.adp );
			
			chuandi.adp.Update (Dt);
			
			Dt.AcceptChanges ();
			
		    		
		
	    }
		#endregion

}