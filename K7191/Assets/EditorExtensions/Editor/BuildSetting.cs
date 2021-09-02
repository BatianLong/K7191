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
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using System.IO;

    public class BuildSetting : Editor
   {
        [PostProcessBuild(1)]
       public static void AfterBuild(BuildTarget target,string pathToBuildProject)
        {
            Debug.Log(("Build Success" + target +" "+pathToBuildProject).LogGreen());
            string filePath = Application.dataPath + "/";
            Debug.Log(("看下路径：" + filePath).LogGreen());

            string BuildFilesPath = GetParentPath(pathToBuildProject);
            string AssetsFilePath = filePath + "Configs";

            CopyFolder(AssetsFilePath, BuildFilesPath);

            if (target == BuildTarget.StandaloneWindows64)
            {
    
            }
            Debug.Log(("target:"+target.ToString()).LogCyan());
        }

        private static void CopyFolder(string source,string dest)
        {
            try
            {
                string folderName = Path.GetFileName(source);
                string destFolderDir = Path.Combine(dest, folderName);
                string[] fileNames = Directory.GetFileSystemEntries(source);
                foreach (string file in fileNames)
                {
                   
                    if (Directory.Exists(file))
                    {
                        string curDir = Path.Combine(destFolderDir, Path.GetFileName(file));
                        if (!Directory.Exists(curDir))
                        {
                            Directory.CreateDirectory(curDir);
                        }
                        CopyFolder(file, destFolderDir);
                    }
                    else
                    {
                        string srcFileName = Path.Combine(destFolderDir, Path.GetFileName(file));
                        if (!Directory.Exists(destFolderDir))
                        {
                            Directory.CreateDirectory(destFolderDir);
                        }
                        if (Path.GetExtension(file) != ".meta")
                        {
                            File.Copy(file, srcFileName,true);
                        }
                    }
                }
    
            }
            catch (System.Exception)
            {

                Debug.LogError("克隆文件夹失败！".LogPink());
            }
        }

        private static string GetParentPath(string path)
        {
            string[] arr = path.Split('/');
            string parentPath = "";
            for (int i = 0; i < arr.Length-1; i++)
            {
                parentPath += arr[i] + "/";
            }

            return parentPath;
        }
   }
