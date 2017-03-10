using System;
using System.Windows.Forms;
using CCWin;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewShopManage : ViewBaseEx
    {
        readonly IViewFactory _viewFacktory;
        readonly IShopBll _shopBll;

        public ViewShopManage(IViewFactory viewFacktory, IShopBll shopBll)
        {
            InitializeComponent();
            _viewFacktory = viewFacktory;
            _shopBll = shopBll;
            Init();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BindShopList();
        }

        void Init()
        {
            sdgvShopList.AutoGenerateColumns = false;
            sbtnAdd.Click += (sender, e) =>
            {
                var view = _viewFacktory.GetView<ViewAddShop>();
                view.ShowDialog(this);
            };

            sbtnDelete.Click += (sender, e) =>
            {
                if (sdgvShopList.SelectedRows.Count == 0 || sdgvShopList.SelectedRows[0].IsNewRow)
                {
                    MessageBoxEx.Show(this, "请选择需要删除的店铺信息！",
                        "删除店铺信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = (int)sdgvShopList.SelectedRows[0].Cells["ColId"].Value;
                _shopBll.Delete(new Shop { Id = id }, state =>
                {
                    string info = string.Empty;
                    switch (state)
                    {
                        case ShopOptState.CannotConnectServer:
                            info = "服务器连接失败，未能删除店铺信息！";
                            break;
                        case ShopOptState.Failed:
                            info = "服务器异常，删除店铺信息失败!";
                            break;
                        case ShopOptState.InvalidOpt:
                            info = "非法操作！与服务器连接断开，请稍后重试！";
                            break;
                        case ShopOptState.Successed:
                            info = "删除店铺信息成功！";
                            break;
                    }

                    Invoke(() =>
                    {
                        MessageBoxEx.Show(this, info, "删除店铺信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(state == ShopOptState.Successed)
                        {
                            BindShopList();
                        }
                    });
                });
            };
        }

        internal void BindShopList()
        {
            _shopBll.GetList(false, listResponse =>
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
                    case ShopOptState.Successed:
                        break;
                }

                Invoke(() =>
                {
                    if (listResponse.State != ShopOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取店铺信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    sdgvShopList.DataSource = listResponse.Data;
                });
            });
        }
    }
}