using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CCWin;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class OrderRecordListControl : UserControl
    {
        readonly IOrderStateBll _orderStateBll;
        readonly IShopBll _shopBll;
        IList<OrderState> _orderStates;

        public OrderRecordListControl(IShopBll shopBll, IOrderStateBll orderStateBll)
        {
            InitializeComponent();
            SdgvOrderRecordList.AutoGenerateColumns = false;
            _orderStateBll = orderStateBll;
            _shopBll = shopBll;
            Init();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BindShopList();
            BindOrderState();
        }

        void Init()
        {
            SdgvOrderRecordList.CellFormatting += (sender, e) =>
            {
                switch (e.ColumnIndex)
                {
                    case 3:
                        if (_orderStates == null)
                        {
                            _orderStates = _orderStateBll.GetList();
                        }

                        var curState = _orderStates.FirstOrDefault(state =>
                        {
                            return state.Id == (int)e.Value;
                        });

                        e.Value = curState == null ? string.Empty : curState.Name;
                        break;
                    case 4:
                    case 5:
                        if (e.Value != null)
                        {
                            var dateTime = (DateTime)e.Value;
                            e.Value = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        break;
                    case 6:
                        var cell = SdgvOrderRecordList.Rows[e.RowIndex].Cells[4];
                        if (cell.Value != null)
                        {
                            var dateTime = (DateTime)cell.Value;
                            dateTime = dateTime.AddDays(30);
                            e.Value = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

                            if (dateTime <= DateTime.Now)
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.SelectionBackColor = Color.Red;
                                return;
                            }

                            if (dateTime.AddDays(-5) <= DateTime.Now)
                            {
                                e.CellStyle.BackColor = Color.Yellow;
                                e.CellStyle.SelectionBackColor = Color.Yellow;
                                return;
                            }
                        }
                        break;
                    case 7:
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
                    case 8:
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
                    case 9:
                        var cell3 = SdgvOrderRecordList.Rows[e.RowIndex].Cells[3];
                        if (cell3.Value != null)
                        {
                            var stateId = (int)cell3.Value;
                            if (stateId == 999999 || stateId == 40)
                            {
                                e.Value = "已完结";
                                return;
                            }
                        }

                        var cell4 = SdgvOrderRecordList.Rows[e.RowIndex].Cells[4];
                        if (cell4.Value != null)
                        {
                            var dateTime = (DateTime)cell4.Value;
                            dateTime = dateTime.AddDays(30);
                            if (dateTime <= DateTime.Now)
                            {
                                e.Value = "已完结";
                                return;
                            }
                        }

                        if (e.Value == null)
                        {
                            e.Value = "连接";
                        }
                        break;
                }
            };

            SdgvOrderRecordList.CellContentClick += SdgvOrderRecordListCellContentClick;

            PaginationOrderRecordList.Reload += Reload;
            sbtnSearch.Click += Reload;
        }

        void SdgvOrderRecordListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                var parent = FindForm() as ViewOptMain;
                if (parent == null)
                {
                    return;
                }

                var row = SdgvOrderRecordList.Rows[e.RowIndex];
                var value = row.Cells[9].FormattedValue.ToString();
                if (string.Equals(value, "连接"))
                {
                    if (parent.RemoteDeskConnectState.Connected)
                    {
                        MessageBoxEx.Show(this,
                            "已经连接挂机端操作，不能同时进行多个连接操作！",
                            "连接挂机端",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if ((bool)row.Cells[7].Value)
                    {
                        parent.RemoteDeskConnectState.Connected = true;
                        var orcderRecord = row.DataBoundItem as OrderRecordDetails;
                        parent.OnRemoteOperationRequest(new UserSubAccountPageListVM
                        {
                            UserId = orcderRecord.ClientUserId,
                            Id = orcderRecord.ClientUserSubAccountId,
                            UserAccount = orcderRecord.ClientUserAccount,
                            TaoBaoAccount = orcderRecord.ClientUserSubAccount
                        }, ConnectOptFrom.OrderRecorList);
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
                else if (string.Equals(value, "已完结"))
                {
                    MessageBoxEx.Show(this,
                        "该刷单操作已完结，不能再进行操作。",
                        "连接挂机端",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (AnyDesk.IsClientOpened())
                    {
                        AnyDesk.CloseClient();
                    }

                    parent.StartOrderRecord();
                }
            }
        }

        void Reload(object sender, EventArgs e)
        {
            var parent = FindForm() as ViewOptMain;
            if (parent != null)
            {
                int? shopId = null;
                int? orderStateId = null;

                var shop = scbShop.SelectedItem as Shop;
                if (shop != null && shop.Id != -1)
                {
                    shopId = shop.Id;
                }

                var orderState = scbOrderState.SelectedItem as OrderState;
                if (orderState != null && orderState.Id != -1)
                {
                    orderStateId = orderState.Id;
                }

                parent.LoadOrderRecordPageList(
                    PaginationOrderRecordList.PageIndex,
                    PaginationOrderRecordList.PageSize,
                    shopId, orderStateId);
            }
        }
        void BindShopList()
        {
            _shopBll.GetList(true, listResponse =>
            {
                string info = string.Empty;
                switch (listResponse.State)
                {
                    case ShopOptState.CannotConnectServer:
                        info = "服务器连接失败，未能获取店铺信息！";
                        break;
                    case ShopOptState.Failed:
                        info = "服务器异常，获取店铺信息失败!";
                        break;
                    case ShopOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                }

                Invoke((Action)(() =>
                {
                    if (listResponse.State != ShopOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取店铺信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    scbShop.DisplayMember = "WangWangAccount";
                    if (listResponse.Data != null)
                    {
                        listResponse.Data.Insert(0, new Shop
                        {
                            Id = -1,
                            WangWangAccount = string.Empty
                        });
                    }
                    scbShop.DataSource = listResponse.Data;
                }));
            });
        }

        void BindOrderState()
        {
            if (_orderStates == null)
            {
                _orderStates = _orderStateBll.GetList();
            }

            _orderStates.Insert(0, new OrderState
            {
                Id = -1,
                Name = string.Empty
            });

            scbOrderState.DisplayMember = "Name";
            scbOrderState.DataSource = _orderStates;
        }
    }
}
