using HPSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPSocket.Tcp;

namespace TCPClient
{
    public partial class TCPClientForm : Form
    {
        delegate void AddLogHandler(string log);
        private AppState appState = AppState.Stoped;
        private readonly ITcpPackClient _client = new TcpPackClient();

        public TCPClientForm()
        {
            InitializeComponent();
        }

        private void TCPClientForm_Load(object sender, EventArgs e)
        {
            appState = AppState.Stoped;
            SetControlState();

            // 缓冲区大小
            _client.SocketBufferSize = 4096; // 4K
            // 异步连接
            _client.Async = true;

            // pack模型专有设置
            _client.MaxPackSize = 4096;     // 最大封包
            _client.PackHeaderFlag = 0x01;  // 包头标识, 要与客户端对应, 否则无法通信

            _client.Address = "127.0.0.1";
            _client.Port = 5556;

            _client.OnPrepareConnect += OnPrepareConnect;
            _client.OnConnect += OnConnect;
            _client.OnReceive += OnReceive;
            _client.OnClose += OnClose;
        }

        private HandleResult OnPrepareConnect(IClient sender, IntPtr socket)
        {
            AddLog($"正在连接({sender.Address}:{sender.Port}), socket handle: {socket}, hp-socket version: {sender.Version}");

            return HandleResult.Ok;
        }

        private HandleResult OnConnect(IClient sender)
        {
            AddLog("连接服务器成功!");
            return HandleResult.Ok;
        }

        private HandleResult OnReceive(IClient sender, byte[] bytes)
        {
            string recievedStr = Encoding.Default.GetString(bytes);

            AddLog(string.Format("收到服务器信息，内容：{0}，长度：{1}", recievedStr, bytes.Length));

            return HandleResult.Ok;
        }

        private HandleResult OnClose(IClient sender, SocketOperation socketOperation, int errorCode)
        {
            appState = AppState.Stoped;
            SetControlState();

            if (errorCode == 0)
            {
                AddLog($"服务器连接关闭！");
            }
            else
            {
                AddLog($"服务器连接异常关闭，错误代码:{errorCode}");
            }

            return HandleResult.Ok;
        }

        private void AddLog(string log)
        {
            if (TxtLog.IsDisposed)
            {
                return;
            }

            // 从ui线程去操作ui
            if (TxtLog.InvokeRequired)
            {
                TxtLog.Invoke(new AddLogHandler(AddLog), log);
            }
            else
            {
                TxtLog.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {log}\r\n");
            }
        }

        //根据AppState设置界面控件相关状态的方法
        private void SetControlState()
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                //textBoxIPAdress.Enabled = (appState == AppState.Stoped);
                //textBoxPort.Enabled = (appState == AppState.Stoped);
                //checkBoxAsyncConn.Enabled = (appState == AppState.Stoped);
                BtnStart.Enabled = (appState == AppState.Stoped);
                BtnClose.Enabled = (appState == AppState.Started);
                TxtSendMsg.Enabled = (appState == AppState.Started);
                BtnSend.Enabled = (appState == AppState.Started);
            });
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string content = TxtSendMsg.Text;
            if (content.Length < 1)
            {
                return;
            }

            byte[] sendBytes = Encoding.Default.GetBytes(content);

            _client.Send(sendBytes, sendBytes.Length);

            TxtSendMsg.Text = string.Empty;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            appState = AppState.Starting;
            try
            {
                if (_client.Connect())
                {
                    appState = AppState.Started;
                    SetControlState();
                }
                else
                {
                    appState = AppState.Stoped;
                    SetControlState();
                    throw new Exception($"无法建立连接：{_client.ErrorMessage}，{_client.ErrorCode}");
                }
            }
            catch (Exception exec)
            {
                AddLog(exec.Message);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            appState = AppState.Stopping;
            _client.Stop();
        }

        private void TCPClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (appState == AppState.Started)
            {
                AddLog("请先关闭连接");
                e.Cancel = true;
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            var msg = TxtSendMsg.Text;
            if (string.IsNullOrWhiteSpace(msg))
            {
                msg = "测试数据！！！";
            }

            byte[] sendBytes = Encoding.Default.GetBytes(msg);

            _client.Send(sendBytes, sendBytes.Length);
            _client.Send(sendBytes, sendBytes.Length);
            _client.Send(sendBytes, sendBytes.Length);
            _client.Send(sendBytes, sendBytes.Length);
        }
    }
    public enum AppState
    {
        Starting, Started, Stopping, Stoped, Error
    }
}
