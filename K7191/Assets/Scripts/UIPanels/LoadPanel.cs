/***
 *
 *         Title:VR安全事故
 *                    主题：
 *          Description:
 *                    功能：
 *          Data:2021
 *          Version: 0.1版本
 *          Modify Recoder:
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class LoadPanel : PathDefine
{
    void Start()
    {
        EventCenter.AddListener<string>(EventType.ShowText, OnShowMsg);
    }
    void OnShowMsg(string msg)
    {
        Messagetxt.text = msg;
    }
}

