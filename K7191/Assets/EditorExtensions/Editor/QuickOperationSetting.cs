using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System.Xml;

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
    [MenuItem(itemName: "编辑器扩展/生成xml &1")]
    public static void ToXml()
    {//xml保存的路径，这里放在Assets路径 注意路径。
        string filepath = Application.dataPath + @"/my.xml";
        //继续判断当前路径下是否有该文件
        if (!File.Exists(filepath))
        {
            //创建XML文档实例
            XmlDocument xmlDoc = new XmlDocument();
            //创建root节点，也就是最上一层节点
            XmlElement root = xmlDoc.CreateElement("transforms");
            //继续创建下一层节点
            XmlElement elmNew = xmlDoc.CreateElement("rotation");
            //设置节点的两个属性 ID 和 NAME
            elmNew.SetAttribute("id", "0");
            elmNew.SetAttribute("name", "momo");
            //继续创建下一层节点
            XmlElement rotation_X = xmlDoc.CreateElement("x");
            //设置节点中的数值
            rotation_X.InnerText = "0";
            XmlElement rotation_Y = xmlDoc.CreateElement("y");
            rotation_Y.InnerText = "1";
            XmlElement rotation_Z = xmlDoc.CreateElement("z");
            rotation_Z.InnerText = "2";
            //这里在添加一个节点属性，用来区分。。
            rotation_Z.SetAttribute("id", "1");

            //把节点一层一层的添加至XMLDoc中 ，请仔细看它们之间的先后顺序，这将是生成XML文件的顺序
            elmNew.AppendChild(rotation_X);
            elmNew.AppendChild(rotation_Y);
            elmNew.AppendChild(rotation_Z);
            root.AppendChild(elmNew);
            xmlDoc.AppendChild(root);
            //把XML文件保存至本地
            xmlDoc.Save(filepath);
            Debug.Log("createXml OK!");

            UnityEditor.AssetDatabase.Refresh();
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
