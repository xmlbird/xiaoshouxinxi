/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/2/24
 * 时间: 10:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;


#region 取汉字首字母类
/// <summary>
/// 取汉字首字母类
/// </summary>
static class GetFirstLetter
{
    /// <summary>

    /// 在指定的字符串列表CnStr中检索符合拼音索引字符串

    ///</summary>

    /// <param name="CnStr">汉字字符串</param>

    /// <returns>相对应的汉语拼音首字母串</returns>

    public static string GetSpellCode(string CnStr) {

        string strTemp = "";

        int iLen = CnStr.Length;

        int i = 0;

        for (i = 0; i <= iLen - 1; i++) {

            strTemp += GetCharSpellCode(CnStr.Substring(i, 1));


        }

        return strTemp;

    }

    /// <summary>
    /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
    /// </summary>
    /// <param name="CnChar">单个汉字</param>
    /// <returns>单个大写字母</returns>
    private static string GetCharSpellCode(string CnChar) {

        long iCnChar;

        byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

        //如果是字母，则直接返回

        if (ZW.Length == 1) {

            return CnChar.ToUpper();

        }

        else {

            // get the array of byte from the single char

            int i1 = (short)(ZW[0]);

            int i2 = (short)(ZW[1]);

            iCnChar = i1 * 256 + i2;

        }

        // iCnChar match the constant

        if ((iCnChar >= 45217) && (iCnChar <= 45252)) {

            return "A";

        }

        else if ((iCnChar >= 45253) && (iCnChar <= 45760)) {

            return "B";

        } else if ((iCnChar >= 45761) && (iCnChar <= 46317)) {

            return "C";

        } else if ((iCnChar >= 46318) && (iCnChar <= 46825)) {

            return "D";

        } else if ((iCnChar >= 46826) && (iCnChar <= 47009)) {

            return "E";

        } else if ((iCnChar >= 47010) && (iCnChar <= 47296)) {

            return "F";

        } else if ((iCnChar >= 47297) && (iCnChar <= 47613)) {

            return "G";

        } else if ((iCnChar >= 47614) && (iCnChar <= 48118)) {

            return "H";

        } else if ((iCnChar >= 48119) && (iCnChar <= 49061)) {

            return "J";

        } else if ((iCnChar >= 49062) && (iCnChar <= 49323)) {

            return "K";

        } else if ((iCnChar >= 49324) && (iCnChar <= 49895)) {

            return "L";

        } else if ((iCnChar >= 49896) && (iCnChar <= 50370)) {

            return "M";

        } else if ((iCnChar >= 50371) && (iCnChar <= 50613)) {

            return "N";

        } else if ((iCnChar >= 50614) && (iCnChar <= 50621)) {

            return "O";

        } else if ((iCnChar >= 50622) && (iCnChar <= 50905)) {

            return "P";

        } else if ((iCnChar >= 50906) && (iCnChar <= 51386)) {

            return "Q";

        } else if ((iCnChar >= 51387) && (iCnChar <= 51445)) {

            return "R";

        } else if ((iCnChar >= 51446) && (iCnChar <= 52217)) {

            return "S";

        } else if ((iCnChar >= 52218) && (iCnChar <= 52697)) {

            return "T";

        } else if ((iCnChar >= 52698) && (iCnChar <= 52979)) {

            return "W";

        } else if ((iCnChar >= 52980) && (iCnChar <= 53640)) {

            return "X";

        } else if ((iCnChar >= 53689) && (iCnChar <= 54480)) {

            return "Y";

        } else if ((iCnChar >= 54481) && (iCnChar <= 55289)) {

            return "Z";

        } else

            return ("?");

    }
 }
#endregion 



#region 形成格式化字符串的类
public static class FormatString
     {
   	   #region     形成货币"#0.00"的形式
   	   /// <summary>
   	    /// 形成货币"#0.00"的形式
   	    /// </summary>
   	    /// <param name="str1">输要格式化的值，有Decemial,double等类型 </param>
   	    /// <returns>返回已经格式化的字符串</returns>
     	public static string  HuoBi<T>(T str1){
     	   
     		return string.Format("{0:#0.00}",str1);
     	
     	}
       #endregion 
   	    

      #region     形成日期"#yyyy-MM-dd"的形式
   	    /// <summary>
   	    /// 形成日期"#yyyy-MM-dd"的形式
   	    /// </summary>
   	    /// <param name="str1">输要格式化的值，有datetime等类型 </param>
   	    /// <returns>返回已经格式化的字符串</returns>
     	public static string  Fdate<T>(T str1){
     	   
     		return string.Format("{0:yyyy-MM-dd}",str1);
     	
     	}
   	     #endregion 
     }


    #endregion
