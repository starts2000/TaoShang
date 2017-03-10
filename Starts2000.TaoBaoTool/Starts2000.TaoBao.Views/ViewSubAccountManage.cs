using System;
using System.Windows.Forms;
using CCWin;
using Ninject;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewSubAccountManage : ViewBaseEx
    {
        readonly IViewFactory _viewFacktory;
        readonly IUserSubAccountBll _subAccountBll;

        public ViewSubAccountManage(IViewFactory viewFacktory, IUserSubAccountBll subAccountBll)
        {
            InitializeComponent();
            _viewFacktory = viewFacktory;
            _subAccountBll = subAccountBll;
            Init();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BindUserSubAccountList();
        }

        void Init()
        {
            sdgvSubAccountList.AutoGenerateColumns = false;
            sdgvSubAccountList.CellFormatting += (sender, e) =>
            {
                switch(e.ColumnIndex)
                {
                    case 2:
                        byte? value = e.Value as byte?;
                        if(value.HasValue)
                        {
                            e.Value = ConstData.TaoBaoLevels[value.Value - 1].Name;
                        }
                        break;
                }
            };

            sbtnAdd.Click += (sender, e) =>
            {
                var view = _viewFacktory.GetView<ViewAddSubAccount>();
                view.ShowDialog(this);
            };

            sbtnUpdate.Click += (sender, e) =>
            {
                if (sdgvSubAccountList.SelectedRows.Count == 0 || sdgvSubAccountList.SelectedRows[0].IsNewRow)
                {
                    MessageBoxEx.Show(this, "请选择需要修改信息的小号！",
                        "修改小号信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var view = _viewFacktory.GetView<ViewUpdateSubAccount>();
                view.SubAccount = sdgvSubAccountList.SelectedRows[0].DataBoundItem as UserSubAccount;
                view.ShowDialog(this);
            };

            sbtnDelete.Click += (sender, e) =>
            {
                if (sdgvSubAccountList.SelectedRows.Count == 0 || sdgvSubAccountList.SelectedRows[0].IsNewRow)
                {
                    MessageBoxEx.Show(this, "请选择需要删除的小号信息！",
                        "删除小号信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = (int)sdgvSubAccountList.SelectedRows[0].Cells["ColId"].Value;
                _subAccountBll.Delete(new UserSubAccount { Id = id }, state =>
                {
                    string info = string.Empty;
                    switch (state)
                    {
                        case UserSubAccountOptState.CannotConnectServer:
                            info = "服务器连接失败，未能删除小号信息！";
                            break;
                        case UserSubAccountOptState.Failed:
                            info = "服务器异常，删除小号信息失败!";
                            break;
                        case UserSubAccountOptState.InvalidOpt:
                            info = "非法操作！与服务器连接断开，请稍后重试！";
                            break;
                        case UserSubAccountOptState.Successed:
                            info = "删除小号信息成功！";
                            break;
                    }

                    Invoke(() =>
                    {
                        MessageBoxEx.Show(this, info, "删除小号信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (state == UserSubAccountOptState.Successed)
                        {
                            BindUserSubAccountList();
                        }
                    });
                });
            };
        }

        internal void BindUserSubAccountList()
        {
            _subAccountBll.GetList(listResponse =>
            {
                string info = string.Empty;
                switch (listResponse.State)
                {
                    case UserSubAccountOptState.CannotConnectServer:
                        info = "服务器连接失败，未能获取小号信息！";
                        break;
                    case UserSubAccountOptState.Failed:
                        info = "服务器异常，获取小号信息失败!";
                        break;
                    case UserSubAccountOptState.InvalidOpt:
                        info = "非法操作！与服务器连接断开，请稍后重试！";
                        break;
                    case UserSubAccountOptState.Successed:
                        break;
                }

                Invoke(() =>
                {
                    if (listResponse.State != UserSubAccountOptState.Successed)
                    {
                        MessageBoxEx.Show(this, info, "获取小号信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    sdgvSubAccountList.DataSource = listResponse.Data;
                });
            });
        }
    }
}
