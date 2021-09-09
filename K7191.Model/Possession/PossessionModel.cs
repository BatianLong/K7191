
using System;

public class PossessionModel
{
    public int ID { get; set; }
    public string UserCode { get; set; }
    /// <summary>
    /// 金币数量--行星币
    /// </summary>
    public int Golds { get; set; } = 0;
    /// <summary>
    /// 星积分
    /// </summary>
    public int Integrate { get; set; } = 0;
    public DateTime ModifyTime { get; set; }
}
