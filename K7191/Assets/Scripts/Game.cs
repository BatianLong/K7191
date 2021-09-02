using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Game:MonoBehaviour
{
    private void Start()
    {
        //连接服务器
        EventCenter.Broadcast<string>(EventType.ShowText,"正在连接服务器...");
        Client.ConnectServer();
        //检查更新
        //服务器
    }
}
