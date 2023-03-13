/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/23
 * 时间: 21:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System .IO;
using System.Windows.Forms;
using System .Collections .Generic;
using System.Windows.Forms.VisualStyles;

/// <summary>
/// Description of Class1.
/// </summary>
public static class AboutFile
	{
		
		//判断一个文件是否被打开
		public static bool isFileLocked(string pathName)
        {
            try
            {
                if (!File.Exists(pathName))
                {
                    return false;
                }
                using (var fs = new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    fs.Close();
                }
            }
            catch
            {
                return true;
            }
            return false;
        }
	
	
	
	//判断是否为空文件夹
	
	public static bool isEmptyFolder(string str1)
	{
	    if (Directory.GetDirectories(str1 + "\\").Length > 0 || Directory.GetFiles(str1+ "\\").Length > 0)
			{
			return false ;
			}
	    return true;
		
	}

    //创建文件并写入内容
	public static void WriteFiles(string str,string str1)
    {
		
       if (!File.Exists(str))
            {
               //没有则创建这个文件
                FileStream fs1 = new FileStream(str, FileMode.Create, FileAccess.Write);//创建写入文件 
               //设置文件属性为隐藏
                //File.SetAttributes(@"c:\\users\\administrator\\desktop\\webapplication1\\webapplication1\\testtxt.txt",  FileAttributes.System );    
                StreamWriter sw = new StreamWriter(fs1);
                sw.Write(str1);//开始写入值
                sw.Close();
                fs1.Close();
               
            }

      }
	
	
	public static string SelectFolder()
	{
	
	string str1 = "";
			
	FolderBrowserDialog folder = new FolderBrowserDialog ();
	folder .Description ="选择要保存的文件夹";
	if (folder .ShowDialog() == DialogResult.OK)
		{
		    str1 =folder.SelectedPath ;
		}	
	
	return str1;
	}

    public static string SelectOpenFile(string InitPath, string filter)
    {
         OpenFileDialog openFileDialog = new OpenFileDialog ();
         
         openFileDialog.InitialDirectory = InitPath;

        openFileDialog.Filter = filter;

        openFileDialog.FilterIndex = 0;

        openFileDialog .Multiselect = false;

        openFileDialog.AddExtension = true;

        openFileDialog.RestoreDirectory = true;

        DialogResult dr = openFileDialog .ShowDialog ();

        if (dr == DialogResult.OK && openFileDialog .FileName .Length > 0)
        {
            string Path = openFileDialog.FileName.Trim();

            return Path;
        }

        return "";
    }




	public static string SelectSaveFile(string InitPath, string filter,string filename = "")
	{
	     string path=""; //文件名，没有后缀
       
         SaveFileDialog saveFileDialog1 = new SaveFileDialog();
         
         saveFileDialog1.InitialDirectory = InitPath;
         
         saveFileDialog1.Filter = filter;
        
         saveFileDialog1.FileName = filename;
         
         saveFileDialog1.FilterIndex = 0;
         
         saveFileDialog1.AddExtension = true;
         
         saveFileDialog1.RestoreDirectory = true;
         
         DialogResult dr = saveFileDialog1.ShowDialog();
         
          if (dr == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                path =saveFileDialog1 .FileName .Trim ();	
                
                return path ;
            }
            return "";
	}



    #region
    //	public static void WriteSave<T>(string File_Path_Name, Object File1)
    //	    {
    //	      FileStream fs = File.OpenWrite(File_Path_Name);
    //		  File1 .Write(fs);
    //		  fs.Close ();
    //	    }

    #endregion



    #region//复制文件
    
    public static void CopyFile(string SourceName,string TargetName)
    {
        File.Copy(SourceName , TargetName , true);
            
    }



    #endregion 

}

