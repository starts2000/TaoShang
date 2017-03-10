using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewClientMain : ViewBaseEx
    {
        readonly IRemoteOperationBll _remoteOperationBll;
        readonly INotifyIconMagager _notifyIcon;
        readonly IOrderRecordBll _orderRecordBll;
        readonly IViewFactory _viewFactory;
        readonly IGlobalApplicationData _globalApplicationData;
        bool _hangUp = true;
        bool _systemExit;
        RemoteDeskState _remoteDeskState = new RemoteDeskState();

        string _anyDeskSourceFile = Path.Combine(Application.StartupPath, @"remotedesk\anydesk\anydesk.exe");
        string _anyDeskIstallPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "MsgTaoBao");

        int _remoteDeskpCheckTimerCallbackState;
        System.Threading.Timer _checkRemoteDeskTimer;

        public ViewClientMain(IRemoteOperationBll remoteOperationBll,
            INotifyIconMagager notifyIcon, IOrderRecordBll orderRecordBll,
            IViewFactory viewFactory, IGlobalApplicationData globalApplicationData)
        {
            InitializeComponent();

            _remoteOperationBll = remoteOperationBll;
            _orderRecordBll = orderRecordBll;
            _notifyIcon = notifyIcon;
            _viewFactory = viewFactory;
            _globalApplicationData = globalApplicationData;
            Init();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(() =>
            {
                if (!AnyDesk.Start(_anyDeskIstallPath, _anyDeskSourceFile))
                {
                    Invoke(() =>
                    {
                        MessageBoxEx.Show(this, "远程连接服务初始化失败！",
                            "挂机端程序初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _systemExit = true;
                        Application.Exit();
                    });
                }
            }).Wait();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_systemExit)
            {
                var view = _viewFactory.GetView<ViewMainCloseConfirm>();
                if (view.ShowDialog(this) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }

            base.OnFormClosing(e);

            if (!e.Cancel)
            {
                switch (e.CloseReason)
                {
                    case CloseReason.ApplicationExitCall:
                    case CloseReason.TaskManagerClosing:
                    case CloseReason.UserClosing:
                    case CloseReason.WindowsShutDown:
                        _globalApplicationData.ApplicationData.UserExit = true;
                        break;
                }
            }
        }

        void Init()
        {
            _checkRemoteDeskTimer = new System.Threading.Timer(
                CheckRemoteDeskpTimerCallback, null, Timeout.Infinite, 2000);

            sbtnConfirmReceipt.Click += sbtnConfirmReceiptClick;

            sbtnHangUpOpt.Click += (sender, e) =>
            {
                if (_hangUp)
                {
                    _checkRemoteDeskTimer.Change(Timeout.Infinite, 2000);
                    AnyDesk.Stop();
                    _hangUp = false;
                    _remoteDeskState.Connected = false;
                    _remoteDeskState.RemoteInfo = null;
                    tsslRemoteConnectInfo.Text = "暂停挂机";

                    tsslConnectStartTimeLabel.Visible = false;
                    tsslConnectStartTime.Text = string.Empty;
                    tsslConnectStartTime.Visible = false;

                    tsslConnectEndTimeLabel.Visible = false;
                    tsslConnectEndTime.Text = string.Empty;
                    tsslConnectEndTime.Visible = false;

                    sbtnHangUpOpt.Text = "开始挂机";
                }
                else
                {
                    _hangUp = true;
                    tsslRemoteConnectInfo.Text = "等待连接...";
                    sbtnHangUpOpt.Text = "停止挂机";
                }
            };

            _remoteOperationBll.OnRequestRemoteInfo = query =>
            {
                if (!_hangUp || _remoteDeskState.Connected)
                {
                    _remoteOperationBll.ResponseRequetRemoteInfo(
                        query.UserId, RemoteOperationState.ToClientBusy, null);
                    return;
                }

                _remoteDeskState.Connected = true;

                Invoke(() =>
                {
                    tsslRemoteConnectInfo.Text =
                        string.Format("[{0}] 请求连接...", query.UserAccount);
                });

                var state = RemoteOperationState.Failed;

                string remoteId = string.Empty;
                string remotePassword = string.Empty;
                try
                {
                    if (AnyDesk.Start(_anyDeskIstallPath, _anyDeskSourceFile))
                    {
                        remoteId = AnyDesk.GetId();
                        remotePassword = _remoteDeskState.RemoteDeskPassword;
                        AnyDesk.SetPassword(remotePassword);
                        state = RemoteOperationState.Successed;
                    }
                    else
                    {
                        state = RemoteOperationState.ToClientRemoteDesktopServiceError;
                    }
                }
                catch (Exception ex)
                {
                    state = RemoteOperationState.ToClientRemoteDesktopServiceError;
                    Error("RequestRemoteInfo - Start AnyDesk Service Failed!", ex);
                }

                if (state != RemoteOperationState.Successed)
                {
                    _remoteOperationBll.ResponseRequetRemoteInfo(
                        query.UserId, state, null);
                    _remoteDeskState.Connected = false;
                    Invoke(() =>
                    {
                        tsslRemoteConnectInfo.Text =
                            string.Format("等待连接...", query.UserAccount);
                    });
                }
                else
                {
                    Invoke(() =>
                    {
                        tsslRemoteConnectInfo.Text =
                            string.Format("等待 [{0}] 连接...", query.UserAccount);
                    });

                    _remoteDeskState.RemoteInfo = query;
                    _remoteDeskState.CheckRemoteDeskStateStartTime = DateTime.Now;
                    _remoteDeskState.TimerState = TimerState.CheckRemoteDeskState;
                    Interlocked.Exchange(ref _remoteDeskpCheckTimerCallbackState, 0);
                    _checkRemoteDeskTimer.Change(1000, 2000);

                    _remoteOperationBll.ResponseRequetRemoteInfo(
                        query.UserId, state, new RemoteClientInfo
                        {
                            RemoteId = remoteId,
                            RemotePassword = remotePassword
                        });
                }
            };
        }

        void sbtnConfirmReceiptClick(object sender, EventArgs e)
        {
            if (!_remoteDeskState.Connected)
            {
                MessageBoxEx.Show(this, "只有远程用户可以确认收货！", "确认收货",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_remoteDeskState.RemoteInfo == null)
            {
                MessageBoxEx.Show(this, "获取远程用户信息失败！", "确认收货",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _orderRecordBll.GetConfirmReceiptInfo(new OrderRecord
            {
                UserId = _remoteDeskState.RemoteInfo.UserId,
                ClientUserSubAccountId = _remoteDeskState.RemoteInfo.SubAccountId
            }, response =>
            {
                string info = string.Empty;
                switch (response.State)
                {
                    case OrderRecordOptState.CannotConnectServer:
                        info = "服务器连接失败，未能获取确认收货信息！";
                        break;
                    case OrderRecordOptState.Failed:
                        info = "服务器异常，获取确认收货信息失败!";
                        break;
                    case OrderRecordOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                }

                Invoke(() =>
                {
                    if (response.State != OrderRecordOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取确认收货信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (response.Data == null || string.IsNullOrEmpty(response.Data.OrderNum))
                    {
                        MessageBoxEx.Show(this, "没有需要确认收货的订单。", "确认收货",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var result = MessageBoxEx.Show(this, string.Format(
                        "   请登录小号：{0}   {2}{2}   核对订单号：{1}   {2}{2}   进行确认收货！",
                        response.Data.ClientUserSubAccount, response.Data.OrderNum, Environment.NewLine),
                        "确认收货", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if(result == DialogResult.Cancel)
                    {
                        return;
                    }

                    _remoteDeskState.ConfirmReceiptInfo = response.Data;
                    var view = _viewFactory.GetView<ViewECommercePlatformSelect>();
                    view.ShowDialog(this);

                    var viewConfirmReceipt = _viewFactory.GetView<ViewConfirmReceipt>();
                    viewConfirmReceipt.ECommercePlatform = view.ECommercePlatform;
                    viewConfirmReceipt.ConfirmReceiptInfo = _remoteDeskState.ConfirmReceiptInfo;
                    viewConfirmReceipt.Show(this);
                });
            });
        }

        void ShowSubAccountInfo(bool show)
        {
            if (show)
            {
                if (_remoteDeskState.RemoteInfo != null)
                {
                    lbSubAccountInfo.Text = string.Format(
                        "请注意： \r\n    当前选择小号为：{0}，请使用该小号进行操作，否则将不能收货！",
                        _remoteDeskState.RemoteInfo.SubAccount);
                    WindowState = FormWindowState.Normal;
                    Show();
                }
            }
            else
            {
                lbSubAccountInfo.Text = string.Empty;
                WindowState = FormWindowState.Minimized;
            }
        }

        void CheckRemoteDeskpTimerCallback(object state)
        {
            if (Interlocked.Exchange(ref _remoteDeskpCheckTimerCallbackState, 1) == 1)
            {
                return;
            }

            try
            {
                bool started = AnyDesk.IsServerOpened();
                if (_remoteDeskState.TimerState == TimerState.CheckRemoteDeskState)
                {
                    if (started)
                    {
                        _remoteDeskState.RemoteDeskConnectStartTime = DateTime.Now;
                        _remoteDeskState.TimerState = TimerState.CheckRemoteDeskConnectTime;

                        Invoke(() =>
                        {
                            tsslRemoteConnectInfo.Text = string.Format(
                                "[{0}] 远程控制中...", _remoteDeskState.RemoteInfo.UserAccount);

                            tsslConnectStartTimeLabel.Visible = true;
                            tsslConnectStartTime.Text = _remoteDeskState
                                .RemoteDeskConnectStartTime.ToString("yyyy-MM-dd HH:mm:ss");
                            tsslConnectStartTime.Visible = true;

                            tsslConnectEndTimeLabel.Visible = true;
                            tsslConnectEndTime.Text = _remoteDeskState
                                .RemoteDeskConnectEndTime.ToString("yyyy-MM-dd HH:mm:ss");
                            tsslConnectEndTime.Visible = true;
                            ShowSubAccountInfo(true);
                        });

                        return;
                    }

                    if (_remoteDeskState.CheckRemoteDeskStateStartTime.AddMilliseconds(
                        _remoteDeskState.MaxCheckRemoteDeskStateTime) <= DateTime.Now)
                    {
                        _checkRemoteDeskTimer.Change(Timeout.Infinite, 2000);
                        Invoke(() =>
                        {
                            try
                            {
                                AnyDesk.CloseServer();
                                AnyDesk.Stop();
                            }
                            catch(Exception ex)
                            {
                                Error("CheckRemoteDeskpTimerCallback -- AnyDesk Stop！", ex);
                            }
                            tsslRemoteConnectInfo.Text = "等待连接...";
                            tsslConnectStartTimeLabel.Visible = false;
                            tsslConnectStartTime.Text = string.Empty;
                            tsslConnectStartTime.Visible = false;

                            tsslConnectEndTimeLabel.Visible = false;
                            tsslConnectEndTime.Text = string.Empty;
                            tsslConnectEndTime.Visible = false;
                        });

                        _remoteDeskState.Connected = false;
                        _remoteDeskState.RemoteInfo = null;
                        _remoteDeskState.ConfirmReceiptInfo = null;
                        _remoteDeskState.ChangeRemoteDeskPassword();
                    }

                    return;
                }

                if (_remoteDeskState.TimerState == TimerState.CheckRemoteDeskConnectTime)
                {
                    if (started)
                    {
                        var endTime = _remoteDeskState.RemoteDeskConnectEndTime;
                        if (endTime <= DateTime.Now)
                        {
                            _checkRemoteDeskTimer.Change(Timeout.Infinite, 2000);

                            _remoteDeskState.ChangeRemoteDeskPassword();
                            Invoke(() =>
                            {
                                try
                                {
                                    int closeCount = 0;
                                    while (AnyDesk.IsServerOpened() && closeCount++ < 10)
                                    {
                                        AnyDesk.CloseServer();
                                        Thread.Sleep(1000);
                                    }
                                    AnyDesk.SetPassword(_remoteDeskState.RemoteDeskPassword);
                                }
                                catch(Exception ex)
                                {
                                    Error("CheckRemoteDeskpTimerCallback -- AnyDesk CloseServer And SetPassword！", ex);
                                }

                                tsslRemoteConnectInfo.Text = "等待连接...";
                                tsslConnectStartTimeLabel.Visible = false;
                                tsslConnectStartTime.Text = string.Empty;
                                tsslConnectStartTime.Visible = false;

                                tsslConnectEndTimeLabel.Visible = false;
                                tsslConnectEndTime.Text = string.Empty;
                                tsslConnectEndTime.Visible = false;
                                ShowSubAccountInfo(false);
                            });

                            _remoteDeskState.Connected = false;
                            _remoteDeskState.RemoteInfo = null;
                            _remoteDeskState.ConfirmReceiptInfo = null;

                            return;
                        }

                        TimeSpan timeSpan = endTime - DateTime.Now;
                        if (timeSpan.TotalMilliseconds <= 1000 * 60 * 5)
                        {
                            Invoke(() =>
                            {
                                _notifyIcon.ShowBalloonTip(5000, "挂机端远程连接",
                                    string.Format("远程连接还有约 {0}分{1}秒 即将断开，请尽快操作！",
                                    timeSpan.Minutes, timeSpan.Seconds), ToolTipIcon.Warning);
                            });
                        }
                    }
                    else
                    {
                        _checkRemoteDeskTimer.Change(Timeout.Infinite, 2000);
                        _remoteDeskState.ChangeRemoteDeskPassword();
                        _remoteDeskState.Connected = false;
                        _remoteDeskState.RemoteInfo = null;
                        _remoteDeskState.ConfirmReceiptInfo = null;
                        Invoke(() =>
                        {
                            try
                            {
                                AnyDesk.SetPassword(_remoteDeskState.RemoteDeskPassword);
                            }
                            catch(Exception ex)
                            {
                                Error("CheckRemoteDeskpTimerCallback -- AnyDesk SetPassword！", ex);
                            }

                            tsslRemoteConnectInfo.Text = "等待连接...";
                            tsslConnectStartTimeLabel.Visible = false;
                            tsslConnectStartTime.Text = string.Empty;
                            tsslConnectStartTime.Visible = false;

                            tsslConnectEndTimeLabel.Visible = false;
                            tsslConnectEndTime.Text = string.Empty;
                            tsslConnectEndTime.Visible = false;
                            ShowSubAccountInfo(false);
                        });
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Error("CheckRemoteDeskpTimerCallback！", ex);
            }
            finally
            {
                Interlocked.Exchange(ref _remoteDeskpCheckTimerCallbackState, 0);
            }
        }
    }

    class RemoteDeskState
    {
        int _connected;
        int _timerState;
        RemoteInfoQuery _remoteInfo;
        OrderRecordConfirmReceiptInfo _confirmReceiptInfo;
        DateTime _checkRemoteDeskStateStartTime;
        DateTime _remoteDeskConnectStartTime;
        readonly object _rootAsync = new object();

        public RemoteDeskState()
        {
            MaxRemoteDeskConnectTime = 50 * 60 * 1000;
            MaxCheckRemoteDeskStateTime = 60 * 1000;
            ChangeRemoteDeskPassword();
        }

        public bool Connected
        {
            get
            {
                return Interlocked.CompareExchange(ref _connected, 1, 1) == 1;
            }
            set
            {
                if(value)
                {
                    Interlocked.Exchange(ref _connected, 1);
                }
                else
                {
                    Interlocked.Exchange(ref _connected, 0);
                }
            }
        }

        public TimerState TimerState
        {
            get 
            { 
                if(Interlocked.CompareExchange(ref _timerState, 0, 0) == 0)
                {
                    return TimerState.CheckRemoteDeskState;
                }

                return TimerState.CheckRemoteDeskConnectTime;
            }
            set
            {
                switch(value)
                {
                    case TimerState.CheckRemoteDeskState:
                        Interlocked.Exchange(ref _timerState, 0);
                        break;
                    case TimerState.CheckRemoteDeskConnectTime:
                        Interlocked.Exchange(ref _timerState, 1);
                        break;
                }
            }
        }

        public int MaxRemoteDeskConnectTime
        {
            get;
            set;
        }

        public int MaxCheckRemoteDeskStateTime
        {
            get;
            set;
        }

        public RemoteInfoQuery RemoteInfo
        {
            get
            {
                lock(_rootAsync)
                {
                    return _remoteInfo;
                }
            }
            set
            {
                lock(_rootAsync)
                {
                    _remoteInfo = value;
                }
            }
        }

        public OrderRecordConfirmReceiptInfo ConfirmReceiptInfo
        {
            get
            {
                lock(_rootAsync)
                {
                    return _confirmReceiptInfo;
                }
            }
            set
            {
                lock(_rootAsync)
                {
                    _confirmReceiptInfo = value;
                }
            }
        }

        public string RemoteDeskPassword
        {
            private set;
            get;
        }

        public DateTime CheckRemoteDeskStateStartTime
        {
            get
            {
                lock(_rootAsync)
                {
                    return _checkRemoteDeskStateStartTime;
                }
            }
            set
            {
                lock(_rootAsync)
                {
                    _checkRemoteDeskStateStartTime = value;
                }
            }
        }

        public DateTime RemoteDeskConnectStartTime
        {
            get
            {
                lock (_rootAsync)
                {
                    return _remoteDeskConnectStartTime;
                }
            }
            set
            {
                lock (_rootAsync)
                {
                    _remoteDeskConnectStartTime = value;
                }
            }
        }

        public DateTime RemoteDeskConnectEndTime
        {
            get { return RemoteDeskConnectStartTime.AddMilliseconds(MaxRemoteDeskConnectTime); }
        }

        public void ChangeRemoteDeskPassword()
        {
            lock (_rootAsync)
            {
                RemoteDeskPassword = MD5Encrypt.GetSeed(8);
            }
        }
    }

    enum TimerState
    {
        CheckRemoteDeskState,
        CheckRemoteDeskConnectTime,
        CheckRemoteDeskConnectOpen,
        CheckRemoteDeskConnectClose
    }
}
