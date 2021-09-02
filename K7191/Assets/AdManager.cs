using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;//引入unityAds的命名空间  
using UnityEngine.UI;
//using Completed;
public class AdManager : MonoBehaviour
{
    //public Text tex;
    //public Text tex2;
    int index = 1;
    // Use this for initialization  
    void Start()
    {
        //根据GAME ID来初始化广告，是之前在网页上创建项目时获得的“1541875”  
        Advertisement.Initialize("4289199");
    }
    // Update is called once per frame  
    void Update()
    {
        //判断广告是否加载完毕，是否可以播放  
        if (Advertisement.IsReady())
        {
            //tex.text = "OK!!!";
        }
        else
        {
            //tex.text = "Wait!!!";
        }
    }
    /// <summary>  
    /// 由显示广告的button调用的函数方法  
    /// </summary>  
    public void showAd(int num)
    {
        //如果没有正在播放广告并且广告已经准备好，开始播放广告  
        if (Advertisement.isShowing == false)
        {
            if (Advertisement.IsReady())
            {
                ShowOptions options = new ShowOptions();
                options.resultCallback = HandleShowResult;
                Advertisement.Show("Interstitial_Android", options);//播放广告  
            }
        }
    }
   
    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video completed - Offer a reward to the player");
            //tex2.text = "Video completed - Offer a reward to the player";
            if (index==1)
            {
                //Player.instance.Add(2);
            }
            else if (index == 2)
            {
                //Player.instance.Resurgence();
            }
        }
        else if (result == ShowResult.Skipped)
        {
            //tex2.text = "Video was skipped - Do NOT reward the player";

            Debug.LogWarning("Video was skipped - Do NOT reward the player");
            if (index == 1)
            {
                //Player.instance.Add(1);
            }
            else if (index == 2)
            {
               // Player.instance.Resurgence();
            }
        }
        else if (result == ShowResult.Failed)
        {
            //tex2.text = "Video failed to show";

            Debug.LogError("Video failed to show");
           
        }
    }
   
}