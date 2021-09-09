using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;

public class BuddyMgr
{
    string strcon = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString.ToString();//"data source=C:\\Users\\Administrator\\Desktop.db";
    DbConnection dbConnection;
    BuddyContext Context;
    public BuddyMgr()
    {
        dbConnection = new SQLiteConnection(strcon);
        Context = new BuddyContext(dbConnection);
    }
    public void AddLog(BuddyModel buddy)
    {
        buddy.CreateTime = DateTime.Now;
        DBHelper<BuddyModel> dbhelper = new DBHelper<BuddyModel>(Context);
        dbhelper.Add(buddy);
    }
}
