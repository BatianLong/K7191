using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;

public class PossessionMgr
{
    string strcon = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString.ToString();//"data source=C:\\Users\\Administrator\\Desktop.db";
    DbConnection dbConnection;
    PossessionContext Context;
    private static readonly string obj = "lock";
    public PossessionMgr()
    {
        dbConnection = new SQLiteConnection(strcon);
        Context = new PossessionContext(dbConnection);
    }
    /// <summary>
    /// 改变资产信息
    /// </summary>
    /// <param name="user"></param>
    public void CreateUser(PossessionModel possession)
    {
        DBHelper<PossessionModel> dbhelper = new DBHelper<PossessionModel>(Context);
        PossessionModel model = Context.Possession.Where(p => p.UserCode == possession.UserCode).FirstOrDefault();
        if (model != null)
        {
            model.Golds = possession.Golds;
            model.Integrate = possession.Integrate;
            model.ModifyTime = DateTime.Now;
            dbhelper.Update(model);
        }
        else
        {
            possession.ModifyTime = DateTime.Now;
            dbhelper.Add(possession);
        }
    }
    /// <summary>
    /// 查询资产信息
    /// </summary>
    /// <param name="possession"></param>
    /// <returns></returns>
    public PossessionModel GetPossessionInfo(PossessionModel possession)
    {
        DBHelper<PossessionModel> dbhelper = new DBHelper<PossessionModel>(Context);
        PossessionModel model = Context.Possession.Where(p => p.UserCode == possession.UserCode).FirstOrDefault();
        if (model == null)
        {
            model = new PossessionModel();
            model.UserCode = possession.UserCode;
        }
        return model;
    }
}
