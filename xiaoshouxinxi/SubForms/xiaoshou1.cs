/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/3/8
 * 时间: 10:31
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */using System;
using System .IO ;
using System.Drawing;
using System.Windows.Forms;
using System .Data .SqlClient;
using System .Data .OleDb ;
using System .Data ;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using System .Collections.Generic ;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of FormXiaoShou.
	/// </summary>
	
	
	public partial class FormXiaoShou : Form
	{
		
		
		public void  FullDs()
		{
			DataHelper h = new DataHelper ();
			if (chuandi .GxDS .Tables ["neirong"] != null) chuandi .GxDS .Tables ["neirong"].Clear ();
			chuandi.adp = h.ADAPTERFillDataSet ("select * from neirong", chuandi.GxDS , "neirong");
			if (chuandi .GxDS .Tables ["beizhu"] != null) chuandi .GxDS .Tables ["beizhu"].Clear ();
			chuandi.adp.SelectCommand.CommandText = "select * from beizhu";
			chuandi.adp.Fill (chuandi .GxDS ,"beizhu");
			OleDbCommandBuilder cd = new OleDbCommandBuilder(chuandi.adp);
			
			h.close();
		}
		
       
		#region 生成显示的字符串
		/// <summary>
		/// 生成显示的字符串
		/// </summary>
		/// <param name="DDRq ">数据行数组</param>
		///  <param name="Field">放在字符串的列名，内容还是备注</param>
		public void ShowTable(DataRow[] DDRq,string Field)
		{
			List<DataRow> lDr = new List<DataRow>() ;  //定义已编号行列表
			List<DataRow> ldr = new List<DataRow>() ;  //定义未编号行列表
			
			foreach (DataRow ddr in DDRq) {
				if (int.Parse (ddr["bianhao"].ToString ()) == -1) {
					ldr.Add (ddr);
				}
				else{
					lDr.Add (ddr);
				}
				
			}
		    
		    		
			//清空数组列表
			chuandi .Lsr.Clear ();
			
            // 定义要转化后的字符串
			string str1 = "";
			
			// 已编号和未编号都不为空
			if (lDr.Count  > 0 && ldr.Count  > 0){
			    			    
			    int s = 0;    //已编号行的编号   
			    
			    int jsq = 0;
		    
			    foreach (DataRow  el in lDr) {
			 	    s= int.Parse (el["bianhao"].ToString ());
			 	   if (s > ldr.Count ) break ;                 //如果已编号的行其编号比列表的元素数要大，则不再插入，而改为直接添加
	     	 	     ldr.Insert (s-1, el);                     //插入列表
	     	 	     jsq ++;
			        }
			    
			    //对已经插入的列表按索引生成字符串
			    for (int i = 0; i < ldr.Count ; i++) {
	        		str1 =string.Format ("{0}?{1}?{2}",ldr[i]["id"].ToString ().Trim (),(i+1).ToString ().Trim (),ldr[i][Field].ToString().Trim ());
	        	    chuandi .Lsr .Add (str1);  	
			    }
			    
			    if (lDr.Count > jsq) {
			    	for (int i = jsq ; i < lDr .Count ; i++) {
			    		str1 =string.Format ("{0}?{1}?{2}",lDr[i]["id"].ToString ().Trim (),lDr[i]["bianhao"].ToString ().Trim (),lDr[i][Field].ToString().Trim ());
			    	   chuandi .Lsr .Add (str1);
			    	}
			    	
			    }
			        
			}
			
			
             //如果未编号为空，已编号不为空			
	    	
             if (lDr.Count > 0 && ldr.Count  == 0) {
				for (int i = 0; i < lDr.Count ; i++) {
				  str1 =string.Format ("{0}?{1}?{2}",lDr[i]["id"].ToString ().Trim (),lDr[i]["bianhao"].ToString ().Trim (),lDr[i][Field].ToString().Trim ());
				  chuandi .Lsr .Add (str1);
			    }
			}
             
		    //如果未编号不为空，已编号为空
			if (lDr.Count == 0 && ldr.Count > 0) {
			    for (int i = 0; i < ldr.Count ; i++) {
				   str1= string.Format ("{0}?{1}?{2}",ldr[i]["id"].ToString ().Trim (),(i+1).ToString ().Trim (),ldr[i][Field].ToString().Trim ());
				   chuandi .Lsr .Add (str1);
				}
			}
			
         	}
		#endregion 	
		
		
			
		public delegate void DELE();
		
		public event DELE d;
	
		#region   //添加进DataTable前的检验和返回编号（-1 还是 用户输入值）
        /// <summary>
        /// 检查这样的编号和内容有没有重复，能不能添加
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="Field">数据表字段名</param>
        /// <param name="NorB">内容或备注文本框的内容，判断是否重复</param>
        /// <param name="BianHao">编号</param>
        /// <returns></returns>
        public bool AddOrNot(DataTable dt ,string Field,string NorB ,int BianHao )
        {
        	//是否有一样的内容
        	
        	DataRow[] Drs = dt.Select (string.Format ("{0} = '{1}'",Field, NorB) );
        	if (Drs.Length > 0) return  false;
        	
        	//是否有一样的编号
        	if (BianHao != -1) {
        		DataRow[] drs = dt.Select ("bianhao = "+ BianHao);
        		if ( drs.Length > 0 ) return false;
        	}
        	
        	return true;
        	
        	}
        
            
        /// <summary>
        /// 返回编号
        /// </summary>
        /// <param name="BianHaoInput">输入的文本框里的编号，根据编号判断是不是-1</param>
        /// <returns></returns>
        public int  CreateBianHao (string BianHaoInput){
        	            	
        	if (BianHaoInput == "") return -1;
        	
        	if (!myvalidate .isAllNumric (BianHaoInput)) return -1;
        	        	      	
        	return Convert.ToInt32(BianHaoInput) ;
        }
		
		 
		#endregion


		
		
		public void ShowOther(DELE dele)
		{
			d = dele;
			
			d.Invoke ();
		}
		
		
		
		
		//看记录数有多少
		public int[] CountRecords(string TableName){
			
			DataHelper h = new DataHelper ();
			
			h.open ();
			
			OleDbDataReader dr = h.dataread ("select * from " + TableName );
			
			int Total = 0; int WeiBianHao = 0;
			
			while (dr.Read ()) {
			
				Total ++;
			   	
				if ( dr[1].ToString () == "-1")  WeiBianHao++;
			
			}
			
			h.close ();
			
			int[] n = {Total ,WeiBianHao };
			
			return  n;
			
		}
		
		
		//删除前n条未编号 记录
		public void DeleteN_Record(string TableName,int Delete_N){
			
			DataHelper h = new DataHelper ();
			
			h.open ();
			
			OleDbDataReader dr = h.dataread ("select * from " + TableName + " where bianhao = -1 order by id");
			
			List<int> li = new List<int> ();
			
			int n1 = 0;
			
			while (dr.Read ()) {
				li.Add (Convert .ToInt32 (dr[0]));
				if ((++n1) == Delete_N ) break ;
				
				
			}
			
			foreach (int el in li) {
				
				h.dataexecute ("delete from " + TableName + " where id = " + el);
			}
		 
			h.close ();
		}
		
		//计算并删除
		
		public void DeleteRe( string TableName){
			
			int RecordesLimit = 1000;
			
			int[] RN = CountRecords (TableName);
			
			int Total_sn = RN[0] - RecordesLimit ;
			
			int WeiBianHao_sn = RN[1] - RecordesLimit ;
						
			if ( Total_sn > 0 && WeiBianHao_sn > 0  ) {
				
				DeleteN_Record (TableName,Total_sn  );
			}
			
			
		}
		
		
		
		
		  
		
	    
		
		
	}
	}