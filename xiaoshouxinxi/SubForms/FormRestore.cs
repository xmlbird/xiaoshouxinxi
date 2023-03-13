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
    public partial class FormRestore : Form
    {
        public FormRestore()
        {
            InitializeComponent();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            string InitPath = "C:\\";

            if (Directory.Exists("D:\\")) { InitPath = "D:\\"; }

            label1.Text = AboutFile.SelectOpenFile(InitPath, "数据文件（*.dat)|*.dat").Trim ();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            DialogResult dr = MessageBox.Show("是否确定恢复", "警告", MessageBoxButtons.YesNo);

            if (DialogResult.No == dr) return ;

            string Path = Directory.GetCurrentDirectory() + "\\yw.dat";

            try { 
            
                AboutFile .CopyFile (label1 .Text , Path );

                MessageBox.Show("数据已成功恢复");
            
            }
            catch
            {
                MessageBox.Show("没有恢复成功！请重试");
            }



        }
    }
}
