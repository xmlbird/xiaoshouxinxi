/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/24
 * 时间: 10:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System .Data .OleDb ;
using System .Data;

namespace xiaoshouxinxi
{
	/// <summary>
	/// 基本数据库类，包括数据库的打开，读取，执行，关闭，以及填充DATASET.
	/// </summary>
	public  class DataHelper
	{
	//"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataAddress;    
	// @"data source="+chuandi .IPa +";initial catalog=zhanghu;user id=sa;pwd=111111";
	
	//创建数据库连接
	public OleDbConnection  link { get; set; }
	
		   
	public DataHelper()
	{
	  link = new OleDbConnection( "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=yw.dat");
	}

	public DataHelper(string str)
	{
		
      link = new OleDbConnection( "provider= Microsoft.Jet.OLEDB.4.0;extended properties=Excel 8.0;data source="+ str);
		
	}



	//1.打开数据库
	   public void open(){
            if (link.State==0)
    	    link.Open();
    		}
	  
        //2.读取数据库
       public OleDbDataReader dataread(string selectstring ) {
    	OleDbCommand  mycommand=link .CreateCommand ();
        mycommand.CommandText =selectstring ;
        OleDbDataReader myReader=mycommand.ExecuteReader ();
        return myReader;
      }
    
     
        
        
        
        
        //3.执行数据库命令
        public void dataexecute(string exestr){
          OleDbCommand  mycommand=link.CreateCommand();
          mycommand.CommandText =exestr;
          mycommand.ExecuteNonQuery ();
       }
        
        
        
        
        
        //4.关闭数据库
        public void close(){
    	   if (link.State!=0)
    	   link.Close ();
           link =null ;
        }

       //5.填充DATAset
        public  void FullDataSet(string sqlstr,DataSet mydataset,string TableName){
    	OleDbDataAdapter  myDataAdapter=new OleDbDataAdapter  (sqlstr ,link);
    	myDataAdapter.Fill (mydataset ,TableName );
        }
  
       public  DataSet  DATASETFillDataSet(string sqlstr,DataSet mydataset,string TableName){
       	OleDbDataAdapter  myDataAdapter=new OleDbDataAdapter  (sqlstr ,link);
    	myDataAdapter.Fill (mydataset ,TableName );
    	return mydataset ;
       }
       
        public OleDbDataAdapter ADAPTERFillDataSet(string sqlstr,DataSet mydataset,string TableName){
       	OleDbDataAdapter  myDataAdapter=new OleDbDataAdapter  (sqlstr ,link);
    	myDataAdapter.Fill (mydataset ,TableName );
    	return myDataAdapter  ;
       }
       
       
	
	
	}
	
	/// <summary>
	/// 主要是数据库的执行
	/// </summary>
	static class  DataExec
     {
	static public int DE(string str){
		DataHelper helper1=new DataHelper ();
	   try {
			helper1 .open();
			helper1 .dataexecute(str);
			return 1 ;
			}
			catch{
			return 2;
		      }
			finally {
			helper1.close ();
			}
      	}  
    

	}
	
	
	
	
	
}
