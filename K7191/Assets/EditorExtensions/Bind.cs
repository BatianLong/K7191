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
using UnityEngine.UI;

public class Bind : MonoBehaviour
{
    public string NodeName;
    public string ComponentName
    {
        get
        {
            if (GetComponent<Button>())
            {
                return "Button";
            }
            if (GetComponent<Image>())
            {
                return "Image";
            }
            if (GetComponent<Button>())
            {
                return "Button";
            }
            if (GetComponent<Text>())
            {
                return "Text";
            }
            if (GetComponent<InputField>())
            {
                return "InputField";
            }

            return "Transform";
        }
    }
}