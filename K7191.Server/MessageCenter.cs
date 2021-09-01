using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace WindowsFormsApp1
{
    public class MessageCenter
    {
        public void OnDisposeCode(string msg)
        {
            UserMgr mgr = new UserMgr();
            RequestData data = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestData>(msg);
            if (data == null)
            {
                return;
            }
            switch (data.RequestCode)
            {
                case RequestCode.C0001:
                    UserModel model= Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data.Json);
                    mgr.CreateUser(new UserModel());
                    break;
                default:
                    break;
            }
        }
    }
}
