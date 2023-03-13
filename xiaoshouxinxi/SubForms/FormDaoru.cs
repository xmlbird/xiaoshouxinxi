/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/22
 * 时间: 18:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System .Data .OleDb ;
using System .IO ;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Util;
using NPOI.SS.UserModel;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class FormDaoru : Form
	{
		public FormDaoru()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
			     
	    
	    #region 点击导入键，选择并返回文件路径
		void Button1Click(object sender, EventArgs e)
		{
	             OpenFileDialog fileDialog = new OpenFileDialog();
	             fileDialog.Multiselect = false; 
	             fileDialog.Title = "请选择文件"; 
	             fileDialog.Filter="Excel工作簿(97-2003)|*.xls|Excel工作簿(2007以上）|*.xlsx";
	             fileDialog.InitialDirectory = @"C:\";
	              
	             if (fileDialog .ShowDialog () == DialogResult.OK )
	                 {
	             	
	             	label1 .Text =fileDialog .FileName ;
	             		
	             }
	             if (AboutFile.isFileLocked (label1 .Text .Trim ()))
	             {
	             	MessageBox .Show ("请先关闭该文件");
	             	label1 .Text ="";
	             	return ;
	             }
		
		}
		#endregion 
		
		# region 点击生成
		void Button2Click(object sender, EventArgs e)
		{
			 
			#region  判断文件路径
			if (label1 .Text .Trim () == "")
			{
				MessageBox .Show ("请先选择文件");
				return ;
			
			}
			
			#endregion 
			
			
			#region  选择生成的文件夹,并判断是否为空
			
			string str1 = "";
			FolderBrowserDialog folder = new FolderBrowserDialog ();
			folder .Description ="选择要保存的文件夹";
			if (folder .ShowDialog() == DialogResult.OK)
			{
				str1 =folder.SelectedPath ;
			}
			
			//判断是否为空
			if (!AboutFile .isEmptyFolder (str1))
			{
				MessageBox .Show ("文件夹不为空，请选择一个空文件夹");
				return;
			}
						
			#endregion 
			
			#region  两重循环，一是客户名称循环，得到不同工作簿，二是该客户的记录循环，得到各个记录
			//最后生成一个个的工作簿
						
			
			//得到去重的客户表
			DataHelper helper =new DataHelper (label1 .Text.Trim () );
	        helper.open ();
	        string str2 = "select distinct name from [Sheet1$]";
	        OleDbDataReader reader = helper .dataread (str2);
	       
	        
	       int i1 = 0; decimal zhj = 0; int k = 0; // i1，客户数量 ，zhj, 总合计金额 ， k，记录总数
	       
	       //外层循环--客户名称
	       
	       while(reader .Read ())
	       {  
	       	     //如果客户名为空则跳至下一个
	       	    if (reader[0].ToString() =="")
	       	      {
	       		    continue  ;
	       	      }
	       	
	           	i1 ++;   //客户数量自增 
	       	
	       	    #region    生成工作簿，并绘制表头
	       	    HSSFWorkbook workbook =new HSSFWorkbook();  //生成工作簿
	       	    ISheet sheet = workbook.CreateSheet(reader[0].ToString ().Trim () ); //生成工作表
	      	     CNopi cNopi = new CNopi ();
	      	     ICellStyle NormalStyle = cNopi .NormalCellStyle (workbook );
                ICellStyle HeaderStyle =cNopi .HeadCellStyle (workbook );
	       	    //绘制工作表的列数，并确定列宽
	      	    CExcel .NameHeader (workbook ,sheet ,cNopi ,reader [0].ToString (),HeaderStyle );
               
                #endregion
	           	
	       	    
	       	    //读取每个人的记录
	       	    
	       	    DataHelper helper1 = new DataHelper(label1 .Text .Trim());
	       	
	            helper1.open ();
	       	
	          	string str3 ="select * from [sheet1$] where name = '"+ reader[0].ToString()+"' order by date ";
	       
	          	OleDbDataReader reader1= helper1.dataread (str3);
	        
               int n=0; int sl = 0; decimal hj=0; decimal jizhang=0; decimal yifukuan= 0;
               //n:行索引基准，也是该客户记录数
               //sl:数量，hj:金额合计, jizhang : 记账金额合计，yifukuan:已付款金额合计
               
               //内层循环--记录循环
               
               while(reader1.Read ()){
           	        
               	    int a1 = 0; decimal  a2 = 0; decimal  a3 = 0;
                 	// a1 : 本记录的数量 a2:本记录的记账金额 a3:本记录的已付款金额 
               	    if (reader1[2].ToString ().Trim ()=="")  //如果为空则转化为0
           	          {a1=0;}
           	        else
           	          {a1=Convert.ToInt32(reader1[2].ToString ().Trim ());}
           	
           	       if (reader1[4].ToString ().Trim ()=="")
           	          {a2=0;a3=0;}
           	       else 
           	       {
           	          if(reader1 [5].ToString ().Trim ()=="记账")
           	             { a2=Convert.ToDecimal(reader1[4].ToString ().Trim ());}
           	          else
                         {a3=Convert.ToDecimal (reader1[4].ToString ().Trim ());}
           	        }
           	    
           	    //累加   
               	sl += a1;
           	    jizhang += a2;
           	    yifukuan += a3;
           	    zhj += Convert.ToDecimal (reader1[4]); //总金额在每一个记录里累加
               	
           	   //把值放入数组 
           	    string[] strarray=new string[8];
                strarray[0]=(n+1).ToString ().Trim ();
                strarray [1]=reader1[1].ToString ().Trim ();
                strarray [2]=reader1[2].ToString ().Trim ();
                strarray [3]=string.Format ("{0:#0.00}",reader1[3]);
                strarray [4]=string.Format ("{0:#0.00}",reader1[4]);
                strarray [5]=reader1[5].ToString ().Trim ();
                //string[] c=reader1[6].ToString ().Split (' ');
                strarray [6]=String.Format("{0:yyyy-MM-dd}",reader1[6]);;
                strarray [7]=reader1[7].ToString ().Trim ();
           	
                IRow row1 =cNopi .CreateHeaders(sheet,n+3,0,21*20,strarray);
                cNopi .AddCellStyle (row1,NormalStyle  );
                n++;
               
               }  //内层循环结束
                 
                 k += n; //记录总数累加 一次记录循环得到一个客户的记录数
                 
                 hj= jizhang + yifukuan ;   //一个客户的合计等于记账的加上已付款的
                
                 string x; string y; string z;string v;
                 if (jizhang  != 0)
                   {x= string.Format ("{0:#0.00}",jizhang);}
           	     else
           	       {x = "";}
                 
                if (yifukuan != 0)
           	      {y = string.Format ("{0:#0.00}",yifukuan);}
           	    else
           	      {y = "";}
           	     
               
           	    z = string.Format ("{0:#0.00}",hj);
           	    
           	    v = sl.ToString ();
           	    //添加表尾部分
           	    CExcel .Nametail (n,cNopi ,sheet,v,x,y,z,HeaderStyle );
           	    
           	    
           	    FileStream fs = File.OpenWrite(str1+ "\\" + reader[0].ToString ().Trim () + ".xls");
		             workbook .Write(fs);
		                fs.Close ();
           
		                helper1.close ();

           }
	       
	       helper .close ();
	       #endregion 	
	       
	       #region  生成总结文本文件 
	       
	       string str4 = string.Format ("一共{0}条记录，{1}名客户，总金额{2}元。",k,i1,zhj);
		   AboutFile .WriteFiles (str1+"\\1.txt",str4);
	       
		   #endregion
	       

		   MessageBox .Show("已成功生成完毕,文件位于文件夹\n" + str1 + "\\" );
	    }
		
		
		#endregion 
		
		
		
	}
	
	
	
}
	

