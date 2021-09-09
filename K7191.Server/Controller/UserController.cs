using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserController
{
    UserMgr mgr = new UserMgr();
    public void Register(string strjson)
    {
        UserModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(strjson);
        //创建用户
        mgr.CreateUser(model);
        //新增登录日志信息
    }
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="strjson"></param>
    public void Login(string strjson)
    {

    }
    /// <summary>
    /// 注销
    /// </summary>
    /// <param name="strjson"></param>
    public void LogOut(string strjson)
    {

    }
    /// <summary>
    /// 加载好友列表
    /// </summary>
    /// <param name="strjson"></param>
    public void LoadBuddyList(string strjson)
    {
        BuddyModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<BuddyModel>(strjson);
        //创建用户
        //mgr(BuddyModel);
    }
    /// <summary>
    /// 
    /// </summary>
    public void AddBuddy() { 
    
    }
}