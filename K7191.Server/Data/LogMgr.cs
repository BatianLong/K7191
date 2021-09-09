using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;

public class LogMgr
{
    string strcon = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString.ToString();//"data source=C:\\Users\\Administrator\\Desktop.db";
    DbConnection dbConnection;
    LogContext Context;
    public LogMgr()
    {
        dbConnection = new SQLiteConnection(strcon);
        Context = new LogContext(dbConnection);
    }
    public void AddLog(LogInfo log)
    {
        log.CreateTime = DateTime.Now;
        DBHelper<LogInfo> dbhelper = new DBHelper<LogInfo>(Context);
        dbhelper.Add(log);
    }
}
