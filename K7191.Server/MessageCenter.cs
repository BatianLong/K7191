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
        public void OnDisposeCode(string msg, string ip)
        {
            string UserCode = "";
            try
            {
                RequestData data = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestData>(msg);
                if (data == null)
                {
                    return;
                }
                switch (data.RequestCode)
                {
                    case RequestCode.R0001:
                        UserController controller = new UserController();
                        controller.Register(data.Json);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                LogMgr mgr = new LogMgr();
                LogInfo logInfo = new LogInfo();
                logInfo.CreateUser = UserCode == "" ? ip : UserCode;
                logInfo.Level = 1;
                logInfo.LogType = LogType.RequestError.ToString();
                logInfo.Message = ex.Message;
                logInfo.Info = ex.ToString();
                mgr.AddLog(logInfo);
            }
        }
    }
}
