using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum LogType
{
    RequestError,
    UserCreate,//用户创建
    UserLogin,//用户登录
    UserTapeOut,//用户下线
}
public class LogInfo
{
    public int ID { get; set; }
    public string LogType { get; set; }
    public int Level { get; set; }
    public string Message { get; set; }
    public string Info { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 创建用户
    /// </summary>
    public string CreateUser { get; set; }
}
