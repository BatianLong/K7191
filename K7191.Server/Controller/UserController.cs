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
}