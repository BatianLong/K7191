using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RequestData//<T>
{
    public RequestCode RequestCode { get; set; }
    public RequestType RequestType { get; set; }
    public string Json { get; set; }
    //public T Model { get; set; }
    //public List<T> Models { get; set; }
}
