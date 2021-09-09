using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BaseEntity
{
    public int ID { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 创建用户
    /// </summary>
    public string CreateUser { get; set; }
    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime Modifyime { get; set; }
    /// <summary>
    /// 修改用户
    /// </summary>
    public string ModifyUser { get; set; }
    /// <summary>
    /// 数据是否有效
    /// </summary>
    public bool IsValid { get; set; }
}
