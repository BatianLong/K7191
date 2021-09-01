using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;//引入socket命名空间
using System.Threading;
using System.Text;
using UnityEngine.SceneManagement;

public class Client : MonoBehaviour
{
    //添加两个按钮用于发送数据和关闭连接
    public Button sen;
    public Button col;
    public Button con;
    //输入文本
    public InputField inputText;
    // Start is called before the first frame update
    void Start()
    {
        MessageText = GameObject.Find("MessageText").GetComponent<Text>();
        sen.onClick.AddListener(send_smg);//发送
        col.onClick.AddListener(close_btnClick);//关闭
        con.onClick.AddListener(ConnectServer);//发送
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void send_smg()
    {
        Send(inputText.text);
    }
    public void close_btnClick()
    {
        close();
    }

    /// <summary>
    /// 连接服务器
    /// </summary>
    static Socket socket_client;
    public static void ConnectServer()
    {
        try
        {
            IPAddress pAddress = IPAddress.Parse("121.4.132.26");
            IPEndPoint pEndPoint = new IPEndPoint(pAddress, 3333);
            socket_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket_client.Connect(pEndPoint);
            OnSendMessage("连接成功");
            //创建线程，执行读取服务器消息
            Thread c_thread = new Thread(Received);
            c_thread.IsBackground = true;
            c_thread.Start();
        }
        catch (System.Exception)
        {

            OnSendMessage("IP端口号错误或者服务器未开启");
        }
    }
    /// <summary>
    /// 读取服务器消息
    /// </summary>
    public static void Received()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int len = socket_client.Receive(buffer);
                if (len == 0) break;
                string str = Encoding.UTF8.GetString(buffer, 0, len);
                MessagePanel.Instance.Log.Append(str + "\n");
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msg"></param>
    public static void Send(string msg)
    {
        try
        {
            byte[] buffer = new byte[1024];
            Debug.Log("SendMessage:"+ msg);
            buffer = Encoding.UTF8.GetBytes(msg);
            socket_client.Send(buffer);
        }
        catch (System.Exception)
        {

            OnSendMessage("未连接");
        }
    }
    /// <summary>
    /// 关闭连接
    /// </summary>
    public static void close()
    {
        try
        {
            socket_client.Close();
            OnSendMessage("关闭客户端连接");
            SceneManager.LoadScene("control");
        }
        catch (System.Exception)
        {
            OnSendMessage("未连接");
        }
    }
    public static Text MessageText;
    static void OnSendMessage(string msg)
    {
        MessageText.text = msg;
        Debug.Log(msg); 
        MessagePanel.Instance.Log.Append(msg + "\n");
    }
}