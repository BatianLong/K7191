using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Text;

    /// <summary>
    /// 通用函数
    /// </summary>
    public static class UtilFuncs
    {
        #region 自动代码
        public static void WriteCodeMainTemp(StreamWriter writer, string ObjName)
        {
            writer.WriteLine(@"/***
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

");
            writer.WriteLine("   public partial class " + ObjName + " : PathDefine");
            writer.WriteLine(@"   {");
            writer.WriteLine(@"      void Start()
       {
           
       }
   }
");
        }

        public static void WriteCodeTemplate(StreamWriter writer, string ObjName, List<BindInfo> bindInfos)
        {
            writer.WriteLine(@"/***
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
using UnityEngine.UI;
using UnityEngine;");
            //writer.WriteLine(@"        [SerializeField] private string PathDefine;");
            writer.WriteLine("    public partial class " + ObjName);
            writer.WriteLine(@"    {");
            for (int i = 0; i < bindInfos.Count; i++)
            {
                writer.WriteLine("\t\t[SerializeField] private " + bindInfos[i].ComponentName + " " + bindInfos[i].Name.IgnoreSpecialCode() + ";");
            }
            writer.WriteLine("\t}");
        }

        #endregion
        public static void DisEnableAllChildrensMesh(this Transform trans)
        {
            MeshRenderer[] meshRenderers = trans.GetComponentsInChildren<MeshRenderer>(true);
            foreach (var item in meshRenderers)
            {
                item.enabled = false;
            }
        }

        //public static ClickFunc GetClickFunc<T>(this T trans) where T : Component
        //{
        //    return trans.GetComponent<ClickFunc>();
        //}
        //public static void SetClickFunc<T>(this T t, Action func) where T : Component
        //{
        //    t.gameObject.GetOrAddComponect<ClickFunc>().SetClickFunc(func);
        //}
        //public static void ClearClickFunc<T>(this T t) where T : Component
        //{
        //    t.gameObject.GetOrAddComponect<ClickFunc>().ClearAll();
        //}
        //public static void SetClickFunc(this GameObject t, Action func)
        //{
        //    t.GetOrAddComponect<ClickFunc>().SetClickFunc(func);
        //}

        //public static void SetTriggerFunc(this GameObject t, string aimName, Action func)
        //{
        //    t.GetOrAddComponect<ColliderTrigger>().SetTriggerFuncByName(aimName, func);
        //}
        //public static void SetTriggerFunc<T>(this T t, string aimName, Action func) where T : Component
        //{
        //    t.gameObject.GetOrAddComponect<ColliderTrigger>().SetTriggerFuncByName(aimName, func);
        //}
        //public static void SetCollisionFunc(this GameObject t, string aimName, Action func)
        //{
        //    t.GetOrAddComponect<ColliderTrigger>().SetTriggerFuncByName(aimName, func);
        //}
        //public static void SetCollisionFunc<T>(this T t, string aimName, Action func) where T : Component
        //{
        //    t.gameObject.GetOrAddComponect<ColliderTrigger>().SetCollisionFunc(aimName, func);
        //}

        //public static void SetSeeFunc<T>(this T t, Action func) where T : Component
        //{
        //    t.gameObject.GetOrAddComponect<SeeSeeFunc>().SetSeeFunc(func);
        //}
        //public static void SetSeeFunc(this GameObject t, Action func)
        //{
        //    t.gameObject.GetOrAddComponect<SeeSeeFunc>().SetSeeFunc(func);
        //}
        //public static void SetSeeFunc(this Transform t, Action func)
        //{
        //    t.GetOrAddComponect<SeeSeeFunc>().SetSeeFunc(func);
        //}

        //public static void DeathCamera(this Camera cam, bool isDie = true)
        //{
        //    if (isDie)
        //    {
        //        cam.gameObject.GetOrAddComponect<ScreenToGray>().enabled = true;
        //    }
        //    else
        //    {
        //        cam.gameObject.GetOrAddComponect<ScreenToGray>().enabled = false;
        //    }
        //}

        //public static int WaitDO(this float t, Action func)
        //{
        //    return WaitFunc.Instance.WaitTimeDo(t, func);
        //}

        //public static void SetEnableFunc(this GameObject go, Action func)
        //{
        //    go.GetOrAddComponect<OnEnableFunc>().SetEnableFunc(func);
        //}
        //public static void SetEnableFunc(this Transform go, Action func)
        //{
        //    go.GetOrAddComponect<OnEnableFunc>().SetEnableFunc(func);
        //}
        //public static void SetEnterExitFunc(this Transform go, Action enterFun, Action exitFun)
        //{
        //    go.GetOrAddComponect<EnterExitFunc>().SetEnterExitFunc(enterFun, exitFun);
        //}
        //public static void SetEnterExitFunc<T>(this T go, Action enterFun, Action exitFun) where T : Component
        //{
        //    go.transform.GetOrAddComponect<EnterExitFunc>().SetEnterExitFunc(enterFun, exitFun);
        //}
        //public static void SetEnterExitFunc(this GameObject go, Action enterFun, Action exitFun)
        //{
        //    go.GetOrAddComponect<EnterExitFunc>().SetEnterExitFunc(enterFun, exitFun);
        //}

        //public static void SignInfo(this GameObject go)
        //{
        //    go.GetOrAddComponect<InfoRecord>().SignOrigiInfo();
        //}
        //public static void SignInfo<T>(this T go) where T : Component
        //{
        //    go.transform.GetOrAddComponect<InfoRecord>().SignOrigiInfo();
        //}
        //public static void ResetInfo(this GameObject go)
        //{
        //    InfoRecord info = go.transform.GetComponent<InfoRecord>();
        //    if (info)
        //    {
        //        info.ResetInfo();
        //    }
        //}
        //public static void ResetInfo<T>(this T go) where T : Component
        //{
        //    InfoRecord info = go.transform.GetComponent<InfoRecord>();
        //    if (info)
        //    {
        //        info.ResetInfo();
        //    }

        //}
        //public static void SetSnowEffect(this GameObject obj)
        //{
        //    MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
        //    if (mesh)
        //    {
        //        //mesh.materials.
        //        Material[] materials = mesh.materials;
        //        for (int i = 0; i < materials.Length; i++)
        //        {
        //            materials[i].shader = Shader.Find("Mobile/Snow Diffuse");
        //        }
        //        // mesh.material = new Material();
        //    }
        //    if (obj.transform.childCount != 0)
        //    {
        //        foreach (Transform item in obj.transform)
        //        {
        //            SetSnowEffect(item.gameObject);
        //        }
        //    }
        //}

        //public static void SetEnableActiveFunc(this GameObject go, Action enable_func, Action disable_func)
        //{
        //    go.GetOrAddComponect<Enable_Active_Func>().SetEnableActiveFunc(enable_func, disable_func);
        //}
        //public static void SetEnableActiveFunc(this Transform go, Action enable_func, Action disable_func)
        //{
        //    go.GetOrAddComponect<Enable_Active_Func>().SetEnableActiveFunc(enable_func, disable_func);
        //}
        //public static void SetEnterExitFunc(this Transform tra,Action enterFunc,Action exitFunc = null)
        //{
        //    tra.GetOrAddComponect<EnterFunc>().SetEnterExitFunc(enterFunc,exitFunc);
        //}
        //public static void SetEnterExitFunc(this GameObject tra, Action enterFunc, Action exitFunc = null)
        //{
        //    tra.GetOrAddComponect<EnterFunc>().SetEnterExitFunc(enterFunc, exitFunc);
        //}
        public static void SetChildsBoxColliderEnable<T>(this T t, bool enable = true) where T : Component
        {
            BoxCollider[] colliders = t.GetComponentsInChildren<BoxCollider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = enable;
            }
        }

        //public static void SetUIEnterExitFunc<T>(this T t, Action enterFunc, Action exitFunc) where T : Graphic
        //{
        //    t.transform.GetOrAddComponect<UIMouseEnterFunc>().SetEnterExitFunc(enterFunc, exitFunc);
        //}

        //public static void SetUIDownUpFunc<T>(this T t, Action downFunc, Action upFunc) where T : Graphic
        //{
        //    t.transform.GetOrAddComponect<UIMouseEnterFunc>().SetDownUpFunc(downFunc, upFunc);
        //}

        //public static void SceneGradualChange(this Camera c)
        //{
        //    SlowRed slowRed = c.transform.GetOrAddComponect<SlowRed>();
        //    slowRed.enabled = false;
        //    slowRed.enabled = true;
        //}


        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        public static string GetParentDic(string path)
        {
            string[] str = path.Split('/');
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length-1; i++)
            {
                builder.Append(str[i]+"/");
            }

            return builder.ToString();
        }
//        public static SingleXmlInfo GetConfigInfoByAccidentType(AccidentType accident)
//        {

//            //AssetBundle bundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath+"/configs");          
//            //TextAsset info = bundle.LoadAsset<TextAsset>(accident.ToString() + ".xml") /*Resources.Load<TextAsset>("Configs/" + accident.ToString() + ".xml")*/;

//            string path = GetParentDic(Application.dataPath);
//#if UNITY_EDITOR
//            path = Application.dataPath+ "/";
//#endif
//            path += "Configs/"+ accident.ToString() + ".xml";
//            if (!File.Exists(path))
//            {
//                Debug.LogError("错误路径："+path);
//                return null;
//            }
//            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
//            //MemoryStream stream = new MemoryStream(info.bytes);
//            XmlSerializer serializer = new XmlSerializer(typeof(SingleXmlInfo));

//            SingleXmlInfo infos = (SingleXmlInfo)serializer.Deserialize(stream);
//            stream.Close();
//            if (infos == null)
//            {
//                Debug.LogError("无法获取的数据："+path);
//            }

//            return infos;
//        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        //public static void Serializer(SingleXmlInfo obj, string fileName)
        //{
        //    FileStream Stream = new FileStream(Application.dataPath + "/Configs/" + fileName + ".xml", FileMode.Create, FileAccess.ReadWrite);
        //    //MemoryStream Stream = new MemoryStream();
        //    StreamWriter sw = new StreamWriter(Stream, Encoding.UTF8);
        //    XmlSerializer xml = new XmlSerializer(obj.GetType());
        //    try
        //    {
        //        //序列化对象
        //        xml.Serialize(sw, obj);
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        throw;
        //    }
        //    sw.Close();
        //    Stream.Close();
        //}

        //public static void SerializeStartPanelDicToXml()
        //{
        //    AccidentType accident = AccidentType.桥梁坠落;
        //    int questionNum = 0;
        //    List<string> questions = new List<string>();
        //    List<string> questionTitles = new List<string>();
        //    List<int> questionAnsers = new List<int>();
        //    string dic_key = accident.ToString() + (questionNum + 1);
        //    Debug.Log("大哥哥 "+ dic_key.LogPink()+ "是否存在"+ Consts.QuestionsDic.ContainsKey(dic_key));
        //    while (Consts.QuestionsDic.ContainsKey(dic_key))
        //    {

        //        string[] infos = Consts.QuestionsDic[dic_key];
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < infos.Length; i++)
        //        {
        //            string final = (i == infos.Length - 1) ? "" : "|";
        //            builder.Append(infos[i] + final);
        //        }
        //        questions.Add(builder.ToString());

        //        questionTitles.Add(Consts.QuestionTitleDic[dic_key]);

        //        questionAnsers.Add(Consts.QuestionAnserDic[dic_key]);
        //        questionNum++;
        //        dic_key = accident.ToString() + (questionNum + 1);
        //    }
        //    SingleXmlInfo xmlInfo = new SingleXmlInfo()
        //    {
        //        accidentType = accident,
        //        startPanelInfoList = Consts.StartPanelDic[accident],
        //        causeOfDeath = Consts.CauseOfDeathDic[accident],
        //        questionList = questions.ToArray(),

        //        questionAnserList = questionAnsers.ToArray(),

        //        questionTitleList = questionTitles.ToArray()
        //    };

        //    Serializer(xmlInfo, accident.ToString());
        //    Debug.Log(accident.ToString().LogGreen() + ".xml输出完毕".LogPink());
        //}

        #endregion
    }
