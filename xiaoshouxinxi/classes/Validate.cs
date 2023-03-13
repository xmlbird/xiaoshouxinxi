/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/24
 * 时间: 10:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Text.RegularExpressions;
using System .Text ; 


namespace xiaoshouxinxi
{
	/// <summary>
	/// Description of Validate.
	/// </summary>
	public static class myvalidate{
	
		//1.判断是否为空
		 public static bool ifblank(string str){
			if (str.Trim() == null || str.Trim().Length == 0)    //验证这个参数是否为空
			{return true;}                           //是，就返回False
             else
             {return false ;}
		}
		
		//2.判断是否都是数字
		public static bool isAllNumric(string str){
     		 ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例
             byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里
             foreach (byte c in bytestr)                   //遍历这个数组里的内容
            {
                if (c < 48 || c > 57)                          //判断是否为数字
                {
                    return false;                              //不是，就返回False
                                    }
            }
            return true;                                        //是，就返回True
        }
		
		
		//3.判断是否超过某个 位数
		 public static bool ifchaoguoweishu(string str , int n){
			if (str.Trim().Length > n)    //验证这个参数是否大于某个位数
                return false;                           //是，就返回False
            else
             	return true;    
		}
		
		//4.判断是否低于某个位数
		 public static bool ifdiyuweishu(string str , int n){
			if (str.Trim().Length < n)    //验证这个参数是否大于某个位数
                return false;                           //是，就返回False
			else
             	return true;
            }
				
		//判断是否是两位小数或整数
		public static bool ifshuozi(string str)
		{Regex reg =new Regex("^[0-9]*(\\.[0-9]{1,2})?$");
		
		if (reg.IsMatch (str))
		{
			return true ;
		}
		else 
		{
			return false;
		}
		
		
		}
		
        public static bool iffshuozi(string str)
		{Regex reg =new Regex("^[-]*[0-9]*(\\.[0-9]{1,2})?$");
		
		if (reg.IsMatch (str))
		{
			return true ;
		}
		else 
		{
			return false;
		}
		
		
		}		
		
		
		
		
		
		
		}


}
