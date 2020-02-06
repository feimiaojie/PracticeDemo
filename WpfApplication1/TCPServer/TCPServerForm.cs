using HPSocket;
using HPSocket.Tcp;
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

namespace TCPServer
{
    public partial class ServerForm : Form
    {
        delegate void AddLogHandler(string log);
        private AppState appState = AppState.Stoped;
        private readonly ITcpPackServer _server = new TcpPackServer();

        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            appState = AppState.Stoped;
            SetControlState();

            // 缓冲区大小应根据实际业务设置, 并发数和包大小都是考虑条件
            // 都是小包的情况下4K合适, 刚好是一个内存分页(在非托管内存, 相关知识查百度)
            // 大包比较多的情况下, 应根据并发数设置比较大但是又不会爆内存的值
            _server.SocketBufferSize = 4096; // 4K

            // pack模型专有设置
            _server.MaxPackSize = 4096;     // 最大封包
            _server.PackHeaderFlag = 0x01;  // 包头标识, 要与客户端对应, 否则无法通信

            _server.Address = IPAddress.Any.ToString();
            _server.Port = 5556;

            _server.OnPrepareListen += OnPrepareListen;
            _server.OnAccept += OnAccept;
            _server.OnReceive += OnReceive;
            _server.OnClose += OnClose;
            _server.OnShutdown += OnShutdown;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            appState = AppState.Starting;

            try
            {
                if (_server.Start())
                {
                    appState = AppState.Started;
                    SetControlState();
                }
                else
                {
                    appState = AppState.Stoped;
                    SetControlState();
                    throw new Exception($"服务端启动失败：{_server.ErrorMessage}，{_server.ErrorCode}");
                }
            }
            catch (Exception exec)
            {
                AddLog(exec.Message);
            }
        }

        private void AddLog(string log)
        {
            // 
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
                BtnStart.Enabled = (appState == AppState.Stoped);
                BtnClose.Enabled = (appState == AppState.Started);
                //textBoxSendMsg.Enabled = (appState == AppState.Started);
                //buttonSend.Enabled = (appState == AppState.Started);
            });
        }

        private HandleResult OnPrepareListen(IServer sender, IntPtr listen)
        {
            AddLog($"正在连接({sender.Address}:{sender.Port}), listen: {listen}, hp-socket版本: {sender.Version}");

            return HandleResult.Ok;
        }

        private HandleResult OnAccept(IServer sender, IntPtr connId, IntPtr client)
        {
            // 获取客户端地址
            if (!sender.GetRemoteAddress(connId, out var ip, out var port))
            {
                return HandleResult.Error;
            }

            string connIdStr = connId.ToString();
            AddLog($"接受客户端连接请求,连接ID({connIdStr}), ip: {ip}, port: {port}");

            if (!ChkLbClients.Items.Contains(connIdStr))
            {
                ChkLbClients.BeginInvoke((Action) (() => { ChkLbClients.Items.Add(connIdStr); }));
            }

            return HandleResult.Ok;
        }

        private int count = 0;
        private HandleResult OnReceive(IServer sender, IntPtr connId, byte[] data)
        {
            count++;
            string receiveData = Encoding.Default.GetString(data);
            AddLog($"收到连接ID:{connId}的信息，内容：{receiveData},长度{data.Length}");
            return HandleResult.Ok;
        }

        private HandleResult OnClose(IServer sender, IntPtr connId, SocketOperation socketOperation, int errorCode)
        {
            if (errorCode == 0)
            {
                AddLog($"客户端断开连接，连接ID：{connId}");
            }
            else
            {
                AddLog($"客户端连接异常, ，连接ID：{connId}，错误代码{errorCode}");
            }
            ChkLbClients.BeginInvoke((Action)(() => { ChkLbClients.Items.Remove(connId.ToString()); }));
            return HandleResult.Ok;
        }

        private HandleResult OnShutdown(IServer sender)
        {
            appState = AppState.Stoped;
            SetControlState();

            AddLog($"关闭服务连接：({sender.Address}:{sender.Port})");

            return HandleResult.Ok;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            appState = AppState.Stopping;
            _server.Stop();
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (appState == AppState.Started)
            {
                AddLog("请先停止服务");
                e.Cancel = true;
            }
        }

        private void BtnSendAll_Click(object sender, EventArgs e)
        {
            string sendContent = TxtMsg.Text;
            if (sendContent.Length < 1)
            {
                return;
            }

            byte[] sendBytes = Encoding.Default.GetBytes(sendContent);

            var idList = _server.GetAllConnectionIds();
            foreach (var connId in idList)
            {
                _server.Send(connId, sendBytes, sendBytes.Length);
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string sendContent = TxtMsg.Text;
            if (sendContent.Length < 1)
            {
                return;
            }
            if (ChkLbClients.Items.Count < 1)
            {
                return;
            }

            try
            {
                byte[] sendBytes = Encoding.Default.GetBytes(sendContent);

                for (int i = 0; i < ChkLbClients.Items.Count; i++)
                {
                    IntPtr connId = (IntPtr)Convert.ToInt32(ChkLbClients.Items[i]);
                    if (ChkLbClients.GetItemChecked(i))
                    {
                        _server.Send(connId, sendBytes, sendBytes.Length);
                    }
                }

                TxtMsg.Text = string.Empty;
            }
            catch (Exception exc)
            {
                AddLog($"发送失败：{exc.Message}");
            }
        }

        private void BtnDisConnection_Click(object sender, EventArgs e)
        {
            if (ChkLbClients.Items.Count > 0)
            {
                try
                {
                    for (int i = 0; i < ChkLbClients.Items.Count; i++)
                    {
                        IntPtr connId = (IntPtr)Convert.ToInt32(ChkLbClients.Items[i]);

                        if (ChkLbClients.GetItemChecked(i))
                        {
                            _server.Disconnect(connId, true);
                        }
                    }
                }
                catch (Exception exc)
                {
                    AddLog(exc.Message);
                }
            }
        }
    }

    public enum AppState
    {
        Starting, Started, Stopping, Stoped, Error
    }
}
