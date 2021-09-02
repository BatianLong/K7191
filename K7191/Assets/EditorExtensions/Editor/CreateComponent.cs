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

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

    public class CreateComponent : Editor
    {
        [MenuItem(itemName: "GameObject/@(Ctrl+Alt+M)Create Code &x")]
        public static void CreateCode()
        {
            GameObject selectObj = (GameObject)Selection.objects.First();
            if (selectObj == null)
            {
                Debug.Log("当前选择的物体为空！自动代码生成失败".LogYellow());
                return;
            }

            var bindInfos = new List<BindInfo>();
            //var binds = selectObj.GetComponentsInChildren<Bind>();

            //Type type = 
            if (CheckNodes(selectObj, bindInfos))
            {
                return;
            }
            if (hasSameNode)
            {
                Debug.Log(("自动代码生成失败！").LogRed());
                return;
            }
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Debug.Log(UtilFuncs.ColorText(list[i].findPath));
            //}

            string path = Application.dataPath + "/Scripts";

            PathDefine pathDefine = selectObj.GetComponent<PathDefine>();
            if (pathDefine)
            {
                path = pathDefine.ScriptsPath;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + "/" + selectObj.name + ".cs"))
            {
                StreamWriter writer = File.CreateText(path + "/" + selectObj.name + ".cs");
                UtilFuncs.WriteCodeMainTemp(writer, selectObj.name);
                writer.Close();
            }
            //Debug.Log(UtilFuncs.LogCyan("点到人家了"));
            StreamWriter stream = File.CreateText(path + "/" + selectObj.name + ".Designer.cs");

            UtilFuncs.WriteCodeTemplate(stream, selectObj.name, bindInfos);
            stream.Close();
            EditorPrefs.SetString("GENERATE_CLASS_NAME", selectObj.name);

            AssetDatabase.Refresh();

        }
        static List<string> m_nodeNameList = new List<string>();
        static bool hasSameNode = false;
        static void SearchBinds(string basePath, Transform transform, List<BindInfo> binds)
        {
            Bind bind = transform.GetComponent<Bind>();
            if (bind != null && !(basePath.IsNullOrWhiteSpace()))
            {
                string Name = bind.NodeName == "" ? transform.name : bind.NodeName;
                if (m_nodeNameList.Contains(Name))
                {
                    Debug.Log("存在相同名称的Node：" + Name.LogPink() + "\n路径：" + basePath.ColorText());
                    hasSameNode = true;
                    return;
                }
                binds.Add(new BindInfo()
                {
                    findPath = basePath,
                    Name = Name,
                    ComponentName = bind.ComponentName
                });

                m_nodeNameList.Add(Name);
            }

            foreach (Transform trans in transform)
            {
                SearchBinds((basePath.IsNullOrWhiteSpace() ? basePath : (basePath + "/")) + trans.name, trans, binds);
            }

        }

        [MenuItem(itemName: "GameObject/@(Ctrl+G)AddScriptsPathDefine %g")]
        static void AddScriptsPathDefine()
        {
            if (Selection.objects.Length == 0)
            {
                return;
            }
            GameObject go = (GameObject)Selection.objects.First();
            go.GetOrAddComponect<PathDefine>();
        }

        [MenuItem(itemName: "GameObject/@(Ctrl+Q)AddBind %q")]
        static void AddBind()
        {
            if (Selection.objects.Length == 0)
            {
                return;
            }
            foreach (var item in Selection.objects)
            {
                GameObject go = (GameObject)item;
                Bind bind = go.GetOrAddComponect<Bind>();
                bind.NodeName = go.name.IgnoreSpecialCode();
            }
        }

        [MenuItem(itemName: "编辑器扩展/重启项目 &r")]
        static void ReOpenProject()
        {
            EditorApplication.OpenProject(Application.dataPath.Replace("Assets", string.Empty));
        }

        [DidReloadScripts]
        static void AddComponentToObj()
        {
            // Debug.Log("她执行了！");
            string generateClassName = EditorPrefs.GetString("GENERATE_CLASS_NAME");
            // Debug.Log("generateClassName" + generateClassName);
            EditorPrefs.DeleteKey("GENERATE_CLASS_NAME");

            if (!(generateClassName == null || generateClassName.Replace(" ", "") == ""))
            {
                GameObject selectObj = null;
                if (Selection.objects.Count() != 0)
                {
                    selectObj = (GameObject)Selection.objects.First();
                    if (selectObj == null)
                    {
                        return;
                    }
                }
                //Debug.Log(UtilFuncs.LogGreen("继续操作？"));

                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                var defaultAssembly = assemblies.First(assembly => assembly.GetName().Name == "Assembly-CSharp");
                //Debug.Log(defaultAssembly);
                //Debug.Log(UtilFuncs.ColorText("TyoeName??: "+_typeName));
                var _type = defaultAssembly.GetType(generateClassName);

                if (_type != null)
                {
                    //Debug.Log(UtilFuncs.LogRed("看看Type:"+_type.ToString()));
                    string path = Consts.DefaultScriptsPath;

                    GameObject obj = GameObject.Find(generateClassName);
                    Component has = obj.GetComponent(_type);
                    if (has != null)
                    {
                        SerializedObject hasobj = new SerializedObject(has);
                        path = hasobj.FindProperty("ScriptsPath").stringValue;
                        DestroyImmediate(has);
                    }
                    PathDefine pathdefine = obj.GetComponent<PathDefine>();

                    Component component = obj.AddComponent(_type);

                    SerializedObject serializedObject = new SerializedObject(component);
                    List<BindInfo> bindInfos = new List<BindInfo>();
                    if (CheckNodes(selectObj, bindInfos))
                    {
                        return;
                    }

                    foreach (BindInfo item in bindInfos)
                    {
                        string name = item.Name.IgnoreSpecialCode();
                        serializedObject.FindProperty(name).objectReferenceValue =
                            selectObj.transform.Find(item.findPath).GetComponent(item.ComponentName);
                    }


                    if (pathdefine)
                    {
                        path = pathdefine.ScriptsPath;
                        DestroyImmediate(pathdefine);
                    }
                    serializedObject.FindProperty("ScriptsPath").stringValue = path;

                    serializedObject.ApplyModifiedPropertiesWithoutUndo();
                }
                else
                {
                    Debug.Log("未能找到程序集引用？是否未添加命名空间？".LogRed());
                }

            }
            else
            {
                // Debug.Log(UtilFuncs.LogYellow("不行了。。。"));
            }
        }

        static bool CheckNodes(GameObject selectObj, List<BindInfo> bindInfos)
        {
            hasSameNode = false;
            m_nodeNameList.Clear();
            SearchBinds("", selectObj.transform, bindInfos);
            if (hasSameNode)
            {
                Debug.Log("自动代码生成失败！".LogRed());
            }

            return hasSameNode;
        }
    }
