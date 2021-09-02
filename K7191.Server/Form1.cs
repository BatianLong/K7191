using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.Forms;

namespace K7191.Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }//存储已连接的客户端的泛型集合
        private static Dictionary<string, Socket> socketList = new Dictionary<string, Socket>();

        Socket recviceSocket = null;
        /// <summary>
        /// 接收连接
        /// </summary>
        /// <param name="obj"></param>
        public void StartServer(object obj)
        {
            string str;
            while (true)
            {
                //等待接收客户端连接 Accept方法返回一个用于和该客户端通信的Socket
                recviceSocket = ((Socket)obj).Accept();
                //获取客户端ip和端口号
                str = recviceSocket.RemoteEndPoint.ToString();
                socketList.Add(str, recviceSocket);
                //控件调用invoke方法 解决"从不是创建控件的线程访问它"的异常
                cmb_socketlist.Invoke(new Action(() => { cmb_socketlist.Items.Add(str); }));
                richTextBox1.Invoke(new Action(() => { OnAppendText(str + "已连接"); }));

                //Accept()执行过后 当前线程会阻塞 只有在有客户端连接时才会继续执行
                //创建新线程,监控接收新客户端的请求数据
                Thread thread = new Thread(startRecive);
                thread.IsBackground = true;
                thread.Start(recviceSocket);
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="obj">客户端socket</param>
        public void startRecive(object obj)
        {
            string str;
            string ip;
            while (true)
            {

                byte[] buffer = new byte[2048];
                int count;
                try
                {
                    //Receive(Byte[]) 从绑定的 Socket 套接字接收数据，将数据存入接收缓冲区。
                    //该方法执行过后同Accept()方法一样  当前线程会阻塞 等到客户端下一次发来数据时继续执行
                    count = ((Socket)obj).Receive(buffer);
                    ip = ((Socket)obj).RemoteEndPoint.ToString();
                    if (count == 0)
                    {
                        cmb_socketlist.Invoke(new Action(() => { cmb_socketlist.Items.Remove(ip); }));
                        richTextBox1.Invoke(new Action(() => { OnAppendText(ip + "已断开连接"); }));
                        break;
                    }
                    else
                    {
                        str = Encoding.UTF8.GetString(buffer, 0, count);
                        richTextBox1.Invoke(new Action(() => { OnAppendText("收到" + ip + "数据  " + str); }));
                        MessageCenter message = new MessageCenter();
                        message.OnDisposeCode(str, ip);
                        SendMessageToAll(ip+":"+ str);

                    }
                }
                catch (Exception)
                {


                }
            }
        }

        /// <summary>
        /// 开启服务器监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartListen_Click(object sender, EventArgs e)
        {
            //实例化一个Socket对象，确定网络类型、Socket类型、协议类型
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint IEP = new IPEndPoint(IPAddress.Parse(txt_ip.Text), int.Parse(txt_port.Text));
            //绑定ip和端口
            socket.Bind(IEP);
            //开启监听
            socket.Listen(10);

            richTextBox1.Invoke(new Action(() => { OnAppendText("开始监听"); }));

            Thread thread = new Thread(new ParameterizedThreadStart(StartServer));
            thread.IsBackground = true;
            thread.Start(socket);


            #region 该部分实现只适用一个服务器只对应一个客户端

            //Task.Run(() => {

            //        string str;

            //        while (true)
            //        {
            //            //等待接收客户端连接 Accept返回一个用于和该客户端通信的Socket
            //           Socket recviceSocket = socket.Accept();

            //            //Accept()执行过后 当前线程会暂时挂起 只有在有客户端连接时才会继续执行
            //            richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText(recviceSocket.RemoteEndPoint.ToString() + "已连接" + "\r\n"); }));

            //            //开启接收数据的任务
            //            Task.Run(() => {
            //                while (true)
            //                {
            //                    byte[] buffer = new byte[2048];
            //                    int count;
            //                     //Receive(Byte[]) 从绑定的 Socket 套接字接收数据，将数据存入接收缓冲区。
            //                    //该方法执行过后同上  当前线程会暂时挂起 等到客户端下一次发来数据时继续执行
            //                    count = recviceSocket.Receive(buffer);
            //                    if (count == 0)
            //                    {
            //                        richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText(recviceSocket.RemoteEndPoint.ToString() + "已断开连接" + "\r\n"); }));

            //                        break;
            //                    }
            //                    else
            //                    {
            //                        str = Encoding.Default.GetString(buffer, 0, count);
            //                        richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText("收到"+recviceSocket.RemoteEndPoint.ToString()+"数据:" + str + "\r\n"); }));

            //                    }
            //                }


            //            });


            //        }
            //});
            #endregion
        }

        /// <summary>
        /// 向对应所有发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sendToAll_Click(object sender, EventArgs e)
        {
            string str = txt_send.Text;
            SendMessageToAll(str);
            txt_send.Clear();
        }

        private void SendMessageToAll(string msg)
        {
            byte[] bytes = new byte[2048];
            bytes = Encoding.UTF8.GetBytes(msg);
            recviceSocket.Send(bytes);
        }

        /// <summary>
        /// 向对应客户端发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_send_Click(object sender, EventArgs e)
        {
            string str = txt_send.Text;
            byte[] bytes = new byte[2048];
            bytes = Encoding.UTF8.GetBytes(str);
            //获取combobox的值 从泛型集合中获取对应的客户端socket 然后发送数据
            if (cmb_socketlist.Items.Count != 0)
            {
                if (cmb_socketlist.SelectedItem == null)
                {
                    OnAppendText("请选择一个客户端发送数据!");
                    return;
                }
                else
                {
                    socketList[cmb_socketlist.SelectedItem.ToString()].Send(bytes);
                }
            }
            else
            {
                richTextBox1.Invoke(new Action(() => { OnAppendText("当前无连接的客户端"); }));
            }
            txt_send.Clear();
        }

        private void DotnetSocketServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_port.Text = "3333";
            txt_ip.Text = "0.0.0.0";
        }
        private void OnAppendText(string msg)
        {
            richTextBox1.AppendText("【" + DateTime.Now.ToString() + "】" + msg + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserMgr mgr = new UserMgr();
            mgr.CreateUser(new UserModel());
            //UserManage userManage = new UserManage();
            //userManage.Show();
        }
    }
}
