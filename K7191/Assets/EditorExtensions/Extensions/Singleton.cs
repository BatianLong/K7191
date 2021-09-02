/***
 *
 *         Title:编辑器扩展学习
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

    public class Singleton<T> : MonoBehaviour where T:Singleton<T>
   {
        private static T singleton;
       public static T Instance
        {
            get{
                if (singleton == null)
                {
                    singleton = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        for (int i = 0; i < FindObjectsOfType<T>().Length; i++)
                        {
                            print("存在多个单例：" + FindObjectsOfType<T>()[i].name.LogPink());
                        }
                    }

                    if (singleton == null)
                    {
                        string _name = typeof(T).Name;
                        GameObject obj = GameObject.Find(_name) ? GameObject.Find(_name) : new GameObject(_name);
                        singleton  = obj.GetOrAddComponect<T>();
                       // print("???执行了錒？".LogRed());
//#if !UNITY_EDITOR
                        DontDestroyOnLoad(obj);
//#endif
                    }

                }

                return singleton;
            }
        }
        protected virtual void OnDestroy()
        {
            singleton = null;
        }
   }