using System;
using System.Windows.Forms;
using CCWin;
using Ninject;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewRegister : ViewBaseEx
    {
        readonly IUserBll _userBll;        
        Action<RegisterState> _registerResponse;

        public ViewRegister(IUserBll userBll)
        {
            InitializeComponent();
            _userBll = userBll;
            Init();
        }

        void Init()
        {
            _registerResponse = state =>
            {
                Invoke(() =>
                {
                    switch (state)
                    {
                        case RegisterState.Failed:
                            MessageBoxEx.Show(this, "服务器异常，注册失败！", "帐号注册",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        case RegisterState.CannotConnectServer:
                            MessageBoxEx.Show(this, "连接服务器失败！", "帐号注册",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        case RegisterState.AccountExists:
                            MessageBoxEx.Show(this, "输入的帐号已存在，请重新输入！", "帐号注册",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            stbAccount.Focus();
                            stbAccount.SkinTxt.SelectAll();
                            return;
                        case RegisterState.InvalidAccount:
                            errorProvider.SetError(stbAccount, "帐号输入格式错误！");
                            return;
                        case RegisterState.InvalidPassword:
                            errorProvider.SetError(stbPassword, "密码输入格式错误！");
                            return;
                        case RegisterState.InvalidEmail:
                            errorProvider.SetError(stbEmail, "邮箱输入格式错误！");
                            return;
                        case RegisterState.InvalidQQ:
                            errorProvider.SetError(stbQQ, "QQ号码输入格式错误！");
                            return;
                        case RegisterState.InvalidMobile:
                            errorProvider.SetError(stbMobile, "手机号码输入格式错误！");
                            return;
                        case RegisterState.Successed:
                            MessageBoxEx.Show(this, "会员注册成功！", "会员注册",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            return;
                    }
                });
            };

            EventHandler tbFocus = (sender, e) =>
            {
                var control = sender as Control;
                errorProvider.SetError(control.Parent, string.Empty);
            };

            stbAccount.SkinTxt.GotFocus += tbFocus;
            stbPassword.SkinTxt.GotFocus += tbFocus;
            stbConfirmPassword.SkinTxt.GotFocus += tbFocus;
            stbRealName.SkinTxt.GotFocus += tbFocus;
            stbQQ.SkinTxt.GotFocus += tbFocus;
            stbEmail.SkinTxt.GotFocus += tbFocus;
            stbMobile.SkinTxt.GotFocus += tbFocus;

            stbConfirmPassword.SkinTxt.LostFocus += (sender, e) =>
            {
                if (!stbConfirmPassword.SkinTxt.Text.Trim().Equals(stbPassword.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbConfirmPassword, "确认密码与输入的密码不一致！");
                }
            };

            sbtnRegiester.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(stbAccount.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbAccount, "帐号不能为空！");
                    return;
                }

                if (string.IsNullOrEmpty(stbPassword.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbPassword, "密码不能为空！");
                    return;
                }

                if (string.IsNullOrEmpty(stbConfirmPassword.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbConfirmPassword, "确认密码不能为空！");
                    return;
                }

                if (string.IsNullOrEmpty(stbRealName.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbRealName, "真实姓名不能为空！");
                    return;
                }

                if (string.IsNullOrEmpty(stbQQ.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbQQ, "QQ号码不能为空！");
                    return;
                }

                if (string.IsNullOrEmpty(stbEmail.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbEmail, "邮箱帐号不能为空！");
                    return;
                }

                if (string.IsNullOrEmpty(stbMobile.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbMobile, "手机号码不能为空！");
                    return;
                }

                if (!stbConfirmPassword.SkinTxt.Text.Trim().Equals(stbPassword.SkinTxt.Text.Trim()))
                {
                    errorProvider.SetError(stbConfirmPassword, "确认密码与输入的密码不一致！");
                    return;
                }

                _userBll.Register(new User
                {
                    Account = stbAccount.SkinTxt.Text.Trim(),
                    Password = stbPassword.SkinTxt.Text.Trim(),
                    Name = stbRealName.SkinTxt.Text.Trim(),
                    QQ = stbQQ.SkinTxt.Text.Trim(),
                    Email = stbEmail.SkinTxt.Text.Trim(),
                    Mobile = stbMobile.SkinTxt.Text.Trim(),
                    ReferrerAccount = stbReferrerAccount.SkinTxt.Text.Trim()

                }, _registerResponse);
            };

            sbtnExit.Click += (sender, e) =>
            {
                Close();
            };
        }
    }
}
