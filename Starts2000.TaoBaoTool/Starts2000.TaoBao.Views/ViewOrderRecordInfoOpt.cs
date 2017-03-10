using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CCWin;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewOrderRecordInfoOpt : ViewBaseEx
    {
        readonly IOrderStateBll _orderStateBll;
        readonly IOrderRecordBll _orderRecordBll;
        readonly IShopBll _shopBll;
        readonly IOrderTypeBll _orderTypeBll;

        public ViewOrderRecordInfoOpt(IOrderStateBll orderStateBll, 
            IShopBll shopBll, IOrderTypeBll orderTypeBll, IOrderRecordBll orderRecordBll)
        {
            InitializeComponent();

            _orderStateBll = orderStateBll;
            _shopBll = shopBll;
            _orderTypeBll = orderTypeBll;
            _orderRecordBll = orderRecordBll;
            Init();
        }

        internal UserSubAccountPageListVM UserSubAccountPageListVM
        {
            private get;
            set;
        }

        internal OrderRecord CurrentOrderRecord
        {
            get;
            set;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadOrderState();
            LoadShopList();
        }

        void LoadOrderState()
        {
            var orderStateList = _orderStateBll.GetList();
            orderStateList.Insert(0, new OrderState
            {
                Id = -1,
                Name = string.Empty
            });
            scbOrderState.DisplayMember = "Name";
            scbOrderState.DataSource = orderStateList;
        }

        void LoadShopList()
        {
            _shopBll.GetList(true, response =>
            {
                string info = string.Empty;
                switch (response.State)
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
                    case ShopOptState.Successed:
                        break;
                }

                Invoke(() =>
                {
                    if (response.State != ShopOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取店铺信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var shopList = response.Data;
                    shopList.Insert(0, new Shop
                        {
                            Id = -1,
                            WangWangAccount = string.Empty
                        });
                    scbShopAccount.DisplayMember = "WangWangAccount";
                    scbShopAccount.DataSource = shopList;

                    LoadOrderType();
                });
            });
        }

        void LoadOrderType()
        {
            _orderTypeBll.GetList(response =>
            {
                string info = string.Empty;
                switch (response.State)
                {
                    case OrderTypeOptState.CannotConnectServer:
                        info = "服务器连接失败，未能获订单类别信息！";
                        break;
                    case OrderTypeOptState.Failed:
                        info = "服务器异常，获取订单类别失败!";
                        break;
                    case OrderTypeOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                }

                Invoke(() =>
                {
                    if (response.State != OrderTypeOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取订单类别信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var orderTypeList = response.Data;
                    orderTypeList.Insert(0, new OrderType
                    {
                        Id = -1,
                        Name = string.Empty
                    });
                    scbOrderType.DisplayMember = "Name";
                    scbOrderType.DataSource = orderTypeList;

                    LoadOrderRecord();
                });
            });
        }

        void LoadOrderRecord()
        {
            if(CurrentOrderRecord != null)
            {
                BindCurrentOrderRecordInfo();
                return;
            }

            _orderRecordBll.Get(UserSubAccountPageListVM.Id, response =>
            {
                string info = string.Empty;

                switch (response.State)
                {
                    case OrderRecordOptState.CannotConnectServer:
                        info = "服务器连接失败，未能获取刷单信息！";
                        break;
                    case OrderRecordOptState.Failed:
                        info = "服务器异常，获取刷单信息失败!";
                        break;
                    case OrderRecordOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                }

                Invoke(() =>
                {
                    if (response.State != OrderRecordOptState.Successed)
                    {
                        MessageBoxEx.Show(this, "获取刷单信息", info,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    CurrentOrderRecord = response.Data;
                    BindCurrentOrderRecordInfo();
                });
            });
        }

        void BindCurrentOrderRecordInfo()
        {
            if(CurrentOrderRecord == null)
            {
                stbSubAcount.SkinTxt.Text = UserSubAccountPageListVM.TaoBaoAccount;
                lbStartDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                lbLastDateTime.Text = lbStartDateTime.Text;
                lbEndDateTime.Text = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd HH:mm:ss");
                return;
            }

            var orderStateList = scbOrderState.DataSource as IList<OrderState>;
            scbOrderState.SelectedItem = orderStateList.First(state =>
            {
                return state.Id == CurrentOrderRecord.OrderStateId;
            });

            var shopList = scbShopAccount.DataSource as IList<Shop>;
            scbShopAccount.SelectedItem = shopList.First<Shop>(shop =>
            {
                return shop.Id == CurrentOrderRecord.UserShopId;
            });
            scbShopAccount.Enabled = false;

            if (CurrentOrderRecord.OrderTypeId != null)
            {
                var orderTypeList = scbOrderType.DataSource as IList<OrderType>;
                scbOrderType.SelectedItem = orderTypeList.FirstOrDefault(orderType =>
                {
                    return orderType.Id == CurrentOrderRecord.OrderTypeId;
                });

                scbOrderType.Enabled = false;
            }

            stbSubAcount.SkinTxt.Text = CurrentOrderRecord.ClientUserSubAccount;

            lbStartDateTime.Text = CurrentOrderRecord
                .StartDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            lbLastDateTime.Text = CurrentOrderRecord
                .LastUpdateDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            lbEndDateTime.Text = CurrentOrderRecord
                .StartDateTime.AddDays(30).ToString("yyyy-MM-dd HH:mm:ss");

            if (!string.IsNullOrEmpty(CurrentOrderRecord.OrderNum))
            {
                stbOrderNum.SkinTxt.Text = CurrentOrderRecord.OrderNum;
                stbOrderNum.Enabled = false;
            }
        }

        void Init()
        {
            RemoveErrorOnControlFocused(scbOrderState, scbOrderState, errorProvider);
            RemoveErrorOnControlFocused(scbShopAccount, scbShopAccount, errorProvider);
            RemoveErrorOnControlFocused(scbOrderType, scbOrderType, errorProvider);
            RemoveErrorOnControlFocused(stbOrderNum, stbOrderNum.SkinTxt, errorProvider);

            sbtnOk.Click += (sender, e) =>
            {
                if(CurrentOrderRecord == null)
                {
                    AddOrderRecord();
                }
                else
                {
                    UpdateOrderRecord();
                }
            };
        }

        void AddOrderRecord()
        {
            var orderState = scbOrderState.SelectedItem as OrderState;
            if (orderState.Id == -1)
            {
                errorProvider.SetError(scbOrderState, "必须选择刷单状态！");
                return;
            }

            Shop shop = null;
            OrderType orderType = null;

            if (orderState.Id != 999999)
            {
                shop = scbShopAccount.SelectedItem as Shop;
                if (shop.Id == -1)
                {
                    errorProvider.SetError(scbShopAccount, "必须选择店铺掌柜！");
                    return;
                }

                orderType = scbOrderType.SelectedItem as OrderType;
                if (orderType.Id == -1)
                {
                    errorProvider.SetError(scbOrderType, "必须选择刷单类别！");
                    return;
                }
            }

            if (orderState.Id >= 20 && orderState.Id <= 40)
            {
                if (string.IsNullOrEmpty(stbOrderNum.SkinTxt.Text))
                {
                    errorProvider.SetError(stbOrderNum, "必须输入订单号！");
                    return;
                }
            }

            Action<OrderRecordOptState> addResponse = state =>
            {
                string info = string.Empty;

                switch (state)
                {
                    case OrderRecordOptState.CannotConnectServer:
                        info = "服务器连接失败，未能保存刷单信息！";
                        break;
                    case OrderRecordOptState.Failed:
                        info = "服务器异常，保存刷单信息失败!";
                        break;
                    case OrderRecordOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                    case OrderRecordOptState.DeductionGold:
                        info = "首次远程刷单操作成功，扣除 100 金币。\r\n\r\n请在30天内完成刷单！";
                        break;
                    case OrderRecordOptState.ReturnGold:
                        info = "刷单失败，本次刷单未扣除金币。";
                        break;
                }

                Invoke(() =>
                {
                    if (state != OrderRecordOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "保存刷单信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if(state != OrderRecordOptState.DeductionGold &&
                        state != OrderRecordOptState.ReturnGold && 
                        state != OrderRecordOptState.Successed)
                    {
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                });
            };

            _orderRecordBll.Add(new OrderRecord
            {
                ClientUserId = UserSubAccountPageListVM.UserId,
                ClientUserSubAccountId = UserSubAccountPageListVM.Id,
                OrderStateId = orderState.Id,
                OrderTypeId = orderType == null ? null : (int?)orderType.Id,
                UserShopId = shop == null ? null : (int?)shop.Id,
                OrderNum = stbOrderNum.SkinTxt.Text.Trim(),
                StartDateTime = DateTime.Parse(lbStartDateTime.Text),
                LastUpdateDateTime = DateTime.Now,
                OrderIp = UserSubAccountPageListVM.IpAddress
            }, addResponse);
        }

        void UpdateOrderRecord()
        {
            var orderState = scbOrderState.SelectedItem as OrderState;
            if (orderState.Id == -1)
            {
                errorProvider.SetError(scbOrderState, "必须选择刷单状态！");
                return;
            }

            if (orderState.Id == 999999 || orderState.Id < CurrentOrderRecord.OrderStateId)
            {
                errorProvider.SetError(scbOrderState, 
                    "刷单状态不能倒退选择，必须保持当前刷单状态或选择下一个刷单状态！");
                var orderStateList = scbOrderState.DataSource as IList<OrderState>;
                scbOrderState.SelectedItem = orderStateList.First(state =>
                {
                    return state.Id == CurrentOrderRecord.OrderStateId;
                });
                return;
            }

            if (orderState.Id >= 20)
            {
                if (string.IsNullOrEmpty(stbOrderNum.SkinTxt.Text))
                {
                    errorProvider.SetError(stbOrderNum, "必须输入订单号！");
                    return;
                }
            }

            Action<OrderRecordOptState> updateResponse = state =>
            {
                string info = string.Empty;

                switch (state)
                {
                    case OrderRecordOptState.CannotConnectServer:
                        info = "服务器连接失败，未能更新刷单信息！";
                        break;
                    case OrderRecordOptState.Failed:
                        info = "服务器异常，更新刷单信息失败!";
                        break;
                    case OrderRecordOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                }

                Invoke(() =>
                {
                    if (state != OrderRecordOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "更新刷单信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                });
            };

            _orderRecordBll.Update(new OrderRecord
            {
                Id = CurrentOrderRecord.Id,
                ClientUserSubAccountId = CurrentOrderRecord.ClientUserSubAccountId,
                OrderStateId = orderState.Id,
                OrderNum = stbOrderNum.SkinTxt.Text.Trim(),
                LastUpdateDateTime = DateTime.Now,
                OrderIp = CurrentOrderRecord.OrderIp
            }, updateResponse);
        }
    }
}
