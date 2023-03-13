/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/17
 * 时间: 8:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Data .OleDb ;
using System.Windows.Forms;
using System .Collections.Generic ;

namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class FormKeHuXinXi : Form
	{
		List <Control > ctrl = new List<Control>();
		public FormKeHuXinXi()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ctrl.Add (TxtAdd );
			ctrl.Add (BtnAdd );
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			CControls cc = new CControls (ctrl);
			foreach (Control  el in ctrl) {
			   el.KeyDown += new KeyEventHandler  (cc.KeyPorD  );
			}
		
		
		
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
			
			string str="select * from kehu order by name";
			  
			try{
			 OleDbDataReader myReader=helper.dataread (str);
			  if(myReader.HasRows==true){
			 	int i = 1;
			 	while(myReader.Read () ){
			 		ListViewItem LVI = new ListViewItem(myReader [0].ToString ());      //先实例化ListViewItem这个类
			 		LVI .SubItems .Add (i++.ToString ());
			 		LVI.SubItems.Add(myReader[1].ToString() );     //添加第2列内容
					this.listView1 .Items.Add(LVI);                  //集体添加进去
			     			       }
			        this.listView1.EndUpdate();
		                    	}
			}catch {
			MessageBox .Show("出现错误");
				helper .close ();
				return ;
			}
			TxtAdd .TabIndex = 0;
		}
               
	
		void FormKeHuXinXiLoad(object sender, EventArgs e)
		{
			ShowList ();
		}
		
		
		void BtnAddClick(object sender, EventArgs e)
		{
			string name1 = TxtAdd.Text.Trim ();
			if (myvalidate .ifblank (name1))
			    {
			    	MessageBox .Show ("名字不能为空");
			    	return ;
			    }
			
			string suoXie = GetFirstLetter.GetSpellCode(name1);
			string str ="insert into kehu (name ,suoxie) values ('"+ name1 +"','" + suoXie +"')";
			if (DataExec .DE  (str) == 2) MessageBox .Show ("错误，请检查是否有重名");
			
			ShowList ();
			TxtAdd .Text ="";
			TxtAdd .Focus ();
			
		}
		
		void BtnDeleteClick(object sender, EventArgs e)
		{
			if (listView1 .SelectedItems .Count ==0)
			{
				MessageBox .Show ("请选定一个客户");
				return ;
			}
			
			if (Ask .YesOrNot ("是否要删除这个用户") == false )
			{
				return;
			}
			
			 int id =Convert.ToInt32 (listView1.SelectedItems[0].SubItems[0].Text);
			string str = "delete from kehu where id ="+id;
			DataExec .DE (str);
			ShowList();
			
		}
		
		
		
		
		
		
		
		
	}
}
