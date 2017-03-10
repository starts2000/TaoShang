using System;
using System.Windows.Forms;
using CCWin;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewUserInfo : ViewBaseEx
    {
        readonly IUserBll _userBll;

        public ViewUserInfo(IUserBll userBll)
        {
            InitializeComponent();

            _userBll = userBll;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                _userBll.GetInfo(response =>
                {
                    string info = string.Empty;

                    switch (response.State)
                    {
                        case UserOptState.Failed:
                            info = "服务器异常，获取用户信息失败！";
                            break;
                        case UserOptState.CannotConnectServer:
                            info = "连接服务器失败，未能获取用户信息";
                            break;
                        case UserOptState.InvalidOpt:
                            info = "非法操作！与服务器连接断开，请稍后重试！";
                            break;
                    }

                    Invoke(() =>
                    {
                        if (response.State != UserOptState.Successed)
                        {
                            MessageBoxEx.Show(this, info, "获取用户信息", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (response.Data != null)
                        {
                            lbAccount.Text = response.Data.Account;
                            lbGold.Text = response.Data.Gold.ToString();
                            if (response.Data.ExpireDate.HasValue)
                            {
                                lbExpireDate.Text = 
                                    response.Data.ExpireDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                lbExpireDate.Text = "未授权";
                            }
                        }
                    });
                });
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(this, "获取用户信息失败：" + ex.ToString(), "获取用户信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}