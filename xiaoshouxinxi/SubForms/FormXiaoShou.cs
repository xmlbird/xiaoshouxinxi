/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/21
 * 时间: 17:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
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
		DataSet DsKehu;
		Control[] controlsa ;
		string Kehu; string Shangpin ;int Shuoliang ; decimal  Danjia ; decimal  Jine ;
		string Jiesuan ; string Time1  ; string Beizhu; bool b ; string Flag ; string Id;
		List <Control> ctrls = new List<Control> ();
		
		// 构造函数
		public FormXiaoShou()
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			controlsa = new Control[] {TxtSuoXie,CmbName ,TxtNeiRong ,TxtBianHao,TxtShuoLiang ,TxtDanJia ,CmbJieSuan ,dateTimePicker1,TxtBeiZhu ,TxtBH,TxtHour ,TxtMIn  };
			ctrls .AddRange (controlsa );
			ctrls.Remove (dateTimePicker1 );
			ctrls.Add (button1);
			CControls cc = new CControls (ctrls);
			foreach (Control  el in ctrls) {
				el.KeyDown += new System .Windows .Forms .KeyEventHandler (cc.KeyPorD);
			}
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			TxtBH.KeyPress += TxtBHKeyPress;
		}
		
		
		
		
		
		
		/// <summary>
		/// 添加客户名单至复选框
		/// </summary>
		void CmbAdd()
		{
			DataHelper Help = new DataHelper ();
			DsKehu .Clear ();
			Help.FullDataSet ("select name, suoxie  from kehu", DsKehu,"kehu");
	     	for (int i = 0; i < DsKehu .Tables ["kehu"].Rows .Count ; i++) {
				CmbName.Items .Add (DsKehu .Tables ["kehu"].Rows[i][0].ToString().Trim ());
			  }
			
		}
		
		/// <summary>
		/// 为各个字段变量赋值
		/// </summary>
		void Fuzhi(){
			 Id = "";
		     Kehu = CmbName .Text.Trim ();  
	         Shangpin = TxtNeiRong .Text.Trim () ;
	         Shuoliang = Convert .ToInt32 (TxtShuoLiang .Text.Trim ()) ;
	         Danjia = Convert .ToDecimal (TxtDanJia .Text .Trim ());
	         Jine = Shuoliang * Danjia;
	         Jiesuan = CmbJieSuan .Text.Trim ();
			int Hour = 0; int Min = 0;  //小时和分钟
			//确定小时
			if (TxtHour.Text.Trim() == "")
			{
				Hour = 0;
			}
			else
			{
				Hour = int.Parse(TxtHour.Text.Trim());
			}
			//确定分钟
            if (TxtMIn .Text.Trim() == "")
            {
                Min = 0;
            }
            else
            {
                Min  = int.Parse(TxtMIn.Text.Trim());
            }

			 Time1 = string.Format("{0:yyyy-MM-dd} {1:00}:{2:00}", dateTimePicker1.Value, Hour ,Min );
	         
			 Beizhu = TxtBeiZhu .Text .Trim ();
	         b = ChbBiaoji .Checked; 
	         Flag = DateTime.Now.ToString("yyyyMMddHHmmss");
		}
		
		/// <summary>
		/// 把字段变量的值加入单元格
		/// </summary>
		/// <param name="Rown">增加的行号</param>
		/// <param name="n"></param>
		/// <returns></returns>
		private int FuziGridView(int Rown)
		{
	      DGV.Rows[Rown].Cells[0].Value =Id ;
	      DGV.Rows[Rown].Cells[2].Value =Kehu ;
	      DGV.Rows[Rown].Cells[3].Value =Shangpin ;
	      DGV.Rows[Rown].Cells[4].Value =Convert.ToInt32(Shuoliang );
	      DGV.Rows[Rown].Cells[5].Value =Convert.ToDecimal (string.Format ("{0:#0.00}",Danjia ));
	      DGV.Rows[Rown].Cells[6].Value =Convert.ToDecimal(string.Format ("{0:#0.00}",Jine ) );
          DGV.Rows[Rown].Cells[7].Value =Jiesuan ;
			if (Convert.ToDateTime(Time1).ToString("HH:mm") == "00:00")
			{ DGV.Rows[Rown].Cells[8].Value = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(Time1)); }
			else
			{
              DGV.Rows[Rown].Cells[8].Value = string.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Time1));
            }
          
		  DGV.Rows[Rown].Cells[9].Value=Beizhu ;
          DGV.Rows[Rown].Cells[10].Value =b;
          DGV.Rows[Rown].Cells[11].Value =Flag ;
          return Rown;
		}
		
		/// <summary>
		/// 添加行样式
		/// </summary>
		/// <param name="n">该行索引</param>
		private void StyleCell(int n)
		{
		
		    CDataGridView cdg = new CDataGridView ();
		    DataGridViewCellStyle ds = cdg.DsNormal ();
            DataGridViewCellStyle ds1 = cdg.DsRed ();
			DataGridViewCellStyle ds2 = cdg.DsLeft();
			DataGridViewCellStyle ds3 = cdg.DsRedLeft();

			int R = 255; int G = 240; int B = 245;

			if (n % 2 !=0 )
			{
				ds.BackColor = System.Drawing.Color.FromArgb(R,G,B);
                ds1.BackColor = System.Drawing.Color.FromArgb(R, G, B);
                ds2.BackColor = System.Drawing.Color.FromArgb(R, G, B);
                ds3.BackColor = System.Drawing.Color.FromArgb(R, G, B);
            }


            if (Convert .ToBoolean (DGV.Rows[n].Cells[10].Value) == false){
              
          	for (int i = 1; i < 11; i++) {
					if (i == 8) DGV.Rows[n].Cells[i].Style = ds2;
				    if (i != 8) DGV.Rows[n].Cells[i].Style =ds;
					
          	}
          }
          else
          {
          	for (int i = 1; i < 11; i++) {
                    if (i == 8) DGV.Rows[n].Cells[i].Style = ds3;
                    if (i != 8) DGV.Rows[n].Cells[i].Style = ds1;
                }
          }
		
		}
		
		
		
		void FormXiaoShouLoad(object sender, EventArgs e)
		{
			int width = DGV.Width;
			DGV.Columns[0].Width = 0;
			DGV.Columns[1].Width = Convert.ToInt32(width * 0.05);
			DGV.Columns[2].Width = Convert.ToInt32( width * 0.12);
            DGV.Columns[3].Width = Convert.ToInt32(width * 0.25);
            DGV.Columns[4].Width = Convert.ToInt32(width * 0.08);
            DGV.Columns[5].Width = Convert.ToInt32(width * 0.08);
            DGV.Columns[6].Width = Convert.ToInt32(width * 0.09);
            DGV.Columns[7].Width = Convert.ToInt32(width * 0.09);
            DGV.Columns[8].Width = Convert.ToInt32(width * 0.13);
			DGV.Columns[9].Width = Convert.ToInt32(width * 0.11);
            DGV.Columns[10].Width = 0;
            DGV.Columns[11].Width = 0;


            DeleteRe ("neirong");
			DeleteRe ("beizhu");		
			InitButton ();
			DsKehu = new DataSet ();
			CmbAdd();
			InitButton();
			DataExec.DE  ("update xiaoshou set flag = null "); //清除flag列数据
			FullDs();
			label10.Text = dateTimePicker1.Value.ToString("yyyy年MM月dd日");

        }
		
		
		/// <summary>
		/// 缩写框变化，下拉菜单也变化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TxtSuoXieTextChanged(object sender, EventArgs e)
		{
			DataView  DvKehu = DsKehu.Tables["kehu"].DefaultView ;
			DvKehu .RowFilter = " suoxie = '"+ TxtSuoXie .Text .Trim ().ToUpper () +"'";
			if (DvKehu.Count > 0){
				CmbName .Items .Clear();
			foreach (DataRowView DrKehu in DvKehu )
			{
				CmbName .Items .Add (DrKehu .Row [0]);
				CmbName .Text = CmbName .Items[0].ToString ();
			}
			}
			else{
				CmbName .Items .Clear();
				
				CmbAdd();
			}
			
		}
		
        

		/// <summary>
	    /// 录入时的数量验证
	    /// </summary>
	    /// <returns>返回是否通过</returns>
		private bool validate()
		{
		for (int i = 0; i < controlsa.Length -1; i++) {
				if (i >0 && i < 7 && i != 3){
					if(myvalidate .ifblank(controlsa[i].Text.Trim ()))
					{
						MessageBox .Show ("必填项不能为空");
						return false;
					}
				}
				
				if (i == 4)
				{
					if(! myvalidate.isAllNumric (controlsa[i].Text.Trim ()) || Convert.ToInt32(controlsa [i].Text .Trim()) == 0)
					   {
       					MessageBox .Show ("请正确填写数量");
   						return false ;
   					   }
				
				}
				
				
				
				
				if (i == 5)
				{
					if(!myvalidate.iffshuozi(controlsa [i].Text .Trim ()))
					{
						MessageBox .Show ("单价请正确填写");
						return false ;
					}
				}


				if (i == 10)
				{
					if (controlsa[i].Text.Trim ()!= "")
					{
						if ( ! myvalidate.isAllNumric (controlsa[i].Text .Trim ()) || Convert.ToInt32(controlsa[i].Text.Trim()) < 0 || Convert.ToInt32(controlsa[i].Text.Trim()) > 23 )
                        {
                            MessageBox.Show("小时请正确填写");
							return false;

                        }

					}
				}


                if (i == 11)
                {
                    if (controlsa[i].Text.Trim()  != "")
                    {
                        if (!myvalidate.isAllNumric(controlsa[i].Text.Trim()) || Convert.ToInt32(controlsa[i].Text.Trim()) < 0 || Convert.ToInt32(controlsa[i].Text.Trim()) > 59)
                        {
                            MessageBox.Show("分钟请正确填写");
							return false;

                        }

                    }
                }

            }
			
			
			return true;


		
		}
		
		
		
	    /// <summary>
	    /// 点击添加按键
	    /// </summary>
	    /// <param name="sender"></param>
	    /// <param name="e"></param>
		void Button1Click(object sender, EventArgs e)
		{
			//数据是否通过检验
			if (!validate()) {
				
				return;
	        } 
			Fuzhi ();  //为字段赋值
		     
			string str1 = "select * from kehu where name = '"+CmbName .Text .Trim ()+"'";
			DataHelper h = new DataHelper();
			h.open ();
			OleDbDataReader r = h.dataread (str1);
			if (r.HasRows == false )
			{
				str1 = "insert into kehu (name,suoxie) values ('"+CmbName.Text .Trim ()+"','"+GetFirstLetter.GetSpellCode  (CmbName .Text .Trim ())+"')";
				h.dataexecute (str1);
			}

			h.close ();


    		//填入数据库
	      string str = string.Format ("insert into xiaoshou (kehu, shangpin, shuoliang, danjia, jine, jiesuan,time1,beizhu,biaoji,flag) values ('{0}','{1}',{2},{3},{4},'{5}','{6}','{7}', {8}, '{9}')",Kehu,Shangpin ,Shuoliang ,Danjia ,Jine ,Jiesuan,Time1,Beizhu,b,Flag);
	     
	      if(DataExec .DE (str) == 2)
	      {   
	    	MessageBox .Show("错误");
	    	return ;
	       }
	      
	      if (DGV .Rows .Count >0 ) DelHeji ();
	      //填入单元格，并确定样式   
	      
			StyleCell (FuziGridView(DGV.Rows .Add()));
	     
	     
	      //合计，并填写序号
	      HeJiAndXuHao();
			DingWie();
	      
	      //把内容和备注 放入 DataTablet以及更新数据库
	      
	       int bianhao = 0;

            #region  //判断编号是不是-1

            //判断编号是不是-1
            if (! chuandi .FormShuo ){
	      	bianhao = -1;
	      }
	      else{
	      	bianhao = CreateBianHao (formnerong.textBox1 .Text .Trim ());
	      }
	      
	      if ( AddOrNot (chuandi .GxDS .Tables ["neirong"], "neirong",TxtNeiRong .Text .Trim (), bianhao )){
	      
          DataOffLink Dof = new DataOffLink ();
           
          Dof.AddTable (chuandi .GxDS .Tables ["neirong"],"neirong",bianhao ,TxtNeiRong.Text  );
	      
          ShowTable (chuandi.GxDS .Tables ["neirong"].Select ("bianhao <> -1"),"neirong" );
	      
          if (chuandi.FormShuo ) ShowOther (formnerong.InitShow );
	      }
		
	      #endregion
	     
          #region 

          if (TxtBeiZhu .Text .Trim() != ""){
          
          if (! chuandi .FormShuo1 ){
	      	bianhao = -1;
          }
          else{
          bianhao = CreateBianHao (formbeizhu.textBox1 .Text .Trim ());
          }
          
          if ( AddOrNot (chuandi .GxDS .Tables ["beizhu"], "beizhu",TxtBeiZhu  .Text .Trim (), bianhao )){
	      
          DataOffLink Dof = new DataOffLink ();
           
          Dof.AddTable (chuandi .GxDS .Tables ["beizhu"],"beizhu",bianhao ,TxtBeiZhu.Text  );
	      
          ShowTable (chuandi.GxDS .Tables ["beizhu"].Select ("bianhao <> -1"),"beizhu" );
	      
          if (chuandi.FormShuo1 ) ShowOther (formbeizhu.InitShow );
          }
          
          }
          
          #endregion

	      TxtSuoXie .Focus ();
	      TxtSuoXie .SelectAll ();
	      TxtNeiRong .Text ="";
	      TxtDanJia .Text ="";
	      TxtBeiZhu .Text ="";
	      TxtBianHao .Text ="";
	      TxtBH .Text ="";
		  TxtSuoXie.Text = "";
			TxtShuoLiang.Text = "1";
	      ChbBiaoji .Checked = false ;
		  if (chuandi.FormShuo) formnerong.textBox1.Text = "";
          if (chuandi.FormShuo1) formbeizhu .textBox1.Text = "";

        }


		



		public void DingWie()
		{
              if (DGV.Rows .Count > 1)
			{
				//DGV.Rows[DGV.Rows.Count - 1].Selected = true;
				DGV.CurrentCell = DGV.Rows[DGV.Rows.Count - 1].Cells[1];  
			}


		}
		
		/// <summary>
		/// 点击查询按键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnChaXunClick(object sender, EventArgs e)
		{			
			Form formChaXun = new FormChaXun ();
			
			formChaXun.ShowDialog ();
			
			if (chuandi .StrBack =="") return ;
            
			DataHelper dh = new DataHelper ();
			
			
			dh.open ();
			
			DGV.Rows .Clear ();
			
			OleDbDataReader reader1 = dh.dataread (chuandi .StrBack );
			 
			if (reader1 .HasRows == true )
			{   
				DGV .Rows .Clear();
				
				while (reader1 .Read ())
				{   int n = DGV.Rows .Add ();
					DGV.Rows[n].Cells[0].Value =reader1["id"].ToString ();
					DGV.Rows[n].Cells[2].Value =reader1["kehu"].ToString ();
					DGV.Rows[n].Cells[3].Value =reader1["shangpin"].ToString ();
					DGV.Rows[n].Cells[4].Value =Convert.ToInt32(reader1["shuoliang"].ToString ());
					DGV.Rows[n].Cells[5].Value =Convert.ToDecimal(string.Format ("{0:#0.00}",reader1["danjia"]));
					DGV.Rows[n].Cells[6].Value =Convert.ToDecimal(string.Format ("{0:#0.00}",reader1["jine"]));
					DGV.Rows[n].Cells[7].Value =reader1["jiesuan"].ToString ();
					if (Convert.ToDateTime(reader1["time1"]).ToString("HH:mm") == "00:00")
					{ 
					DGV.Rows[n].Cells[8].Value = string.Format("{0:yyyy-MM-dd}", reader1["time1"]);
                    }
					else
					{ 
					DGV.Rows[n].Cells[8].Value = string.Format("{0:yyyy-MM-dd HH:mm}", reader1["time1"]); 
					} 
					DGV.Rows[n].Cells[9].Value =reader1["beizhu"].ToString ();
					DGV.Rows[n].Cells[10].Value =reader1["biaoji"].ToString ();
					DGV.Rows[n].Cells[11].Value =reader1["flag"].ToString ();
				
					StyleCell(n);
				
				}
		 	
			}
			
			dh.close ();
		    
			HeJiAndXuHao();
			DingWie();
		
		}
		


		public void Dgv_delete(Object sender, KeyEventArgs e)
		{
			
			if (e.KeyValue == 46)
			{
				BtnDeleteClick(sender, e);		
			}

		}

        /// <summary>
        /// 点击删除按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnDeleteClick(object sender, EventArgs e)
		{
			if (DGV.SelectedRows .Count ==0) {
				MessageBox .Show ("请先选择一条记录");
				return ;
			}
			if(DGV.CurrentRow.Cells[3].Value.ToString()=="合计")
			{
				
				return ;
			}
			
			if (!Ask .YesOrNot ("是否要删除该记录"))
			{
				return ;
			}
			
			string  str = "";
			if (DGV.SelectedRows[0].Cells[0].Value.ToString().Trim()=="")
			{
				str = string.Format ("delete from xiaoshou where flag='{0}'",DGV .SelectedRows[0].Cells[11].Value .ToString ().Trim ());
				
			}
			else
			{
				str = string.Format ("delete from xiaoshou where id={0}",Convert.ToInt32 (DGV .SelectedRows[0].Cells[0].Value));
			}
			
			    DataExec .DE (str);
			    
				DataGridViewRow  dr = new DataGridViewRow ();
				dr = DGV.SelectedRows[0];
				DGV.Rows .Remove (dr);
				DelHeji ();
				HeJiAndXuHao ();
			    
		}
		
		
		/// <summary>
		/// 点击修改按键后的按键状态
		/// </summary>
		private void XiuGaiButton()
		{
		        button1.Enabled =false;
				BtnDelete .Enabled =false ;
				BtnUpdate .Enabled =false;
				BtnChaXun .Enabled =false ;
				button2 .Enabled =true ;
				button3 .Enabled =true;
				BtnDaochu .Enabled = false  ;
		}
		
		/// <summary>
		/// 初始控件状态
		/// </summary>
		private void InitButton()
		{
		        button1.Enabled =true;
				BtnDelete .Enabled =true ;
				BtnUpdate .Enabled =true;
				BtnChaXun .Enabled =true ;
				button2 .Enabled =false ;
				button3 .Enabled =false;
				TxtNeiRong .Text ="";
				TxtDanJia .Text ="";
				TxtShuoLiang .Text ="1";
				CmbJieSuan.Text = CmbJieSuan .Items[0].ToString();
				TxtBeiZhu .Text ="";
				ChbBiaoji .Checked =false ;
				DGV.ClearSelection ();
				BtnDaochu .Enabled = true ;
		}
		
		/// <summary>
		/// 点击修改按键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnUpdateClick(object sender, EventArgs e)
		{
			if (DGV.SelectedRows .Count ==0) {
				MessageBox .Show ("请先选择一条记录");
				return ;
			}
            if (DGV.CurrentRow.Cells[3].Value.ToString() == "合计")
            {

                return;
            }

            XiuGaiButton();
			
			CmbName .Text =DGV .SelectedRows [0].Cells[2].Value.ToString () ;
			TxtNeiRong .Text =DGV .SelectedRows [0].Cells [3].Value.ToString () ;
			TxtShuoLiang .Text =DGV .SelectedRows [0].Cells [4].Value.ToString () ;
			TxtDanJia  .Text =DGV .SelectedRows [0].Cells [5].Value.ToString () ;
			CmbJieSuan.Text   =DGV .SelectedRows [0].Cells [7].Value.ToString () ;
			TxtBeiZhu .Text =DGV .SelectedRows [0].Cells [9].Value.ToString () ;
			ChbBiaoji .Checked = Convert .ToBoolean (DGV .SelectedRows [0].Cells [10].Value);
			
		}
		
		
		/// <summary>
		/// 确定修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Button2Click(object sender, EventArgs e)
		{
	        //数据验证
			if (!validate()) {
				return;
	        } 
			
			string  str = "";
	        
			Fuzhi ();
			
			if (DGV.SelectedRows[0].Cells[0].Value.ToString().Trim()=="")
			{
               
				str =string .Format ("update xiaoshou set kehu='{0}',shangpin='{1}',shuoliang={2},danjia={3},jine={4},jiesuan='{5}',time1='{6}',beizhu='{7}',biaoji={8},flag='{9}' where flag = '{10}'",Kehu,Shangpin,Shuoliang,Danjia,Jine,Jiesuan,Time1,Beizhu,b,Flag,DGV .SelectedRows[0].Cells[10].Value .ToString ().Trim ());
			
			}
			else
			{
				str =string .Format ("update xiaoshou set kehu='{0}',shangpin='{1}',shuoliang={2},danjia={3},jine={4},jiesuan='{5}',time1='{6}',beizhu='{7}',biaoji={8},flag='{9}' where id = {10}",Kehu,Shangpin,Shuoliang,Danjia,Jine,Jiesuan,Time1,Beizhu,b,Flag,Convert.ToInt32 (DGV .SelectedRows[0].Cells[0].Value));
			}
			DataExec .DE (str);
			
			int n1 = Convert.ToInt32 (DGV.CurrentRow.Cells[1].Value);
			
			StyleCell(FuziGridView (DGV.CurrentRow .Index));
			
			InitButton ();
			DelHeji ();
			HeJiAndXuHao ();
		}
		
		
		
		/// <summary>
		/// 取消修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Button3Click(object sender, EventArgs e)
		{
			InitButton ();
		}
		
		/// <summary>
		/// 点击数据导出按键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnDaochuClick(object sender, EventArgs e)
		{
			if (DGV.Rows .Count == 0)
			{
				MessageBox .Show("没有任何数据可以导出");
				return ;
			}
		
			FormDaochuQuery formDaoChuQuery = new FormDaochuQuery ();
			formDaoChuQuery .ShowDialog ();
			
			//分客户导出
			if (chuandi .ifName ==true){
				
	           //选择文件夹并返回	   
     		    string str1 = AboutFile .SelectFolder();
				
               //判断所选文件夹是否为空
			    if (!AboutFile .isEmptyFolder (str1))
			{
				MessageBox .Show ("文件夹不为空，请选择一个空文件夹");
				return;
			}
			
    		    //得到客户名单
			    HashSet<string> hs = new HashSet<string>();
			    hs = Hs();
			
			
			    int zjl = 0; decimal zhj = 0;
			
			
			#region //对客户名单进行循环---外循环
			   foreach (string KeHuName in hs) {
     		    //建立标题和表头
			       HSSFWorkbook workbook = new HSSFWorkbook ();
			       ISheet sheet = workbook .CreateSheet("sheet1" );
			       CNopi cNopi = new CNopi ();
			       ICellStyle style1 = cNopi .NormalCellStyle(workbook );
			       ICellStyle style2 = cNopi .HeadCellStyle (workbook );
			       CExcel .NameHeader (workbook ,sheet,cNopi ,KeHuName,style2);
			
			       int jiShuQi = 0;  //单个记数器
			
			
			        int RowIndex = 3; //行索引
			        
			        int Sl =0 ; decimal Jizhang = 0; decimal Yifukuan = 0 ; decimal Heji = 0;
			       
			      //对表格进行循环，遇到名称一样的就填入EXCEL---内循环
			       for (int i = 0; i < DGV.Rows.Count ; i++) {
				
			      	  if (DGV.Rows[i].Cells[2].Value .ToString() !=KeHuName) continue ;    //遇到名称一致的
					   //为内容数组赋值
				      string[] str = new string[8];
				      str[0] = (++jiShuQi).ToString ();
					  for (int j = 1; j < 8; j++) {
					  	str[j] = DGV.Rows[i].Cells[j+2].Value.ToString();
					  }
					 
					 //数量累加
					  Sl += Convert.ToInt32 (DGV.Rows[i].Cells[4].Value );
					 
					 //记账和已付款累加
					  if (DGV.Rows [i].Cells[7].Value.ToString () =="记账") {
					   	Jizhang += Convert.ToDecimal  (DGV.Rows[i].Cells[6].Value);
					  }
					  else{
					    Yifukuan  += Convert.ToDecimal  (DGV.Rows[i].Cells[6].Value);
					  }
					 
					  Heji = Jizhang + Yifukuan ;   //合计累加
					 
					 	//填入excel表中
                      IRow row1 = cNopi .CreateHeaders(sheet,RowIndex, 0,21*20,str);
                      cNopi .AddCellStyle (row1,style1);
                      RowIndex ++;
	         		}		//内循环结束
             
			//表尾
			 CExcel .Nametail (RowIndex ,cNopi ,sheet, Sl.ToString (), (Jizhang == 0 ? "" : Jizhang .ToString ()) ,(Yifukuan  == 0 ? "" : Yifukuan  .ToString ()),Heji.ToString () ,style2 );
		     
			 FileStream fs = File.OpenWrite(str1+ "\\" + KeHuName  + ".xls");
		     workbook .Write(fs);
		     fs.Close ();
			
		      zhj += Heji ;	 zjl += jiShuQi ;  //总合计和总记录数累加
			
			}//外循环结束
			#endregion 
			
			string str4 = string.Format ("一共{0}条记录，{1}名客户，总金额{2}元。",zjl,hs.Count ,zhj);
		    AboutFile .WriteFiles (str1+"\\1.txt",str4);
	        MessageBox .Show("已成功生成完毕,文件位于文件夹\n" + str1 + "\\" );
			
		}//分客户结尾
		   		
	    else    //直接导出
		   {
	    	string str = AboutFile .SelectSaveFile ("C:\\","EXCEL文件(*.xls)|*.xls");
	    	if (str =="") return ;
	    	
	    	HSSFWorkbook workbook = new HSSFWorkbook ();
		    ISheet sheet = workbook .CreateSheet("sheet1");
			CNopi cNopi = new CNopi ();
			ICellStyle style1 = cNopi .NormalCellStyle(workbook );
			ICellStyle style2 = cNopi .HeadCellStyle (workbook );
		    //生成标题和表头
			CExcel .NameHeader (workbook ,sheet,cNopi ,style2);
			
			decimal jizhang = 0 ; decimal yifukuan = 0 ;
			string[] strrr = new string[9];
			int n = 2;
			for (int i = 0; i < DGV.Rows.Count ; i++) {
				
				
				  for (int j = 0; j < 9; j++) {
					strrr[j]=DGV.Rows[i].Cells[j+1].Value .ToString ();
					
				  }
				
				IRow ro = cNopi.CreateHeaders (sheet,n,0,21*20,strrr);
				cNopi.AddCellStyle (ro,style1);
				n++;
				if (i==DGV.Rows.Count-1 )continue  ; //到合计栏的时候，就进行下一个，合计栏不合计
				if (DGV.Rows[i].Cells[7].Value .ToString ()=="记账") {
					jizhang += Convert .ToDecimal(DGV.Rows[i].Cells[6].Value);
					
				} else {
					yifukuan += Convert .ToDecimal(DGV.Rows[i].Cells[6].Value);
				}
				
			}

			cNopi .AddCellStyle (sheet.GetRow(n-1),style2 );
			string jz =( (jizhang == 0)?"":FormatString.HuoBi<decimal>(jizhang));
			string yfk =( (yifukuan  == 0)?"":FormatString.HuoBi<decimal>(yifukuan ));
			
            
			CExcel.Nametail (n,cNopi ,sheet,jz,yfk,style2);
			
			cNopi .WriteAndSave (workbook ,str);
				
			MessageBox .Show (string.Format ("已成功导出文件{0}",str));
		   }
            			
			
			

//		
		}
		
		
		/// <summary>
		/// 取得唯一客户名单
		/// </summary>
		/// <returns>返回一个客户列表</returns>
		private HashSet<string> Hs()
		{
			HashSet<string > hs = new HashSet<string>();
			for (int i = 0; i < DGV.Rows.Count ; i++) {
				if(DGV.Rows[i].Cells[3].Value .ToString ()!="合计")
				   {
					hs.Add (DGV.Rows[i].Cells[2].Value .ToString ());
				   }
		}
			
			return hs;
		}
		
		
		/// <summary>
		/// 删除合计行
		/// </summary>
		private void DelHeji()
		{
		    if (DGV.Rows[DGV.Rows.Count-1].Cells[3].Value.ToString ()=="合计") {
	      	  DataGridViewRow ro = new DataGridViewRow();
	      	  ro = DGV.Rows [DGV.Rows.Count-1];
	      	  DGV.Rows.Remove(ro);
	        }
		}
		
		/// <summary>
		/// 汇总并生成序号
		/// </summary>
		private void HeJiAndXuHao()
		{
		   if (DGV.Rows .Count == 0)
		  {
		  	return ;
		  }
		  int sl = 0; decimal heji = 0;
          for (int i = 0; i < DGV.Rows .Count ; i++) {
		  	DGV .Rows[i].Cells[1].Value = i+1;
		  	  sl += Convert.ToInt32 (DGV.Rows[i].Cells[4].Value);
		  	  heji  += Convert.ToDecimal (DGV.Rows[i].Cells[6].Value);
		  }
		  
		  int n = DGV.Rows.Add();
		  for (int i = 0; i < DGV.Rows[n].Cells .Count  ; i++) {
		  	DGV .Rows[n].Cells[i].Value ="";
		  }
		  
		  DGV.Rows [n].Cells [10].Value =false ;
	      DGV.Rows[n].Cells[3].Value ="合计";
	      DGV.Rows[n].Cells[4].Value =sl.ToString() ;
	      DGV.Rows[n].Cells[6].Value =string.Format ("{0:#0.00}",heji);
	      StyleCell (n);
	     
	      DGV.Rows[n].DefaultCellStyle.Font=new Font ("宋体",9F,FontStyle .Bold);

		}
		
		public FormNeiRong  formnerong;
	
		void Label3Click(object sender, EventArgs e)
		{
			if (chuandi .FormShuo )return ;
	        formnerong = new FormNeiRong (TxtNeiRong );
	       	formnerong.Show ();
			formnerong .Width = 250;
			formnerong .TopMost = true ;
			formnerong .Opacity = 0.9;
			formnerong .Top = 20;
			formnerong .Left = (Screen .PrimaryScreen .WorkingArea.Width - 20) - formnerong .Width ;
			chuandi .FormShuo = true;
			ShowTable (chuandi .GxDS .Tables ["neirong"].Select ("bianhao <> -1","bianhao"),"neirong");
			ShowOther (formnerong.InitShow );
		}
		
		public FormBeiZhu  formbeizhu;
		
		void Label8Click(object sender , EventArgs e){
		
			if (chuandi .FormShuo1 )return ;
			formbeizhu = new FormBeiZhu (TxtBeiZhu  );
			formbeizhu.Show ();
			formbeizhu .Width = 250;
			formbeizhu .TopMost = true ;
			formbeizhu .Opacity = 0.9;
			formbeizhu .Top = (Screen .PrimaryScreen .WorkingArea.Height- 10 - formbeizhu.Height );
			formbeizhu .Left = (Screen .PrimaryScreen .WorkingArea.Width - 20) - formbeizhu .Width ;
			chuandi .FormShuo1 = true;
			ShowTable (chuandi .GxDS .Tables ["beizhu"].Select ("bianhao <> -1 ","bianhao" ),"beizhu");
			ShowOther (formbeizhu.InitShow);
			
		}
			
		void TxtNeiRongTextChanged(object sender, EventArgs e)
		{
			if(!chuandi.FormShuo ) return ;
			DataRow[] Dr;
			if( TxtNeiRong .Text .Trim () == "")
			{
				Dr = chuandi .GxDS .Tables ["neirong"].Select ("bianhao <> -1","bianhao");
			}
			
			else {
			
			Dr = chuandi .GxDS .Tables ["neirong"].Select ("neirong like '%"+ TxtNeiRong .Text .Trim ()+"%'");
			}
			ShowTable (Dr,"neirong");
			ShowOther (formnerong.InitShow );
		}
		
		public delegate string DE(string str);
		
		public event DE d1;
		
		void TxtBianHaoKeyPress(object  sender,KeyPressEventArgs e)
		{		
			
			
			if(e.KeyChar == 13)
			{
				if (!myvalidate .isAllNumric (TxtBianHao .Text .Trim ())) return ;
				if (TxtBianHao.Text .Trim () == "") return ;
				if (chuandi .FormShuo ){
				d1 = formnerong.FullBlank ;
				TxtNeiRong.Text =d1(TxtBianHao .Text .Trim ());
				}
				else{
				int i = int.Parse (TxtBianHao .Text .Trim ());
				
				DataRow[] Dr = chuandi .GxDS .Tables ["neirong"].Select ("bianhao = " + i );
				
				if ( Dr.Length > 0 ) TxtNeiRong.Text = Dr[0][2].ToString ();
					
			}
			
			
		}
		}
		void TxtBeiZhuTextChanged(object sender, EventArgs e)
		{
	
			if(!chuandi.FormShuo1 ) return ;
			DataRow[] Dr;
			if( TxtBeiZhu  .Text .Trim () == "")
			{
				Dr = chuandi .GxDS .Tables ["beizhu"].Select ("bianhao <> -1","bianhao");
			}
			else {
			    Dr = chuandi .GxDS .Tables ["beizhu"].Select ("beizhu like '%"+ TxtBeiZhu .Text .Trim ()+"%'");
			}
			ShowTable (Dr,"beizhu");
			ShowOther (formbeizhu.InitShow );
			
			
		}
		
		public void TxtBHKeyPress(object sender,KeyPressEventArgs e){
			
			
			if(e.KeyChar == 13)
			{
				if (!myvalidate .isAllNumric (TxtBH .Text .Trim ())) return ;

				if (TxtBH.Text .Trim () == "") return ;
				
				if (chuandi .FormShuo1 ){

    			d1 = formbeizhu.FullBlank ;
			
				TxtBeiZhu.Text =d1(TxtBH .Text .Trim ());

				}
				
				else{
					
				int i = int.Parse (TxtBH .Text .Trim ());
				
				DataRow[] Dr = chuandi .GxDS .Tables ["beizhu"].Select ("bianhao = " + i );
				
				if ( Dr.Length > 0 ) TxtBeiZhu.Text = Dr[0][2].ToString ();
					
			}
			}
			
			
		}


        #region// 点击标题行，表格排序，先删除合计栏，再加上 
        private DataGridViewRow ro;
        private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1) return;
            if (DGV.Rows.Count == 0) return;
            ro = DGV.Rows[DGV.Rows.Count - 1];
            DGV.Rows.Remove(ro);
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            DGV.Rows.Add(ro);
        }
        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
			label10.Text = dateTimePicker1.Value.ToString("yyyy年MM月dd日");
        }


		




    } //窗体类


}          //命名空间
	

	


