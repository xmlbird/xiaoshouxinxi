/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/27
 * 时间: 11:15
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using System .IO ;


	/// <summary>
    // Description of CNopi.
	/// </summary>
	public class CNopi
	{
		
		#region  生成标题单元格
		/// <summary>
		/// 生成标题单元格
		/// </summary>
		/// <param name="sheet">所在工作表</param>
		/// <param name="r">建立的行索引</param>
		/// <param name="col">建立的列索引</param>
		/// <param name="RowH">行高，41*20格式</param>
		/// <param name="Title">标题单元格内容</param>
		/// <param name="a">合并起始行</param>
		/// <param name="b">合并终止行</param>
		/// <param name="c">合并起始列</param>
		/// <param name="d">合并终止列</param>
		/// <returns>返回标题单元格</returns>
		public ICell  CreateTitleCell(ISheet sheet ,int r, int col ,short RowH, string Title, int a, int b,int c,int d)
		{
		  IRow row = sheet.CreateRow(r);  // 生成标题行
          ICell cell=row.CreateCell(col);	 //生成标题单元格
          row.Height =RowH;               //设置标题单元格行高  41*20
          cell.SetCellValue(Title );  //设置标题单元格内容
          sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //0,0,0,7
          return cell;
		 }
		
        #endregion


        #region 确定列数及列宽
        /// <summary>
        /// 确定列数及列宽
        /// </summary>
        /// <param name="sheet">所在工作表</param>
        /// <param name="n">列宽数组</param>
        public void Cols(ISheet sheet,int [] n)
        {
            for (int i = 0; i < n.Length ; i++) {
        		sheet.SetColumnWidth(i,  (int)(n[i]));
            }    
        }
        	
        #endregion
        
        
        #region 建立并返回表头
        /// <summary>
        /// 建立并返回表头
        /// </summary>
        /// <param name="sheet">所在工作表</param>
        /// <param name="r">所在行索引</param>
        /// <param name="s_col">起始列索引</param>
        /// <param name="RowH">行高</param>
        /// <param name="Hearders">列标题字符串数组</param>
        /// <returns>返回表头行</returns>
        public IRow CreateHeaders(ISheet sheet ,int r, int s_col,short RowH, string[] Hearders)
        {
          IRow row = sheet.CreateRow(r);  // 生成标题行
          row.Height =RowH;
          for (int i = s_col; i < s_col + Hearders.Length ; i++) {
          ICell cell=row.CreateCell(i);	
          cell.SetCellValue(Hearders[i]);  //设置标题单元格内容
          }
          return row;
        }
        #endregion
        
        
		
	    #region   建立并返回标题单元格样式
	         
	    /// <summary>
	    ///  建立并返回标题单元格样式
	    /// </summary>
	    /// <returns>标题单元格样式</returns>
	    public ICellStyle TitleCellStyle(IWorkbook workbook)
	    {
	       ICellStyle style=workbook.CreateCellStyle ();
           style.VerticalAlignment =VerticalAlignment .CENTER ;
           style.Alignment = NPOI.SS.UserModel.HorizontalAlignment .CENTER ;
           IFont font= workbook .CreateFont();
           font.FontName ="宋体";
           font.Boldweight =short.MaxValue ;
           font.FontHeightInPoints =16;
           style.SetFont (font);
           return style;
	    }
	    #endregion
 
        #region   建立并返回副标题单元格样式 
       /// <summary>
       /// 建立并返回副标题单元格样式
       /// </summary>
       /// <returns>返回单元格样式</returns>
       public ICellStyle SubTitleCellStyle(IWorkbook workbook)
       {
           ICellStyle style3=workbook.CreateCellStyle();
           style3.VerticalAlignment =VerticalAlignment.CENTER ;
           style3.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT ;
           IFont font3=workbook .CreateFont ();
           font3.FontHeightInPoints =13;
           font3.FontName ="黑体";
           style3 .SetFont (font3);
           return style3;
       }

       #endregion
       
	    #region  建立并返回普通单元格样式
	    /// <summary>
	    /// 建立并返回普通单元格样式
	    /// </summary>
	    /// <returns>普通单元格样式</returns>
	    public ICellStyle NormalCellStyle(IWorkbook workbook)
	    {
	       ICellStyle style1=workbook.CreateCellStyle();
           style1.VerticalAlignment =VerticalAlignment .CENTER ;
           style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment .CENTER ;
           IFont font1=workbook .CreateFont ();
           //font1.Boldweight =short.MaxValue;
           font1.FontHeightInPoints =12;
           font1.FontName ="宋体";
           style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
           style1.BorderLeft =NPOI.SS.UserModel.BorderStyle.THIN;
           style1.BorderRight =NPOI.SS.UserModel.BorderStyle.THIN;
           style1.BorderTop =NPOI.SS.UserModel.BorderStyle.THIN;
           style1 .SetFont (font1);
           return style1;
	    }
	    #endregion
	    
	    #region 建立并返回表头单元格样式
        	    
	    public ICellStyle HeadCellStyle(IWorkbook workbook)
	    {
	       ICellStyle style1=workbook.CreateCellStyle();
           style1.VerticalAlignment =VerticalAlignment .CENTER ;
           style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment .CENTER ;
           IFont font1=workbook .CreateFont ();
           font1.Boldweight = short .MaxValue;
           font1.FontHeightInPoints =12;
           font1.FontName ="宋体";
           style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
           style1.BorderLeft =NPOI.SS.UserModel.BorderStyle.THIN;
           style1.BorderRight =NPOI.SS.UserModel.BorderStyle.THIN;
           style1.BorderTop =NPOI.SS.UserModel.BorderStyle.THIN;
           style1 .SetFont (font1);
           return style1;
	    }
	    #endregion
	    
	    #region 为一行的各列添加样式
	    /// <summary>
	    /// 为一行的各列添加样式
	    /// </summary>
	    /// <param name="row1">行</param>
	    /// <param name="style">样式</param>
	    public void AddCellStyle(IRow row1, ICellStyle style)
	    {
	       foreach (ICell e1 in row1) {
            e1.CellStyle =style ;
             }
	    }
	    
	    #endregion
	    
	    #region 写入和保存工作簿
	    /// <summary>
	    /// 写入和保存工作簿
	    /// </summary>
	    /// <param name="workbook">工作簿</param>
	    /// <param name="str">保存路径和文件名</param>
	    public void WriteAndSave(IWorkbook workbook,string str)
	    {
	      FileStream fs = File.OpenWrite(str);
          workbook .Write(fs);
		  fs.Close ();
	    }
	    
	    #endregion
	    
	    
	    
	    
	    
	    
	    
	    
	    
		
	}

