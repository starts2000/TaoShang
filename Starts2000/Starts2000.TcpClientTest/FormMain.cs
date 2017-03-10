using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Starts2000.Net.Codecs;
using Starts2000.Net.Codecs.Message;
using Starts2000.Net.Session;
using Starts2000.Net.Session.Future;
using Starts2000.Net.Session.Packet;

namespace Starts2000.TcpClientTest
{
    public partial class FormMain : Form
    {
        int _connectCount;
        bool _systemExit;
        IDictionary<AsyncTcpSession, SessionInfo>
            _tcpClients = new Dictionary<AsyncTcpSession, SessionInfo>();
        IPacket _sendPacket = new DefaultPacket();

        public FormMain()
        {
            InitializeComponent();
            Init();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _systemExit = true;

            foreach(var session in _tcpClients.Keys)
            {
                CloseClient(session);
                Thread.Sleep(10);
            }
        }

        void Init()
        {
            _sendPacket = new DefaultPacketEncoder().Encode(null, "Hello, Starts2000.Net.TcpClient!");

            IPAddress[] addreses = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (var address in addreses)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    tbLocalIp.Text = address.ToString();
                    tbServerIp.Text = address.ToString();
                    break;
                }
            }

            btnCreateClient.Click += (sender, e) =>
            {
                Task.Factory.StartNew(() =>
                {
                    CreateClients();
                });
            };
        }

        void CreateClients()
        {
            int count = int.Parse(tbConnectCount.Text);

            IPEndPoint localEP = null;
            if (!string.IsNullOrEmpty(tbLocalIp.Text))
            {
                localEP = new IPEndPoint(IPAddress.Parse(tbLocalIp.Text), 0);
            }

            IPEndPoint remoteEP = new IPEndPoint(
                IPAddress.Parse(tbServerIp.Text), int.Parse(tbPort.Text));

            BeginInvoke((Action)(() =>
            {
                AsyncTcpSession tcpClient;
                lvSession.BeginUpdate();

                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        tcpClient = new AsyncTcpSession(localEP, remoteEP, true, 5000, 1000, true);
                        tcpClient.PacketEncoder = new DefaultPacketEncoder();
                        tcpClient.PacketDecoder = new DefaultPacketDecoder();
                        tcpClient.Closed += TcpClient_Closed;
                        tcpClient.ObjectSent += TcpClient_ObjectSent;
                        tcpClient.StateChanged += TcpClient_StateChanged;
                        tcpClient.ObjectReceived += TcpClient_ObjectReceived;
                        tcpClient.ExceptionCaught += TcpClient_ExceptionCaught;

                        _connectCount++;
                        _tcpClients.Add(tcpClient, new SessionInfo
                        {
                            Id = _connectCount
                        });

                        lvSession.Items.Add(new ListViewItem(new string[]{
                        _connectCount.ToString(), "", "0", "0", ""
                    })
                        {
                            Name = _connectCount.ToString(),
                            Tag = tcpClient
                        });
                    }
                    catch (Exception ex)
                    {
                        AppendInfo("创建 TcpClient 失败：" + ex.ToString());
                    }
                }

                lvSession.EndUpdate();
                OpenClients();
            }));
        }

        void OpenClients()
        {
            foreach(var tcpClient in _tcpClients)
            {
                OpenClinet(tcpClient.Key, tcpClient.Value.Id);
            }
        }

        void CloseClient(AsyncTcpSession tcpClient)
        {
            try
            {
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                AppendInfo("Close Client: " + ex.ToString());
            }
        }

        void OpenClinet(AsyncTcpSession tcpClient, int id)
        {
            AppendInfo(string.Concat("TcpClient:", id.ToString(), "， 开始连接服务器！"));
            AsyncFuture openFuture = tcpClient.Open() as AsyncFuture;
            openFuture.FutureCompleted += OpenFutureCompleted;
        }

        void SendData(AsyncTcpSession tcpClient)
        {
            IPacket packet = new DefaultPacket(_sendPacket.Buffer.Duplicate(), _sendPacket.EndPoint);
            tcpClient.Flush(packet);
            //future.FutureCompleted += (sender, e) =>
            //{
            //    //SendData();
            //};
        }

        void OpenFutureCompleted(object sender, FutureCompletedEventArgs e)
        {
            var session = e.Future.Session as AsyncTcpSession;
            int id = _tcpClients[session].Id;

            if (e.Future.IsSucceeded)
            {
                if (e.Future.Session.SessionState == SessionState.Opened)
                {

                    string localEP = session.LocalEndPoint.ToString();
                    AppendInfo(string.Concat("TcpClinet:", id.ToString(), " - ", localEP, " 已连接服务器！"));
                    BeginInvoke((Action)(() =>
                    {
                        lvSession.Items[id.ToString()].SubItems[1].Text = localEP;
                    }));
                    SendData(session);
                    return;
                }
            }

            Thread.Sleep(1000);
            OpenClinet(session, id);
        }

        void TcpClient_StateChanged(object sender, SessionEventArgs e)
        {
            var session = e.Session as AsyncTcpSession;
            string key = _tcpClients[session].Id.ToString();
            BeginInvoke((Action)(() =>
            {
                lvSession.Items[key].SubItems[4].Text = session.SessionState.ToString();
            }));
        }

        void TcpClient_ExceptionCaught(object sender, ExceptionEventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                AppendInfo(e.Exception.ToString());
            }));

        }

        void TcpClient_Closed(object sender, SessionEventArgs e)
        {
            var session = e.Session as AsyncTcpSession;
            int id = _tcpClients[session].Id;

            if (!_systemExit)
            {
                AppendInfo(string.Concat("TcpClient:", id.ToString(), " - ", 
                    e.Session.LocalEndPoint.ToString(), " Session Closed!"));
                OpenClinet(session, id);
            }
        }

        void TcpClient_ObjectSent(object sender, SessionEventArgs e)
        {
            var session = e.Session as AsyncTcpSession;
            SessionInfo info = _tcpClients[session];
            Interlocked.Increment(ref info.SendCount);

            BeginInvoke((Action)(() =>
            {
                lvSession.Items[info.Id.ToString()].SubItems[2].Text = info.SendCount.ToString();
            }));

            Thread.Sleep(300);
            SendData(session);
        }

        void TcpClient_ObjectReceived(object sender, SessionEventArgs e)
        {
            var session = e.Session as AsyncTcpSession;
            SessionInfo info = _tcpClients[session];
            Interlocked.Increment(ref info.ReceiveCount);

            BeginInvoke((Action)(() =>
            {
                lvSession.Items[info.Id.ToString()].SubItems[3].Text = info.ReceiveCount.ToString();
            }));

            AppendInfo(string.Concat("TcpClient:", info.Id.ToString(), " - ",
                session.LocalEndPoint.ToString(), ": " , (e.Obj as DefaultMessage).Obj.ToString()), true);
        }

        void AppendInfo(string info, bool isReceiveInfo = false)
        {
            if (isReceiveInfo && !cbShowReceiveInfo.Checked)
            {
                return;
            }

            BeginInvoke((Action)(() =>
            {
                if (rtbInfo.TextLength > 1024 * 1024 * 5)
                {
                    rtbInfo.Clear();
                }

                rtbInfo.AppendText(DateTime.Now.ToString("yyMMdd HH:mm:ss.fff") + "  " + info);
                rtbInfo.AppendText(Environment.NewLine);
            }));
        }
        class SessionInfo
        {
            public int Id;
            public int SendCount;
            public int ReceiveCount;
        }
    }
}