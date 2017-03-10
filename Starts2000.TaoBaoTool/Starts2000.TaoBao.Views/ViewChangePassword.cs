using System;
using System.Windows.Forms;
using CCWin;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewChangePassword : ViewBaseEx
    {
        readonly IUserBll _userBll;
        readonly ILoginCfgBll _loginCfgBll;
        readonly IGlobalApplicationData _globalApplicationData;

        public ViewChangePassword(IUserBll userBll,
            ILoginCfgBll loginCfgBll, IGlobalApplicationData globalApplicationData)
        {
            InitializeComponent();
            _userBll = userBll;
            _loginCfgBll = loginCfgBll;
            _globalApplicationData = globalApplicationData;
            sbtnOk.Click += sbtnOk_Click;

            RemoveErrorOnControlFocused(stbOldPassword, stbOldPassword.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(stbNewPassword, stbNewPassword.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(stbConfirmNewPassword, stbConfirmNewPassword.SkinTxt, errorProvider);
        }

        void sbtnOk_Click(object sender, EventArgs e)
        {
            if(!CheckControlTextNullOrEmpty(stbOldPassword, 
                stbOldPassword.SkinTxt, errorProvider, "原密码不能为空。"))
            {
                return;
            }

            if (!CheckControlTextNullOrEmpty(stbNewPassword,
                stbNewPassword.SkinTxt, errorProvider, "新密码不能为空。"))
            {
                return;
            }

            if (!CheckControlTextNullOrEmpty(stbConfirmNewPassword,
                stbConfirmNewPassword.SkinTxt, errorProvider, "确认密码不能为空。"))
            {
                return;
            }

            if (!stbConfirmNewPassword.SkinTxt.Text.Trim().Equals(stbNewPassword.SkinTxt.Text.Trim()))
            {
                errorProvider.SetError(stbConfirmNewPassword, "确认密码与输入的新密码不一致！");
                return;
            }

            var changePassword = new ChangePassword
            {
                OldPassword = MD5Encrypt.GetMD5(stbOldPassword.SkinTxt.Text.Trim()),
                NewPassword = stbNewPassword.SkinTxt.Text.Trim()
            };

            _userBll.ChangePassword(changePassword, state =>
            {
                string info = string.Empty;

                switch (state)
                {
                    case ChangePasswordState.Failed:
                        info = "服务器异常，修改密码失败！";
                        break;
                    case ChangePasswordState.CannotConnectServer:
                        info = "连接服务器失败！";
                        break;
                    case ChangePasswordState.InvalidOpt:
                        info = "非法操作或与服务器连接断开，请稍后重试！";
                        break;
                    case ChangePasswordState.InvalidOldPassword:
                        info = "原密码输入错误！";
                        break;
                    case ChangePasswordState.InvalidNewPassword:
                        info = "新密码输入格式错误！";
                        break;
                    case ChangePasswordState.Successed:
                        info = "修改密码成功！";
                        break;
                }

                Invoke(() =>
                {
                    MessageBoxEx.Show(this, info, "修改密码", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (state == ChangePasswordState.Successed)
                    {
                        var user = _globalApplicationData.ApplicationData.User;
                        user.Password = MD5Encrypt.GetMD5(changePassword.NewPassword);
                        _loginCfgBll.UpdatePassword(user.Account, user.Password);
                    }
                });
            });
        }
    }
}