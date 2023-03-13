using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xiaoshouxinxi
{
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            string filename = string.Format("销售单备份{0:yyyy年MM月dd日HH时mm分ss秒}", DateTime.Now);

            string InitPath = "C:\\";

            if (Directory.Exists("D:\\")) InitPath = "D:\\";
            
            
            string SourceName = Directory.GetCurrentDirectory() + "\\yw.dat";
            
            string StrBackup = AboutFile.SelectSaveFile(InitPath , "数据库文件(*.dat)|*.dat|所有文件(*.*)|*.*",filename );

            if ( StrBackup == "" ) return ;
            try { 
                AboutFile.CopyFile(SourceName, StrBackup);
                MessageBox.Show("数据库已成功备份在" + StrBackup);
            }
            catch { 
                MessageBox.Show("备份错误！"); 
            }
            
        }
    }
}
