/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/20
 * 时间: 9:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System ;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using System .Data .OleDb ;
using System .Data .SqlClient ;
using System .Data ;
using System .Collections .Generic ;


class KeHu
{
public string  Name { get; set; }
public string  SuoXie { get; set; }

public string Buy(string shangPin , int shuoliang, double danJia, double jinE, DateTime date)
{
	string str= string.Format ("insert into xiaoshou values('{0}','{1}',{2},{3},{4},'{5}'",this.Name ,shangPin ,shuoliang, jinE ,date);
	return str;
}
}

class ShangPin
{
public string  Name { get; set; }
}

class XiaoShou
{
public KeHu KeHu { get; set; }
public ShangPin  ShangPin { get; set; }
public int ShuoLiang { get; set; }
public double DanJia {get;set;}
public double Price { get; set; }
}


public static class chuandi
{
   static public string  StrBack { get; set; }
   static public bool ifName { get; set; }   
   static public bool FormShuo {get ; set ;}
   static public List<string > Lsr = new List<string >();
   static public DataSet GxDS = new DataSet ();
   static public bool FormShuo1 {get ; set;}
   static public OleDbDataAdapter adp {get;set;}
   static public string norb;
   
   

}


static class  CExcel
{	
	
	private static int[] ColsWidth1 = {6*256, 56*256, 8*256, 14*256, 16*256, 15*256, 20*256, 15*256 };
	
	private static int[] ColsWidth2 = {6*256, 15*256, 56*256, 8*256, 14*256, 16*256, 15*256, 20*256, 15*256 };
	/// <summary>
	/// 分客户名单列宽
	/// </summary>
    public static int[] Colwidth1 { get{return ColsWidth1;} }

    public static  int[] Colwidth2 { get{return ColsWidth2;} }
    
    
    #region 分客户标题及表头
    /// <summary>
    /// 分客户标题及表头
    /// </summary>
    /// <param name="workbook">工作簿</param>
    /// <param name="sheet">工作表</param>
    /// <param name="cNopi">NOPi对象</param>
    /// <param name="st">客户名称</param>
    public static void NameHeader(HSSFWorkbook workbook, ISheet sheet, CNopi cNopi,string st,ICellStyle headStyle)
    {
                cNopi .Cols (sheet,Colwidth1 );
	       	    ICell CellTitle = cNopi .CreateTitleCell(sheet,0,0,41*20,"永成通信销售单",0,0,0,7);
                CellTitle .CellStyle = cNopi .TitleCellStyle(workbook );
               
                ICell CellSubTitle = cNopi .CreateTitleCell (sheet ,1,0,23*20,"客户姓名："+st,0,0,0,7);
                CellSubTitle .CellStyle =cNopi .SubTitleCellStyle (workbook );

                string[] strarr={"序号","内容","数量","单价","金额","是否付款","日期","备注"};
                IRow Hearder =cNopi .CreateHeaders (sheet,2,0,23*20,strarr);
                cNopi .AddCellStyle (Hearder,headStyle );
       
    }
    #endregion 
    #region 分名单表尾
    /// <summary>
    /// 分名单表尾
    /// </summary>
    /// <param name="n">此时的表索引，一般是当前加一</param>
    /// <param name="cNopi">Nopi对象</param>
    /// <param name="sheet">工作表</param>
    /// <param name="v">数量</param>
    /// <param name="x">记账金额</param>
    /// <param name="y">已付款</param>
    /// <param name="z">总金额</param>
    /// <param name="style">行尾适用样式</param>
    public static void Nametail(int n , CNopi cNopi,ISheet sheet, string v,string x,string y,string  z,ICellStyle style)
    {
    	
    	string[] stra = {"","合计",v,"",z,"","",""};
        IRow row7= cNopi .CreateHeaders (sheet,n,0,21*20,stra);
        cNopi .AddCellStyle (row7,style );
        
        n++;
        string[] stra1 = {"","其中:记  账","","",x,"","",""};
        IRow row8= cNopi .CreateHeaders (sheet,n,0,21*20,stra1);
        cNopi .AddCellStyle (row8,style );
          	    
        n++;
        string[] stra2 ={"","      已付款","","",y,"","",""    };
  	    IRow row9= cNopi .CreateHeaders (sheet,n,0,21*20,stra2);
        cNopi .AddCellStyle (row9,style );
    }
    #endregion
    
    #region 
    public static void NameHeader(HSSFWorkbook workbook, ISheet sheet, CNopi cNopi,ICellStyle headStyle)
    {
    
       cNopi .Cols (sheet,Colwidth2 );
	   ICell CellTitle = cNopi .CreateTitleCell(sheet,0,0,41*20,"永成通信销售单",0,0,0,8);
       CellTitle .CellStyle = cNopi .TitleCellStyle(workbook );
       
       string[] strarr={"序号","姓名","内容","数量","单价","金额","是否付款","日期","备注"};
       IRow Hearder =cNopi .CreateHeaders (sheet, 1,0,23*20,strarr);
       cNopi .AddCellStyle (Hearder,headStyle );
    
    }
    #endregion
    #region 
     public static void Nametail(int n , CNopi cNopi,ISheet sheet, string Jizhang,string Yifukuan,ICellStyle style)
    {
    	
    	string[] stra1 = {"","","其中:记  账","","",Jizhang ,"","",""};
        IRow row8= cNopi .CreateHeaders (sheet,n,0,21*20,stra1);
        cNopi .AddCellStyle (row8,style );
          	    
        n++;
        string[] stra2 ={"","","      已付款","","",Yifukuan ,"","",""    };
  	    IRow row9= cNopi .CreateHeaders (sheet,n,0,21*20,stra2);
        cNopi .AddCellStyle (row9,style );
    }
    #endregion
    
  
    
   
    
    
    
    
    
    
}

