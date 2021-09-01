using System;
using System.Collections.Generic;

class ResultRows<T>
{
    /// <summary>
    /// 状态码
    /// </summary>
    public bool state { get; set; }
    /// <summary>
    /// 返回消息内容
    /// </summary>
    public string message { get; set; }
    /// <summary>
    /// 返回数据
    /// </summary>
    public PageList<T> data { get; set; }
}
[Serializable]
class ResultModel<T>
{
    /// <summary>
    /// 状态码
    /// </summary>
    public bool state { get; set; }
    /// <summary>
    /// 返回消息内容
    /// </summary>
    public string message { get; set; }
    /// <summary>
    /// 返回数据
    /// </summary>
    public T data { get; set; }
}
[Serializable]
public class PageList<T>
{
    //总数
    public long total { get; set; }
    //总页数
    public int pagecount { get; set; }
    public List<T> rows { get; set; }
}