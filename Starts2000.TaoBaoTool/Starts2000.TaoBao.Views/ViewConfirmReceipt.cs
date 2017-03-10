using System;
using System.Linq;
using System.Windows.Forms;
using CCWin;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewConfirmReceipt : ViewBaseEx
    {
        readonly string _taobaoUrl = "https://trade.taobao.com/trade/confirm_goods.htm?biz_order_id={0}";
        readonly string _1688AliUrl = "https://trade.1688.com/order/trade_flow.htm?alipayAction=confirm_receive_goods&orderId={0}&fromType=fromOrderList&tradeType=6&userType=buyer&productName=&startDate=&endDate=&buyerMemberId=&tradeStatus=&page=&sellerMemberId=&orderIdSearch=";

        readonly IViewFactory _viewFactory;

        public ViewConfirmReceipt(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
            InitializeComponent();
            SetToMax();

            timerInputKey.Tick += (sender, e) =>
            {
                if(!webBrowser.Focused)
                {
                    return;
                }

                string pwd = TripleDES.Decrypt3DES(ConfirmReceiptInfo.PayPassWord);
                foreach (char ch in pwd.ToUpper().ToCharArray())
                {
                    Keys keyCode = (Keys)ch;
                    KeyBoardHook.Key(keyCode);
                }

                timerInputKey.Stop();
                stbUrl.Visible = true;
            };

            sbtnGoto.Click += (sender, e) =>
            {
                webBrowser.Navigate(stbUrl.SkinTxt.Text);
            };

            sbtnBrowserSet.Click += (sender, e) =>
            {
                var view = _viewFactory.GetView<ViewBrowserSet>();
                view.ShowDialog(this);
                webBrowser.Refresh();
            };

            sbtnInpuPassword.Click += (sender, e) =>
            {
                string url = webBrowser.Url.ToString().ToLower();

                if (url.IndexOf("trade") <= 0)
                {
                    MessageBoxEx.Show(this, "\r\n    请求的地址错误!    \r\n", "输入支付密码");
                    return;
                }

                if (url.IndexOf(ConfirmReceiptInfo.OrderNum) <= 0)
                {
                    MessageBoxEx.Show(this, "\r\n    请求的订单号错误!    \r\n", "输入支付密码");
                    return;
                }

                if (url.IndexOf("https://trade.taobao.com/trade/confirm_goods.htm") != 0 &&
                    url.IndexOf("https://trade.1688.com/order/trade_flow.htm") != 0 &&
                    url.IndexOf("https://trade.tmall.com/order/confirmgoods.htm") != 0)
                {
                    MessageBoxEx.Show(this, "\r\n    请求的地址错误!    \r\n", "输入支付密码");
                    return;
                }

                base.TopMost = true;
                stbUrl.Visible = false;
                timerInputKey.Start();
            };

            webBrowser.NewWindow3 += (sender, e) =>
            {
                e.Cancel = true;
                webBrowser.Navigate(e.Url);
            };
        }

        internal ECommercePlatform ECommercePlatform
        {
            private get;
            set;
        }

        internal OrderRecordConfirmReceiptInfo ConfirmReceiptInfo
        {
            private get;
            set;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            webBrowser.DocumentCompleted += (sender, dce) =>
            {
                try
                {
                    if (webBrowser.Document != null && webBrowser.Document.Body != null)
                    {
                        stbUrl.SkinTxt.Text = dce.Url.ToString();
                        webBrowser.Document.GetElementsByTagName("input")
                            .OfType<HtmlElement>().ToList().ForEach(ele =>
                            {
                                var type = ele.GetAttribute("type");
                                if (type != "checkbox" && type != "radio")
                                {
                                    ele.SetAttribute("disabled", "disabled");
                                    ele.SetAttribute("readonly", "readonly");
                                }
                            });
                    }
                }
                catch
                {

                }
            };

            switch(ECommercePlatform)
            {
                case ECommercePlatform.TaoBao:
                    webBrowser.Navigate(string.Format(_taobaoUrl, ConfirmReceiptInfo.OrderNum));
                    break;
                case ECommercePlatform.Ali1688:
                    webBrowser.Navigate(string.Format(_1688AliUrl, ConfirmReceiptInfo.OrderNum));
                    break;
            }
        }
    }
}