using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserModel:BaseEntity
{
    public string UserCode { get; set; }
    public string Account { get; set; }
    public string RealName { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string LastIp { get; set; }
}
