using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Starts2000.Net.Codecs;
using Starts2000.Net.Codecs.Message;
using Starts2000.Net.Session;

namespace Starts2000.TcpServerDemo
{
    public partial class FormMain : Form
    {
        AsyncSocketSessionAcceptor _acceptor;
        long _sendCount;
        long _receiveCount;

        public FormMain()
        {
            InitializeComponent();
            Init();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if(_acceptor!= null && _acceptor.Started)
            {
                _acceptor.Close();
            }
        }

        void Init()
        {
            IPAddress[]addreses = Dns.GetHostAddresses(Dns.GetHostName());

            foreach(var address in addreses)
            {
                if(address.AddressFamily == AddressFamily.InterNetwork)
                {
                    tbIP.Text = address.ToString();
                    break;
                }
            }

            btnStart.Click += (sender, e) =>
            {
                if(string.IsNullOrWhiteSpace(tbIP.Text))
                {
                    MessageBox.Show("请输入 IP 地址。");
                }

                if (string.IsNullOrWhiteSpace(tbPort.Text))
                {
                    MessageBox.Show("请输入端口。");
                }

                try
                {
                    AppendInfo("TcpServer Starting!");
                    _acceptor = new AsyncSocketSessionAcceptor(
                        new IPEndPoint(IPAddress.Parse(tbIP.Text), int.Parse(tbPort.Text)));
                    _acceptor.Backlog = 200;
                    _acceptor.ReuseAddress = true;
                    _acceptor.PacketEncoder = new DefaultPacketEncoder();
                    _acceptor.PacketDecoder = new DefaultPacketDecoder();
                    _acceptor.SessionAccepted += AcceptorSessionAccepted;
                    _acceptor.ExceptionCaught += AcceptorExceptionCaught;
                    _acceptor.Start();
                    AppendInfo("TcpServer Started!");
                }
                catch(Exception ex)
                {
                    AppendInfo("TcpServer Start Fail!" + ex.ToString());
                }
            };
        }

        void AcceptorSessionAccepted(object sender, SessionAcceptedEventArgs e)
        {
            e.Session.ObjectReceived += Session_ObjectReceived;
            e.Session.ObjectSent += Session_ObjectSent;
            e.Session.ExceptionCaught += Session_ExceptionCaught;
            ((SessionBase)e.Session).Closed += SessionClosed;

            BeginInvoke((Action)(() =>
            {
                tsslConnectCount.Text = e.Acceptor.AcceptedCount.ToString();
            }));

            AppendInfo(e.Session.RemoteEndPoint.ToString() + " 已连接！");
        }

        void Session_ExceptionCaught(object sender, ExceptionEventArgs e)
        {
            AppendInfo(e.Exception.ToString());
        }

        void AcceptorExceptionCaught(object sender, ExceptionEventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                AppendInfo(e.Exception.ToString());
            }));
        }

        void Session_ObjectReceived(object sender, SessionEventArgs e)
        {
            if (e.Obj != null)
            {
                Interlocked.Increment(ref _receiveCount);
            }

            if (cbShowPacketCount.Checked)
            {
                BeginInvoke((Action)(() =>
                {
                    tsslRecieveCount.Text = _receiveCount.ToString();
                }));
            }

            //Thread.Sleep(100);

            e.Session.Send("Hello," + e.Session.RemoteEndPoint.ToString() + "!");

            AppendInfo(e.Session.RemoteEndPoint.ToString()
                + ": " + (e.Obj as DefaultMessage).Obj.ToString(), true);
        }

        void Session_ObjectSent(object sender, SessionEventArgs e)
        {
            Interlocked.Increment(ref _sendCount);

            if (cbShowPacketCount.Checked)
            {
                BeginInvoke((Action)(() =>
                {
                    tsslSendCount.Text = _sendCount.ToString();
                }));
            }
        }

        void SessionClosed(object sender, SessionEventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                AppendInfo(e.Session.RemoteEndPoint.ToString() + " 断开连接。");
                tsslConnectCount.Text = _acceptor.AcceptedCount.ToString();
            }));
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

                rtbInfo.AppendText(info);
                rtbInfo.AppendText(Environment.NewLine);
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var buffer = Starts2000.Net.Buffer.BufferFactory.GetBuffer(128);
            //buffer.GetInnerByteArray()[0] = 10;
            //buffer.GetInnerByteArray()[1] = 11;
            //buffer.GetInnerByteArray()[2] = 12;
            //buffer.GetInnerByteArray()[3] = 13;
            //buffer.GetInnerByteArray()[4] = 14;
            //buffer.GetInnerByteArray()[5] = 15;
            //buffer.GetInnerByteArray()[6] = 16;
            //buffer.GetInnerByteArray()[7] = 17;
            //buffer.GetInnerByteArray()[8] = 18;
            //buffer.GetInnerByteArray()[9] = 19;
            //buffer.Position = 1;

            //var buffer1 = Starts2000.Net.Buffer.BufferFactory.GetBuffer(4);
            //buffer1.GetInnerByteArray()[0] = 20;
            //buffer1.GetInnerByteArray()[1] = 21;
            //buffer1.GetInnerByteArray()[2] = 22;
            //buffer1.GetInnerByteArray()[3] = 23;

            //buffer.Compact();

            //if (buffer.Remaining < buffer1.Remaining)
            //{
            //    IBuffer buffer2 = Starts2000.Net.Buffer.BufferFactory.GetBuffer(
            //        buffer.Position + buffer1.Remaining).Put(buffer.Flip());
            //    //_content.Release();
            //    //_content = buffer;

            //    buffer2.Put(buffer1);
            //    buffer2.Flip();
            //}

            //_content.Put(content);
            //_content.Flip();

            //IBuffer flip = buffer.Flip();

            //var buffer2 = Starts2000.Net.Buffer.BufferFactory.GetBuffer(20);
            //buffer2.Put(flip);
            //buffer2.Put(buffer1);
            //buffer2.Flip();

            NormalizeCapacity(1255);
        }

        public static Int32 NormalizeCapacity(Int32 requestedCapacity)
        {
            if (requestedCapacity < 0)
                return Int32.MaxValue;

            Int32 newCapacity = HighestOneBit(requestedCapacity);
            newCapacity <<= (newCapacity < requestedCapacity ? 1 : 0);
            return newCapacity < 0 ? Int32.MaxValue : newCapacity;
        }

        private static Int32 HighestOneBit(Int32 i)
        {
            i |= (i >> 1);
            i |= (i >> 2);
            i |= (i >> 4);
            i |= (i >> 8);
            i |= (i >> 16);
            return i - (i >> 1);
        }
    }
}
