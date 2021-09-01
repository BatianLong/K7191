using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;//����socket�����ռ�
using System.Threading;
using System.Text;
using UnityEngine.SceneManagement;

public class Client : MonoBehaviour
{
    //����������ť���ڷ������ݺ͹ر�����
    public Button sen;
    public Button col;
    public Button con;
    //�����ı�
    public InputField inputText;
    // Start is called before the first frame update
    void Start()
    {
        MessageText = GameObject.Find("MessageText").GetComponent<Text>();
        sen.onClick.AddListener(send_smg);//����
        col.onClick.AddListener(close_btnClick);//�ر�
        con.onClick.AddListener(ConnectServer);//����
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
    /// ���ӷ�����
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
            OnSendMessage("���ӳɹ�");
            //�����̣߳�ִ�ж�ȡ��������Ϣ
            Thread c_thread = new Thread(Received);
            c_thread.IsBackground = true;
            c_thread.Start();
        }
        catch (System.Exception)
        {

            OnSendMessage("IP�˿ںŴ�����߷�����δ����");
        }
    }
    /// <summary>
    /// ��ȡ��������Ϣ
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
    /// ������Ϣ
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

            OnSendMessage("δ����");
        }
    }
    /// <summary>
    /// �ر�����
    /// </summary>
    public static void close()
    {
        try
        {
            socket_client.Close();
            OnSendMessage("�رտͻ�������");
            SceneManager.LoadScene("control");
        }
        catch (System.Exception)
        {
            OnSendMessage("δ����");
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