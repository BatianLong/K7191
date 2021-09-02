using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class QuickOperationSetting : Editor
{
    [MenuItem(itemName: "编辑器扩展/隐藏背景 &o")]
    private static void CloseSDK_SetupAndRun()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        GameObject BgImg = Canvas.transform.GetComponentInChildren<Image>().transform.Find("BgImg").gameObject;
        if (BgImg != null)
        {
            BgImg.SetActive(!BgImg.activeSelf);
        }
    }

    [MenuItem(itemName: "编辑器扩展/显示物体 &s")]
    private static void ShowObject()
    {
        SetVisivle(true);
    }
    private static void SetVisivle(bool isShow)
    {
        Object[] objects = Selection.objects;
        foreach (var obj in objects)
        {
            GameObject o = (GameObject)obj;
            if (o)
            {
                o.SetActive(isShow);
            }
        }
    }
    [MenuItem(itemName: "编辑器扩展/隐藏物体 &d")]
    private static void HideObject()
    {
        SetVisivle(false);
    }


    [MenuItem(itemName: "编辑器扩展/打包AssetBundle")]
    public static void BuildAssetBundle()
    {
        string packagePath = Application.streamingAssetsPath;
        if (!Directory.Exists(packagePath))
        {
            Debug.LogError("打包Asseybundle失败：错误路径--" + packagePath);
        }
        BuildPipeline.BuildAssetBundles(packagePath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        AssetDatabase.Refresh();
    }

}
