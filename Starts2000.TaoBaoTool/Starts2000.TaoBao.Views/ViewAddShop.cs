using System.Windows.Forms;
using CCWin;
using Ninject;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewAddShop : ViewBaseEx
    {
        readonly IShopBll _shopBll;

        public ViewAddShop(IShopBll shopBll)
        {
            InitializeComponent();
            _shopBll = shopBll;
            Init();
        }

        void Init()
        {
            RemoveErrorOnControlFocused(
                stbWagnWangAccount, stbWagnWangAccount.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(
                stbShopName, stbShopName.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(
                stbShopUrl, stbShopUrl.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(
                scbShopLevel, scbShopLevel, errorProvider);

            sbtnAddShop.Click += (sender, e) =>
            {
                if(!CheckControlTextNullOrEmpty(stbWagnWangAccount,
                    stbWagnWangAccount.SkinTxt, errorProvider, "淘宝旺旺号不能为空！"))
                {
                    return;
                }

                if(!CheckControlTextNullOrEmpty(stbShopName,
                    stbShopName.SkinTxt, errorProvider, "店铺名不能为空！"))
                {
                    return;
                }

                if(!CheckControlTextNullOrEmpty(stbShopUrl,
                    stbShopUrl.SkinTxt, errorProvider, "店铺网址不能为空！"))
                {
                    return;
                }

                if(!CheckControlTextNullOrEmpty(scbShopLevel,
                    scbShopLevel, errorProvider, "店铺等级不能为空！"))
                {
                    return;
                }

                _shopBll.Add(new Shop
                {
                    WangWangAccount = stbWagnWangAccount.SkinTxt.Text.Trim(),
                    ShopName = stbShopName.SkinTxt.Text.Trim(),
                    ShopLevel = scbShopLevel.Text.Trim(),
                    ShopUrl = stbShopUrl.SkinTxt.Text.Trim()
                }, state =>
                {
                    string info = string.Empty;

                    switch(state)
                    {
                        case ShopOptState.Failed:
                            info = "服务器异常，添加店铺失败！";
                            break;
                        case ShopOptState.CannotConnectServer:
                            info = "连接服务器失败！";
                            break;
                        case ShopOptState.InvalidOpt:
                            info = "非法操作！与服务器连接断开，请稍后重试！";
                            break;
                        case ShopOptState.Successed:
                            info = "添加店铺成功！";
                            break;
                    }

                    Invoke(() =>
                    {
                        MessageBoxEx.Show(this, info, "添加店铺", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(state == ShopOptState.Successed)
                        {
                            Clear();
                            var owner = this.Owner as ViewShopManage;
                            if (owner != null)
                            {
                                owner.BindShopList();
                            }
                        }
                    });
                });
            };
        }

        void Clear()
        {
            stbWagnWangAccount.SkinTxt.Text = string.Empty;
            stbShopName.SkinTxt.Text = string.Empty;
            stbShopUrl.SkinTxt.Text = string.Empty;
            scbShopLevel.Text = string.Empty;
        }
    }
}
