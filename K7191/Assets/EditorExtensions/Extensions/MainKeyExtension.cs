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
using UnityEngine;
using UnityEngine.UI;

public static class MainKeyExtension
{
    #region C#扩展
    public static bool IsNullOrWhiteSpace(this string info)
    {
        return info == null || info.Replace(" ", "") == "";
    }

    public static string IgnoreSpecialCode(this string info)
    {
        return info.Replace(" ", "_").Replace("(", "").Replace(")", "");
    }
    public static string GetParentPath(this string path)
    {
        string[] arr = path.Split('/');
        string parentPath = "";
        for (int i = 0; i < arr.Length - 1; i++)
        {
            parentPath += arr[i] + "/";
        }

        return parentPath;
    }
    public static bool Contains<T>(this T[] arr, T key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Equals(key))
            {
                return true;
            }
        }
        return false;
    }
    #endregion

    #region 工具函数
    public static float RandValue(this float t, float min = 0)
    {
        return UnityEngine.Random.Range(min, t);
    }
    public static int RandValue(this int t, int min = 0)
    {
        return UnityEngine.Random.Range(min, t);
    }

    public static void ToLocalOrigi<T>(this T t, bool scaleToOne = true) where T : Component
    {
        t.transform.ToLocalOrigi(scaleToOne);
    }
    public static void ToLocalOrigi(this Transform t, bool scaleToOne = true)
    {
        t.localPosition = Vector3.zero;
        t.localEulerAngles = Vector3.zero;
        if (scaleToOne)
        {
            t.localScale = Vector3.one;
        }
    }
    public static void ToLocalOrigi(this GameObject t, bool scaleToOne = true)
    {
        t.transform.ToLocalOrigi(scaleToOne);
    }
    public static void Hide<T>(this T t) where T : Component
    {
        t.SetActive(false);
    }
    public static void Hide(this GameObject t)
    {
        t.SetActive(false);
    }
    public static void Show(this GameObject t)
    {
        t.SetActive(true);
    }
    public static void Show<T>(this T t) where T : Component
    {
        t.SetActive();
    }
    public static void SetActive<T>(this T t, bool active = true) where T : Component
    {
        t.gameObject.SetActive(active);
    }

    public static void AddClickFun<T>(this T t, Action func) where T : Graphic
    {
        //t.gameObject.GetOrAddComponect<Button>().onClick.AddListener(()=> { func.Do(); });
    }
    public static void AddClickFun(this Transform t, Action func)
    {
        //t.GetOrAddComponect<Button>().onClick.AddListener(() => { func.Do(); });
    }
    public static void AddClickFun(this GameObject t, Action func)
    {
        //t.GetOrAddComponect<Button>().onClick.AddListener(() => { func.Do(); });
    }
    public static void SetText<T>(this Text txt, T info)
    {
        txt.text = info.ToString();
    }
    public static void SetText<T, W>(this W component, T info) where W : Component
    {
        Text txt = component.gameObject.GetComponent<Text>();
        if (txt == null)
        {
            if (component.GetComponent<Graphic>())
            {
                Debug.Log("无法给" + component.gameObject.name.LogYellow() + " 添加Text脚本！SetText失败！");
                return;
            }
            txt = component.gameObject.GetOrAddComponect<Text>();
            txt.SetText(info);
        }
        else
        {
            txt.SetText(info);
        }
    }

    #region 物理组件
    public static Rigidbody GetRigidbody<T>(T t) where T : Component
    {
        return t.GetComponent<Rigidbody>();
    }
    public static Rigidbody GetRigidbody(GameObject t)
    {
        return t.GetComponent<Rigidbody>();
    }
    public static BoxCollider GetBoxCollider<T>(T t) where T : Component
    {
        return t.GetComponent<BoxCollider>();
    }
    public static BoxCollider GetBoxCollider(GameObject t)
    {
        return t.GetComponent<BoxCollider>();
    }
    public static MeshRenderer GetMeshRenderer<T>(T t) where T : Component
    {
        return t.GetComponent<MeshRenderer>();
    }
    public static MeshRenderer GetMeshRenderer(GameObject t)
    {
        return t.GetComponent<MeshRenderer>();
    }
    #endregion

    #region Button Text CanvasGroup
    public static void Hide(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
    public static void Show(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    public static CanvasGroup GetCanvasGroup<T>(this T t) where T : Component
    {
        return t.GetComponent<CanvasGroup>();
    }
    public static CanvasGroup GetCanvasGroup(this GameObject t)
    {
        return t.GetComponent<CanvasGroup>();
    }
    public static Button GetButton<T>(this T t) where T : Component
    {
        return t.GetComponent<Button>();
    }
    public static Button GetButton(this GameObject t)
    {
        return t.GetComponent<Button>();
    }
    public static Text GetText<T>(this T t) where T : Component
    {
        return t.GetComponent<Text>();
    }
    public static Text GetText(this GameObject t)
    {
        return t.GetComponent<Text>();
    }

    #endregion

    #region RectTransform相关
    public static RectTransform GetRectTansform<T>(this T t) where T : Component
    {
        return t.GetComponent<RectTransform>();
    }
    public static RectTransform GetRectTransform(this GameObject obj)
    {
        return obj.GetComponent<RectTransform>();
    }
    public static void SetRectHeight(this RectTransform rect, float height)
    {
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, height);
    }
    public static void SetRectWidth(this RectTransform rect, float width)
    {
        rect.sizeDelta = new Vector2(width, rect.sizeDelta.y);
    }
    #endregion

    #region Transform
    public static void SetEulerAnglesX(this Transform trans, float angle)
    {
        trans.eulerAngles = new Vector3(angle, trans.eulerAngles.y, trans.eulerAngles.z);
    }
    public static void SetEulerAnglesY(this Transform trans, float angle)
    {
        trans.eulerAngles = new Vector3(trans.eulerAngles.x, angle, trans.eulerAngles.z);
    }
    public static void SetEulerAnglesZ(this Transform trans, float angle)
    {
        trans.eulerAngles = new Vector3(trans.eulerAngles.x, trans.eulerAngles.y, angle);
    }
    public static void SetLocalEulerAnglesX(this Transform trans, float angle)
    {
        trans.localEulerAngles = new Vector3(angle, trans.localEulerAngles.y, trans.localEulerAngles.z);
    }
    public static void SetLocalEulerAnglesY(this Transform trans, float angle)
    {
        trans.localEulerAngles = new Vector3(trans.localEulerAngles.x, angle, trans.localEulerAngles.z);
    }
    public static void SetLocalEulerAnglesZ(this Transform trans, float angle)
    {
        trans.localEulerAngles = new Vector3(trans.localEulerAngles.x, trans.localEulerAngles.y, angle);
    }
    #endregion

    public static T Clone<T>(this T originalObj, Transform parent = null) where T : UnityEngine.Object
    {
        return UnityEngine.Object.Instantiate(originalObj, parent);
    }
    /// <summary>
    /// 获取或者添加组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="go">目标物体</param>
    /// <returns></returns>
    public static T GetOrAddComponect<T>(this GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();
        if (t == null)
        {
            t = go.AddComponent<T>();
        }
        return t;
    }

    public static T GetOrAddComponect<T>(this Transform w) where T : Component
    {
        return w.gameObject.GetOrAddComponect<T>();
    }

    public static BoxCollider SetXRUIBox<T>(this T graphic) where T : Component
    {
        BoxCollider collider = graphic.gameObject.GetOrAddComponect<BoxCollider>();
        RectTransform rectTrans = graphic.gameObject.GetOrAddComponect<RectTransform>();
        collider.size = new Vector3(rectTrans.rect.width, rectTrans.rect.height, 1f);

        return collider;
    }
    #endregion
    /// <summary>
    /// 延时执行方法
    /// </summary>
    /// <param name="t">延时时间</param>
    /// <param name="Func">最后执行的方法</param>
    /// <returns></returns>
    public static IEnumerator WaitSomeSecondDo(this float t, Action Func)
    {
        yield return new WaitForSeconds(t);
        if (Func != null)
        {
            Func.Invoke();
        }
    }

    #region UI子物体渲染在最上层
    public static void SetAllChildUIRenderAtLast<T>(this T trans) where T : Component
    {
        Material overlay = Resources.Load<Material>("Materials/Overlay");
        if (overlay)
        {
            Graphic[] childs = trans.GetComponentsInChildren<Graphic>(true);
            foreach (var item in childs)
            {
                item.material = overlay;
            }

            Debug.Log("子UI层级渲染层级设定完毕！".LogGreen());
        }
    }
    #endregion

    #region 移动扩展
    public static void MoveLocalPosX<T>(this T trans, float value) where T : Component
    {
        trans.transform.localPosition += new Vector3(value, 0, 0);
    }
    public static void MoveLocalPosY<T>(this T trans, float value) where T : Component
    {
        trans.transform.localPosition += new Vector3(0, value, 0);
    }
    public static void MoveLocalPosZ<T>(this T trans, float value) where T : Component
    {
        trans.transform.localPosition += new Vector3(0, 0, value);
    }
    public static void MovePosX<T>(this T trans, float value) where T : Component
    {
        trans.transform.position += new Vector3(value, 0, 0);
    }
    public static void MovePosY<T>(this T trans, float value) where T : Component
    {
        trans.transform.position += new Vector3(0, value, 0);
    }
    public static void MovePosZ<T>(this T trans, float value) where T : Component
    {
        trans.transform.position += new Vector3(0, 0, value);
    }

    public static void SetLocalPosX<T>(this T trans, float value) where T : Component
    {
        trans.transform.localPosition = new Vector3(value, trans.transform.localPosition.y, trans.transform.localPosition.z);
    }
    public static void SetLocalPosY<T>(this T trans, float value) where T : Component
    {
        trans.transform.localPosition = new Vector3(trans.transform.localPosition.x, value, trans.transform.localPosition.z);
    }
    public static void SetLocalPosZ<T>(this T trans, float value) where T : Component
    {
        trans.transform.localPosition = new Vector3(trans.transform.localPosition.x, trans.transform.localPosition.y, value);
    }

    public static void SetPosX<T>(this T trans, float value) where T : Component
    {
        trans.transform.position = new Vector3(value, trans.transform.position.y, trans.transform.position.z);
    }
    public static void SetPosY<T>(this T trans, float value) where T : Component
    {
        trans.transform.position = new Vector3(trans.transform.position.x, value, trans.transform.position.z);
    }
    public static void SetPosZ<T>(this T trans, float value) where T : Component
    {
        trans.transform.position = new Vector3(trans.transform.position.x, trans.transform.position.y, value);
    }
    #endregion

    #region 音频操作
    public static void MuteObjAudio<T>(this T trans) where T : Component
    {
        AudioSource[] source = trans.GetComponents<AudioSource>();
        for (int i = 0; i < source.Length; i++)
        {
            source[i].Stop();
        }
    }

    public static void MuteObjAudio(this GameObject trans)
    {
        AudioSource[] source = trans.GetComponents<AudioSource>();
        for (int i = 0; i < source.Length; i++)
        {
            source[i].Stop();
        }
    }
    #endregion

    #region 文字颜色工具
    /// <summary>
    /// 给文字添加颜色码
    /// </summary>
    /// <param name="info"></param>
    /// <param name="colorType"></param>
    /// <returns></returns>
    public static string ColorText(this string info, ColorType colorType = ColorType.RandColor)
    {
        return "<color=#" + GetColorCodeByColorType(colorType) + ">" + info + "</color>";
    }
    public static string LogColor(this string info, string color)
    {
        return "<color=#" + color + ">" + info + "</color>";
    }
    public static string LogRed(this string info)
    {
        return ColorText(info, ColorType.Red);
    }
    public static string LogGreen(this string info)
    {
        return ColorText(info, ColorType.Green);
    }
    public static string LogBlue(this string info)
    {
        return ColorText(info, ColorType.Blue);
    }
    public static string LogGray(this string info)
    {
        return ColorText(info, ColorType.Gray);
    }
    public static string LogCyan(this string info)
    {
        return ColorText(info, ColorType.Cyan);
    }
    public static string LogYellow(this string info)
    {
        return ColorText(info, ColorType.Yellow);
    }
    public static string LogPink(this string info)
    {
        return ColorText(info, ColorType.Pink);
    }
    public static string LogOrange(this string info)
    {
        return ColorText(info, ColorType.Orange);
    }
    public static string LogPurple(this string info)
    {
        return ColorText(info, ColorType.Purple);
    }
    public static string GetColorCodeByColorType(ColorType colorType)
    {
        return colorType != ColorType.RandColor ? ColorConsts.colorDic[colorType] : GetColorCodeByColorType((ColorType)UnityEngine.Random.Range(0, (int)colorType));
    }
    public static string LogBow(this string info)
    {
        int color = UnityEngine.Random.Range(0, 8);
        //int length = info.Length;
        string bow = "";
        char[] arr = info.ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            bow += ColorText(arr[i].ToString(), (ColorType)color);
            color++;
            color = color > (int)ColorType.RandColor ? 0 : color;
        }

        return bow;
    }
    public static string LogRandBow(this string info)
    {
        int maxIndex = (int)ColorType.RandColor;
        int color = UnityEngine.Random.Range(0, maxIndex);
        //int length = info.Length;
        string bow = "";
        char[] arr = info.ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            bow += ColorText(arr[i].ToString(), (ColorType)color);
            int next = UnityEngine.Random.Range(0, maxIndex);
            while (next == color)
            {
                next = UnityEngine.Random.Range(0, maxIndex);
            }
            color = next;
        }

        return bow;
    }
    #endregion

#if UNITY_2017_4_40
        public static void Do(this Action func)
        {
            if (func!=null)
            {
                func.Invoke();
            }
        }
        public static void Do<T>(this Action<T> func,T t)
        {
            if (func != null)
            {
                func.Invoke(t);
            }
        }
        public static void Do<T,W>(this Action<T,W> func, T t,W w)
        {
            if (func != null)
            {
                func.Invoke(t,w);
            }
        }
#endif
}
public class ColorConsts
{
    public static Dictionary<ColorType, string> colorDic = new Dictionary<ColorType, string>() {
            {ColorType.Red,"FF0000" },
            { ColorType.Orange,"F5721C" },
            { ColorType.Yellow,"FFFF00" },
            { ColorType.Green,"00FF00" },
            { ColorType.Blue,"0000FF" },
            { ColorType.Cyan,"00FFFF" },
            { ColorType.Pink,"F51BE9" },
            { ColorType.Purple,"5C00DE" },
            {ColorType.Gray,"5C5C5CFF" },
        };
}
public enum ColorType
{
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Cyan,
    Pink,
    Purple,
    Gray,
    RandColor,
}

