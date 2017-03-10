using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CCWin;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewOptMain : ViewBaseEx
    {
        readonly IViewFactory _viewFactory;
        readonly IUserSubAccountBll _subAccountBll;
        readonly IAreaBll _areaBll;
        readonly IRemoteOperationBll _remoteOperationBll;
        readonly IShopBll _shopBll;
        readonly IOrderRecordBll _orderRecordBll;
        readonly IOrderStateBll _orderStateBll;
        readonly IGlobalApplicationData _globalApplicationData;

        readonly Random _accHidenRandom = new Random();
        RemoteDeskConnectState _remoteDeskConnectState;

        int _remoteDeskpCheckTimerCallbackState;
        System.Threading.Timer _remoteDeskCheckTimer;

        OrderRecordListControl _orderRecordControl;

        public ViewOptMain(IViewFactory viewFactory, IUserSubAccountBll subAccountBll,
            IAreaBll areaBll, IRemoteOperationBll remoteOperationBll, IShopBll shopBll,
            IOrderRecordBll orderRecordBll, IOrderStateBll orderStateBll, IGlobalApplicationData globalApplicationData)
        {
            InitializeComponent();

            _viewFactory = viewFactory;
            _subAccountBll = subAccountBll;
            _areaBll = areaBll;
            _remoteOperationBll = remoteOperationBll;
            _shopBll = shopBll;
            _orderRecordBll = orderRecordBll;
            _orderStateBll = orderStateBll;
            _globalApplicationData = globalApplicationData;
            Init();
        }

        internal RemoteDeskConnectState RemoteDeskConnectState
        {
            get { return _remoteDeskConnectState; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            scbProvince.DataSource = _areaBll.GetProvinceList();
            LoadSubAccountPageList(1, paginationSubAccount.PageSize);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
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

        void Init()
        {
            SetToMax();

            _orderRecordControl = new OrderRecordListControl(_shopBll, _orderStateBll);
            _orderRecordControl.Dock = DockStyle.Fill;
            tpShippingList.Controls.Add(_orderRecordControl);

            skinTabControl.SelectedIndexChanged += (sender, e) =>
            {
                if (skinTabControl.SelectedIndex == 1 &&
                    !_remoteDeskConnectState.Connected)
                {
                    LoadOrderRecordPageList(1,
                        _orderRecordControl.PaginationOrderRecordList.PageSize);
                }
            };

            _remoteDeskConnectState = new RemoteDeskConnectState();
            _remoteDeskCheckTimer = new System.Threading.Timer(
                RemoteDeskCheckTimerCallback, null, Timeout.Infinite, 2000);

            sdgvSubAccountList.AutoGenerateColumns = false;
            sdgvSubAccountList.CellFormatting += (sender, e) =>
            {
                switch (e.ColumnIndex)
                {
                    case 1:
                        string acc = e.Value as string;
                        if (!string.IsNullOrEmpty(acc))
                        {
                            int result;
                            int markCount = Math.DivRem(acc.Length,  2, out result);
                            if(result != 0)
                            {
                                markCount++;
                            }

                            var accArray = acc.ToCharArray();
                            for(int i = 1; i <= markCount; i+=1)
                            {
                                accArray[acc.Length - i] = '*';
                            }

                            e.Value = new string(accArray);
                        }
                        break;
                    case 2:
                        byte? index = (byte?)e.Value;
                        if (index.HasValue)
                        {
                            e.Value = ConstData.TaoBaoLevels[index.Value - 1].Name;
                        }
                        break;
                    case 3:
                        bool? sex = (bool?)e.Value;
                        if (sex.HasValue)
                        {
                            e.Value = sex.Value ? "男" : "女";
                        }
                        break;
                    case 5:
                        var data = sdgvSubAccountList.DataSource as IList<UserSubAccountPageListVM>;
                        if (data != null && data.Count > e.RowIndex)
                        {
                            var vm = data[e.RowIndex];
                            e.Value = string.Format("{0} - {1} - {2}", vm.Province, vm.City, vm.District);
                        }
                        break;
                    case 8:
                        if ((bool)e.Value)
                        {
                            e.Value = "在线";
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.SelectionBackColor = Color.Green;
                        }
                        else
                        {
                            e.Value = "离线";
                            e.CellStyle.BackColor = Color.Red;
                            e.CellStyle.SelectionBackColor = Color.Red;
                        }
                        break;
                    case 9:
                        if (e.Value == null)
                        {
                            e.Value = "未连接";
                        }

                        if (e.Value.ToString().Equals("正在连接"))
                        {
                            e.CellStyle.BackColor = Color.Yellow;
                            e.CellStyle.SelectionBackColor = Color.Yellow;
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.SelectionForeColor = Color.Red;
                        }
                        break;
                    case 10:
                        if (e.Value == null)
                        {
                            e.Value = "连接";
                        }
                        break;
                    case 11:
                        int? dayCount = e.Value as int?;
                        if (dayCount.HasValue && dayCount.Value >= 3)
                        {
                            e.CellStyle.BackColor =
                                e.CellStyle.SelectionBackColor = Color.Red;
                        }
                        break;
                    case 13:
                        var orderTypeDetailsList = e.Value as IList<OrderTypeDetails>;
                        if (orderTypeDetailsList != null && orderTypeDetailsList.Count > 0)
                        {
                            StringBuilder orderTypeSb = new StringBuilder();
                            foreach (var orderTypeDetails in orderTypeDetailsList)
                            {
                                orderTypeSb.AppendFormat("{0}({1}) ",
                                    orderTypeDetails.Name, orderTypeDetails.Count);
                            }
                            e.Value = orderTypeSb.ToString();
                        }
                        else
                        {
                            e.Value = string.Empty;
                        }
                        break;
                }
            };

            sdgvSubAccountList.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex == -1)
                {
                    return;
                }

                if (e.ColumnIndex == 10)
                {
                    var row = sdgvSubAccountList.Rows[e.RowIndex];
                    var value = row.Cells[e.ColumnIndex].FormattedValue.ToString();
                    if (string.Equals(value, "连接"))
                    {
                        if (_remoteDeskConnectState.Connected)
                        {
                            MessageBoxEx.Show(this,
                                "已经连接挂机端操作，不能同时进行多个连接操作！",
                                "连接挂机端",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //开始连接前，关闭所有连接窗口。
                        while (AnyDesk.IsClientOpened())
                        {
                            AnyDesk.CloseClient();
                        }

                        if ((bool)row.Cells[8].Value)
                        {
                            _remoteDeskConnectState.Connected = true;
                            var view = _viewFactory.GetView<ViewReadyConnectClient>();
                            view.Model = row.DataBoundItem as UserSubAccountPageListVM;
                            if (view.ShowDialog(this) != DialogResult.OK)
                            {
                                _remoteDeskConnectState.Connected = false;
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show(this,
                               "该挂机端不在线，不能连接！\r\n\r\n可尝试刷新挂机端信息后，再进行操作。",
                               "连接挂机端",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        while (AnyDesk.IsClientOpened())
                        {
                            AnyDesk.CloseClient();
                        }
                        StartOrderRecord();
                    }
                }
            };

            scbProvince.SelectedIndexChanged += (sender, e) =>
            {
                if (scbProvince.SelectedIndex != -1)
                {
                    var value = scbProvince.SelectedItem as Province;
                    if (value.ProvinceID != -1)
                    {
                        scbCity.DisplayMember = "CityName";
                        scbCity.DataSource = _areaBll.GetCityList(value.ProvinceID);
                    }
                    else
                    {
                        scbCity.DataSource = null;
                        scbDistrict.DataSource = null;
                    }
                }
                else
                {
                    scbCity.DataSource = null;
                    scbDistrict.DataSource = null;
                }
            };

            scbCity.SelectedIndexChanged += (sender, e) =>
            {
                if (scbCity.SelectedIndex != -1)
                {
                    var value = scbCity.SelectedItem as City;
                    if (value.CityID != -1)
                    {
                        scbDistrict.DisplayMember = "DistrictName";
                        scbDistrict.DataSource = _areaBll.GetDistrictList(value.CityID);
                    }
                    else
                    {
                        scbDistrict.DataSource = null;
                    }
                }
                else
                {
                    scbDistrict.DataSource = null;
                }
            };

            tsmiSubAccManage.Click += (sender, e) =>
            {
                var view = _viewFactory.GetView<ViewSubAccountManage>();
                view.ShowDialog(this);
            };

            tsmiShopManage.Click += (sender, e) =>
            {
                var view = _viewFactory.GetView<ViewShopManage>();
                view.ShowDialog(this);
            };

            tsmiAccountInfo.Click += (sender, e) =>
            {
                var view = _viewFactory.GetView<ViewUserInfo>();
                view.ShowDialog(this);
            };

            tsmiChangePwd.Click += (sender, e) =>
            {
                var view = _viewFactory.GetView<ViewChangePassword>();
                view.ShowDialog(this);
            };

            tsmiAbout.Click += (sender, e) =>
            {
                var view = _viewFactory.GetView<ViewAbout>();
                view.ShowDialog(this);
            };

            paginationSubAccount.Reload += (sender, e) =>
            {
                LoadSubAccountPageList(
                    paginationSubAccount.PageIndex, paginationSubAccount.PageSize);
            };

            sbtnSearch.Click += (sender, e) =>
            {
                LoadSubAccountPageList(
                    1, paginationSubAccount.PageSize);
            };
        }

        void LoadSubAccountPageList(int pageIndex, int pageSize)
        {
            if (_remoteDeskConnectState.Connected)
            {
                MessageBoxEx.Show(this, "当前正在远程操作挂机端，不允许刷新挂机端数据！",
                    "刷新挂机端数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _subAccountBll.GetPageList(new PageListQueryInfo<UserSubAccountPageListQuery>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = new UserSubAccountPageListQuery
                {
                    ProvinceName = scbProvince.Text,
                    CityName = scbCity.Text,
                    DistrictName = scbDistrict.Text
                }
            }, response =>
            {
                string info = string.Empty;
                switch (response.State)
                {
                    case UserSubAccountOptState.CannotConnectServer:
                        info = "服务器连接失败，未能获挂机端列表信息！";
                        break;
                    case UserSubAccountOptState.Failed:
                        info = "服务器异常，获取挂机端列表信息失败!";
                        break;
                    case UserSubAccountOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                }

                Invoke(() =>
                {
                    if (response.State != UserSubAccountOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取挂机端列表信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    sdgvSubAccountList.DataSource = response.Data.List;
                    paginationSubAccount.Count = response.Data.Info.Count;
                    paginationSubAccount.PageIndex = pageIndex;
                });
            });
        }

        internal void LoadOrderRecordPageList(int pageIndex, int pageSize,
            int? shopId = null, int? orderStateId = null)
        {
            if (_remoteDeskConnectState.Connected)
            {
                MessageBoxEx.Show(this, "当前正在远程操作挂机端，不允许刷新数据！",
                    "刷新数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _orderRecordBll.GetPageList(new PageListQueryInfo<OrderRecordPageListQuery>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = new OrderRecordPageListQuery
                {
                    ShopId = shopId,
                    OrderStateId = orderStateId
                }
            }, response =>
            {
                string info = string.Empty;
                switch (response.State)
                {
                    case OrderRecordOptState.CannotConnectServer:
                        info = "服务器连接失败，未能获刷单列表信息！";
                        break;
                    case OrderRecordOptState.Failed:
                        info = "服务器异常，获取刷单列表信息失败!";
                        break;
                    case OrderRecordOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                }

                Invoke(() =>
                {
                    if (response.State != OrderRecordOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取刷单列表信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    _orderRecordControl.SdgvOrderRecordList
                        .DataSource = response.Data.List;
                    _orderRecordControl.PaginationOrderRecordList
                        .Count = response.Data.Info.Count;
                    _orderRecordControl.PaginationOrderRecordList.PageIndex = pageIndex;
                });
            });
        }

        internal void OnRemoteOperationRequest(
            UserSubAccountPageListVM model,
            ConnectOptFrom connectOptFrom = ConnectOptFrom.ClientList)
        {
            _remoteDeskConnectState.ConnectOptFrom = connectOptFrom;

            DataGridViewRow selectedRow;
            if (connectOptFrom == ConnectOptFrom.ClientList)
            {
                selectedRow = sdgvSubAccountList.SelectedRows[0];
                selectedRow.Cells[9].Value = "正在连接";
                selectedRow.Cells[10].Value = "断开连接";
            }
            else
            {
                selectedRow = _orderRecordControl.SdgvOrderRecordList.SelectedRows[0];
                selectedRow.Cells[8].Value = "正在连接";
                selectedRow.Cells[9].Value = "断开连接";
            }

            _remoteDeskConnectState.SelectedRow = selectedRow;
            _remoteDeskConnectState.ConnectModel = model;

            tsslRemoteConnectInfo.Text =
                string.Format("请求连接 [{0}] ...", model.UserAccount);

            _remoteOperationBll.RequestConnectToClient(
                model.UserId, model.Id, model.TaoBaoAccount, response =>
            {
                string info = string.Empty;
                switch (response.State)
                {
                    case RemoteOperationState.CannotConnectServer:
                        info = "服务器连接失败，未能获取挂机端远程连接信息";
                        break;
                    case RemoteOperationState.Failed:
                        info = "服务器异常，获取挂机端远程连接信息失败!";
                        break;
                    case RemoteOperationState.NotAuditShop:
                        info = "没有通过审核的店铺，不允许刷单!";
                        break;
                    case RemoteOperationState.ClientOffline:
                        info = "挂机端没有登录，不允许刷单！";
                        break;
                    case RemoteOperationState.Goldless:
                        info = "金币不足，不允许刷单！";
                        break;
                    case RemoteOperationState.ToClientOffline:
                        info = "该挂机端已离线！";
                        break;
                    case RemoteOperationState.ToClientBusy:
                        info = "该挂机端已有其他会员连接！";
                        break;
                    case RemoteOperationState.ToClientRemoteDesktopServiceError:
                        info = "该挂机端远程桌面服务出现错误！";
                        break;
                    case RemoteOperationState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                }

                Invoke(() =>
                {
                    if (response.State != RemoteOperationState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取挂机端远程连接信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (connectOptFrom == ConnectOptFrom.ClientList)
                        {
                            selectedRow.Cells[9].Value = null;
                            selectedRow.Cells[10].Value = null;
                        }
                        else
                        {
                            selectedRow.Cells[8].Value = null;
                            selectedRow.Cells[9].Value = null;
                        }

                        _remoteDeskConnectState.Connected = false;
                        _remoteDeskConnectState.ConnectModel = null;
                        _remoteDeskConnectState.ConnectOptFrom = ConnectOptFrom.ClientList;
                        tsslRemoteConnectInfo.Text = "未连接";
                        return;
                    }

                    var sourceFile = Path.Combine(Application.StartupPath, @"remotedesk\anydesk\anydesk.exe");
                    if (!File.Exists(sourceFile))
                    {
                        MessageBoxEx.Show(this, info, "远程桌面软件丢失，不能进行远程连接！",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (connectOptFrom == ConnectOptFrom.ClientList)
                        {
                            selectedRow.Cells[9].Value = null;
                            selectedRow.Cells[10].Value = null;
                        }
                        else
                        {
                            selectedRow.Cells[8].Value = null;
                            selectedRow.Cells[9].Value = null;
                        }

                        _remoteDeskConnectState.Connected = false;
                        _remoteDeskConnectState.ConnectModel = null;
                        _remoteDeskConnectState.ConnectOptFrom = ConnectOptFrom.ClientList;
                        tsslRemoteConnectInfo.Text = "未连接";
                        return;
                    }

                    Interlocked.Exchange(ref _remoteDeskpCheckTimerCallbackState, 0);
                    _remoteDeskConnectState.IsShowOrderRecordView = false;
                    _remoteDeskConnectState.TimerState = TimerState.CheckRemoteDeskConnectOpen;
                    _remoteDeskCheckTimer.Change(2000, 2000);
                    tsslRemoteConnectInfo.Text =
                        string.Format("开始连接 [{0}] ...", model.UserAccount);
                    AnyDesk.Connect(sourceFile, response.Data.RemoteId, response.Data.RemotePassword);
                });
            });
        }

        internal void CompleteRemoteOperation()
        {
            if (_remoteDeskConnectState.ConnectOptFrom == ConnectOptFrom.ClientList)
            {
                _remoteDeskConnectState.SelectedRow.Cells[9].Value = null;
                _remoteDeskConnectState.SelectedRow.Cells[10].Value = null;
            }
            else
            {
                _remoteDeskConnectState.SelectedRow.Cells[8].Value = null;
                _remoteDeskConnectState.SelectedRow.Cells[9].Value = null;
            }

            _remoteDeskConnectState.Connected = false;
            _remoteDeskConnectState.ConnectModel = null;
            _remoteDeskConnectState.SelectedRow = null;
            _remoteDeskConnectState.ConnectOptFrom = ConnectOptFrom.ClientList;
            tsslRemoteConnectInfo.Text = "未连接";
        }

        internal void StartOrderRecord()
        {
            if (_remoteDeskConnectState.IsShowOrderRecordView)
            {
                return;
            }

            _remoteDeskConnectState.IsShowOrderRecordView = true;

            try
            {
                var view = _viewFactory.GetView<ViewOrderRecordInfoOpt>();
                view.UserSubAccountPageListVM = _remoteDeskConnectState.ConnectModel;

                if (_remoteDeskConnectState.ConnectOptFrom == ConnectOptFrom.OrderRecorList)
                {
                    view.CurrentOrderRecord = _remoteDeskConnectState
                        .SelectedRow.DataBoundItem as OrderRecord;
                }

                if (view.ShowDialog(this) == DialogResult.OK)
                {
                    if (_remoteDeskConnectState.ConnectOptFrom == ConnectOptFrom.ClientList)
                    {
                        _remoteDeskConnectState.SelectedRow.Cells[9].Value = null;
                        _remoteDeskConnectState.SelectedRow.Cells[10].Value = null;
                    }
                    else
                    {
                        _remoteDeskConnectState.SelectedRow.Cells[8].Value = null;
                        _remoteDeskConnectState.SelectedRow.Cells[9].Value = null;
                    }

                    _remoteDeskConnectState.Connected = false;
                    _remoteDeskConnectState.ConnectModel = null;
                    _remoteDeskConnectState.SelectedRow = null;
                    _remoteDeskConnectState.ConnectOptFrom = ConnectOptFrom.ClientList;
                    tsslRemoteConnectInfo.Text = "未连接";
                    tsslConnectStartTimeLabel.Visible = false;
                    tsslConnectStartTime.Text = string.Empty;
                    tsslConnectStartTime.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Error("打开刷单记录窗口失败！", ex);
                MessageBoxEx.Show(this, "打开刷单记录窗口失败！",
                    "刷单记录", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _remoteDeskConnectState.IsShowOrderRecordView = false;
        }

        void RemoteDeskCheckTimerCallback(object state)
        {
            if (Interlocked.CompareExchange(ref _remoteDeskpCheckTimerCallbackState, 1, 1) == 1)
            {
                return;
            }

            try
            {
                bool started = AnyDesk.IsClientOpened();
                if (_remoteDeskConnectState.TimerState == TimerState.CheckRemoteDeskConnectOpen)
                {
                    if (started)
                    {
                        Invoke(() =>
                        {
                            tsslRemoteConnectInfo.Text =
                                string.Format("远程控制 [{0}] 中...",
                                _remoteDeskConnectState.ConnectModel.UserAccount);
                            tsslConnectStartTimeLabel.Visible = true;
                            tsslConnectStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            tsslConnectStartTime.Visible = true;
                        });

                        _remoteDeskConnectState.TimerState = TimerState.CheckRemoteDeskConnectClose;
                    }

                    return;
                }

                if (_remoteDeskConnectState.TimerState == TimerState.CheckRemoteDeskConnectClose)
                {
                    if (!started)
                    {
                        _remoteDeskCheckTimer.Change(Timeout.Infinite, 2000);
                        Invoke(() =>
                        {
                            StartOrderRecord();
                        });
                    }

                    return;
                }
            }
            catch (Exception ex)
            {
                Error("RemoteDeskCheckTimerCallback Error.", ex);
            }
            finally
            {
                Interlocked.Exchange(ref _remoteDeskpCheckTimerCallbackState, 0);
            }
        }
    }

    class RemoteDeskConnectState
    {
        int _connected;
        int _timerState;
        int _isShowOrderRecordView;
        ConnectOptFrom _connectOptFrom = ConnectOptFrom.ClientList;
        DataGridViewRow _selectedRow;
        UserSubAccountPageListVM _connectModel;
        readonly object _rootAsync = new object();

        public bool Connected
        {
            get
            {
                return Interlocked.CompareExchange(ref _connected, 1, 1) == 1;
            }
            set
            {
                if (value)
                {
                    Interlocked.Exchange(ref _connected, 1);
                }
                else
                {
                    Interlocked.Exchange(ref _connected, 0);
                }
            }
        }

        public bool IsShowOrderRecordView
        {
            get
            {
                return Interlocked.CompareExchange(ref _isShowOrderRecordView, 1, 1) == 1;
            }
            set
            {
                if (value)
                {
                    Interlocked.Exchange(ref _isShowOrderRecordView, 1);
                }
                else
                {
                    Interlocked.Exchange(ref _isShowOrderRecordView, 0);
                }
            }
        }

        public TimerState TimerState
        {
            get
            {
                if (Interlocked.CompareExchange(ref _timerState, 0, 0) == 0)
                {
                    return TimerState.CheckRemoteDeskConnectOpen;
                }

                return TimerState.CheckRemoteDeskConnectClose;
            }
            set
            {
                switch (value)
                {
                    case TimerState.CheckRemoteDeskConnectOpen:
                        Interlocked.Exchange(ref _timerState, 0);
                        break;
                    case TimerState.CheckRemoteDeskConnectClose:
                        Interlocked.Exchange(ref _timerState, 1);
                        break;
                }
            }
        }

        public ConnectOptFrom ConnectOptFrom
        {
            get
            {
                lock (_rootAsync)
                {
                    return _connectOptFrom;
                }
            }
            set
            {
                lock (_rootAsync)
                {
                    _connectOptFrom = value;
                }
            }
        }

        public UserSubAccountPageListVM ConnectModel
        {
            get
            {
                lock (_rootAsync)
                {
                    return _connectModel;
                }
            }
            set
            {
                lock (_rootAsync)
                {
                    _connectModel = value;
                }
            }
        }

        public DataGridViewRow SelectedRow
        {
            get
            {
                lock (_rootAsync)
                {
                    return _selectedRow;
                }
            }
            set
            {
                lock (_rootAsync)
                {
                    _selectedRow = value;
                }
            }
        }
    }

    enum ConnectOptFrom
    {
        ClientList,
        OrderRecorList
    }
}