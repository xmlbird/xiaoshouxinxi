/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/20
 * 时间: 20:43
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System .Data .OleDb ;
using System .Collections .Generic ;
namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of FormShangPinXinxi.
	/// </summary>
	public partial class FormShangPinXinxi : Form
	{
		List<Control> ctrl = new List<Control> ();
		public FormShangPinXinxi()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ctrl.Add(TxtName );
			ctrl.Add (TxtDanjia );
			ctrl.Add (BtnAdd );
			CControls cc = new CControls (ctrl);
          foreach (Control  el in ctrl) {
				el.KeyDown += new System .Windows .Forms.KeyEventHandler (cc.KeyPorD );
          }			
   			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public void ShowList()
		{
            listView1.Items.Clear ();
			DataHelper helper =new DataHelper ();
			try {
			helper.open ();
			}
			catch{
				MessageBox .Show("出现错误");
				helper .close ();
				return ;
			}
			
			string str="select * from shangpin order by id";
			  
			try{
			 OleDbDataReader myReader=helper.dataread (str);
			  if(myReader.HasRows==true){
			 	int i = 1;
			 	while(myReader.Read () ){
			 		ListViewItem LVI = new ListViewItem(myReader [0].ToString ());      //先实例化ListViewItem这个类
			 		LVI .SubItems .Add (i++.ToString ());
			 		LVI.SubItems.Add(myReader[1].ToString() );     //添加第2列内容
			 		LVI.SubItems.Add(string.Format ("{0:#0.00}",myReader[2]));
					this.listView1 .Items.Add(LVI);                  //集体添加进去
			     			       }
			        this.listView1.EndUpdate();
		                    	}
			}catch {
			MessageBox .Show("出现错误");
				helper .close ();
				return ;
			}
			TxtName .TabIndex = 0;
		}
		
		
		
		
		
		void FormShangPinXinxiLoad(object sender, EventArgs e)
		{
			BtnAdd .Enabled = true;
			BtnXiuGai .Enabled = true;
			button3 .Enabled =true;
			BtnQueDing.Enabled =false;
			BtnQuXiao .Enabled =false;
	        
			ShowList();
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
	        string strname = TxtName.Text.Trim ();
	        string strdanjia =TxtDanjia .Text.Trim ();
			
	        if ((myvalidate .ifblank (strname)) || myvalidate .ifblank (strdanjia))
			    {
			    	MessageBox .Show ("名称或金额不能为空");
			    	return ;
			    }
	        
	        if (!myvalidate .ifshuozi (strdanjia)) {
	        	MessageBox .Show("请正确输入单价");
				TxtDanjia.Text = "";
	        	return ;
	        }

			try
			{
				string suoXie = GetFirstLetter.GetSpellCode(strname);
				decimal decdanjia = Convert.ToDecimal(strdanjia);
				string str = "insert into shangpin (name ,danjia,suoxie) values ('" + strname + "'," + decdanjia + ",'" + suoXie + "')";
                DataExec.DE(str);
            }
			catch { MessageBox.Show("出现错误，请联系管理员"); }
			ShowList ();
			TxtName .Text ="";
			TxtDanjia.Text ="";
		}
		
		
		void BtnXiuGaiClick(object sender, EventArgs e)
		{
	
			if (listView1 .SelectedItems .Count ==0)
			{
				MessageBox .Show ("请选定一个商品");
				return ;
			}
			
			BtnAdd .Enabled  =false;
			button3 .Enabled =false;
			BtnXiuGai .Enabled =false;
			BtnQuXiao .Enabled =true;
			BtnQueDing .Enabled =true;
			TxtName.Text  = listView1 .SelectedItems[0].SubItems[2].Text ;
			TxtDanjia.Text   = listView1 .SelectedItems[0].SubItems[3].Text ;
			
		
			
		}
		void Button3Click(object sender, EventArgs e)
		{
	       if (listView1 .SelectedItems .Count ==0)
			{
				MessageBox .Show ("请选定一个商品");
				return ;
			}
			
			if (Ask .YesOrNot ("是否要删除这个商品") == false )
			{
				return;
			}
			
	        int id =Convert.ToInt32 (listView1.SelectedItems[0].SubItems[0].Text);
			string str = "delete from shangpin where id ="+id;
			DataExec .DE (str);
			ShowList();
		}
		
		
		void BtnQueDingClick(object sender, EventArgs e)
		{
			string strname = TxtName.Text.Trim ();
	        string strdanjia =TxtDanjia .Text.Trim ();
	        if ((myvalidate .ifblank (strname)) || myvalidate .ifblank (strdanjia))
			    {
			    	MessageBox .Show ("名称或金额不能为空");
			    	return ;
			    }
	        if (!myvalidate .ifshuozi (strdanjia)) {
	        	MessageBox .Show("请正确输入单价");
	        	return ;
	        }
	         int id =Convert.ToInt32 (listView1.SelectedItems[0].SubItems[0].Text);
			string suoXie = GetFirstLetter.GetSpellCode(strname);
			decimal decdanjia = Convert.ToDecimal ( strdanjia);
			string str =string.Format ("update shangpin set name='{0}',danjia={1},suoxie='{2}' where id={3}",strname ,decdanjia ,suoXie,id );
			DataExec .DE  (str);
			ShowList ();
			TxtName .Text ="";
			TxtDanjia.Text ="";
			BtnAdd .Enabled = true;
			BtnXiuGai .Enabled = true;
			button3 .Enabled =true;
			BtnQueDing.Enabled =false;
			BtnQuXiao .Enabled =false;
		}
		void BtnQuXiaoClick(object sender, EventArgs e)
		{
	        TxtName .Text ="";
			TxtDanjia.Text ="";
			BtnAdd .Enabled = true;
			BtnXiuGai .Enabled = true;
			button3 .Enabled =true;
			BtnQueDing.Enabled =false;
			BtnQuXiao .Enabled =false;
		}
		
	}
}
