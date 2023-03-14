/*
 * 由SharpDevelop创建。
 * 用户： e
 * 日期: 2023/3/2
 * 时间: 11:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System ;
using System .Collections .Generic ;
using System .Windows .Forms ;

public class CControls
{
     //创建委托，该委托调用方法无返回佱值 参数为 调用者 ，按键参数 和 控件数组 
	private delegate void KP (Object sender,KeyEventArgs  e,List<Control> ctrl);
	//创建控件数组属性	
	public List<Control > ctrl { get; set; }
	//默认构造函数
	public CControls()
	{
	
	}
	//传控件数组的构造函数
	public CControls (List <Control > ctrl)
	{
		this.ctrl = ctrl;
	}

    
	
	#region  按下回车下一个控件获得焦点
    /// <summary>
    /// 按下回车下一个控件获得焦点
    /// </summary>
    /// <param name="sender">调用者</param>
    /// <param name="e">按键参数</param>
    /// <param name="ctrl">控件数组</param>
    private void Kp (Object sender, KeyEventArgs  e, List<Control> ctrl) 
    {
    	for (int i = 0; i < ctrl.Count -1; i++) {
    		if (sender == ctrl[i]) {
                if (ctrl[i].Tag != null && ctrl[i].Text =="")    //必填项，如果为空则跳出方法，已经事先给必填项的tag设为1
                {
                    return;
                }   	  	    
                if (e.KeyValue  == 13 ) {
    				ctrl[i+1].Focus ();
       	  	    
                }
    			
       	  }
    		
       }
    
    
    }
    #endregion

    #region //使用委托调用获得焦点函数，因为 KeyDown 事件委托 只允许 send和e 这两个参数 
  
    public void KeyPorD (object sender,KeyEventArgs e)
    {
    	        
        KP kp = new KP(Kp);
    	kp.Invoke (sender,e,ctrl);
    }

    #endregion

   


}