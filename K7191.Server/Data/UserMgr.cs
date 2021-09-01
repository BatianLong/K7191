using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;

public class UserMgr
{
    string strcon = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString.ToString();//"data source=C:\\Users\\Administrator\\Desktop.db";
    DbConnection dbConnection;
    UserContext Context;
    public UserMgr()
    {
        dbConnection= new SQLiteConnection(strcon);
        Context = new UserContext(dbConnection);
    }
    public void CreateUser(UserModel user)
    {
        string usercode = SetUserCode();
        user.UserCode = usercode;
        user.CreateTime = DateTime.Now;
        user.CreateUser = usercode;
        DBHelper<UserModel> dbhelper = new DBHelper<UserModel>(Context);
        dbhelper.Add(user);
    }
    public string SetUserCode()
    {
        UserModel User = Context.User.OrderByDescending(p => p.ID).FirstOrDefault();
        int lastid = 0;
        if (User != null)
        {
            lastid = User.ID;
        }
        string Code = "U" + DateTime.Now.ToString("yyMMddHHmmss") + (lastid + 1).ToString("0000");
        return Code;
    }
    public string Number(int Length, bool Sleep)
    {
        if (Sleep)
            System.Threading.Thread.Sleep(3);
        string result = "";
        System.Random random = new Random();
        for (int i = 0; i < Length; i++)
        {
            result += random.Next(10).ToString();
        }
        return result;
    }
}
