using System;
using System.Drawing;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using Ninject;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaoBao.Views.ViewResource;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewLogin : ViewBase
    {
        readonly IUserBll _userBll;
        readonly IViewFactory _viewFactory;
        readonly ILoginCfgBll _loginCfgBll;
        readonly IGlobalApplicationData _globalApplicationData;
        readonly IOfflineCheckManager _offlineCheckManager;
        readonly IUpdateInfoBll _updateInfoBll;
        readonly Action<LoginState> _loginResponse;
        bool _isClient;
        bool _useInputPassword;

        [Inject]
        public ViewLogin(ILoginCfgBll loginCfgBll, 
            IUserBll userBll, IViewFactory viewFactory, IUpdateInfoBll updateInfoBll,
            IOfflineCheckManager offlineCheckManager, IGlobalApplicationData globalApplicationData)
        {
            InitializeComponent();
            InitUI();
            InitEvents();

            _loginCfgBll = loginCfgBll;
            _userBll = userBll;
            _viewFactory = viewFactory;
            _updateInfoBll = updateInfoBll;
            _offlineCheckManager = offlineCheckManager;
            _globalApplicationData = globalApplicationData;
            _loginResponse = state =>
            {
                string info = string.Empty;

                switch (state)
                {
                    case LoginState.Failed:
                        info = "服务器异常，登录失败！";
                        break;
                    case LoginState.InvalidAccountOrPassword:
                        LoginCfg = null;
                        info = "用户名或密码错误！";
                        break;
                    case LoginState.LoggedIn:
                        info = "该用户帐号已经登录。";
                        break;
                    case LoginState.Expired:
                        info = "该用户帐号已过期，不能登录。";
                        break;
                    case LoginState.Locked:
                        info = "该用户帐号已被锁定，请联系管理员进行解锁！";
                        break;
                    case LoginState.HangUpTimeNotEnough:
                        info = "挂机端挂机时间不足，不能登录操作端。";
                        break;
                    case LoginState.CannotConnectServer:
                        info = "连接服务器失败！";
                        break;
                    case LoginState.ClientOffline:
                        info = "挂机端不在线，不能登录操作端。";
                        break;
                    case LoginState.ClientIsNotLatestVersion:
                        info = "挂机端没有更新到最新版本，请更新后再登录操作端。";
                        break;
                    case LoginState.NotAudit:
                    case LoginState.Successed:
                        if(state == LoginState.NotAudit && IsClient)
                        {
                            info = "该用户帐号没有审核，不能登录挂机端。";
                            break;
                        }

                        info = "该用户帐号没有审核，登录成功后只允许对用户信息进行完善，不允许进行刷单操作！\r\n\r\n" +
                            "用户信息完善后，请联系管理员或客服帮助审核！";
                        Invoke(() =>
                        {
                            if (state == LoginState.NotAudit)
                            {
                                MessageBoxEx.Show(this, info, "登录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            if(LoginCfg == null)
                            {
                                if (checkBoxRememberPwd.Checked || checkBoxAutoLogin.Checked)
                                {
                                    LoginCfg = new LoginCfg
                                    {
                                        Account = stbAccount.SkinTxt.Text.Trim(),
                                        Password = MD5Encrypt.GetMD5(stbPassword.SkinTxt.Text.Trim()),
                                        RememberPassword = checkBoxRememberPwd.Checked,
                                        AutoLogin = checkBoxAutoLogin.Checked
                                    };
                                    _loginCfgBll.AddOrUpdate(LoginCfg);
                                }
                            }
                            else
                            {
                                if (!checkBoxAutoLogin.Checked && !checkBoxRememberPwd.Checked)
                                {
                                    _loginCfgBll.Delete(LoginCfg);
                                }
                                else if (LoginCfg.RememberPassword != checkBoxRememberPwd.Checked
                                 || LoginCfg.AutoLogin != checkBoxAutoLogin.Checked)
                                {
                                    LoginCfg.RememberPassword = checkBoxRememberPwd.Checked;
                                    LoginCfg.AutoLogin = checkBoxAutoLogin.Checked;
                                    _loginCfgBll.AddOrUpdate(LoginCfg);
                                }
                            }

                            var user = new User
                            {
                                Account = stbAccount.SkinTxt.Text.Trim(),
                                IsClient = IsClient
                            };

                            if(LoginCfg != null)
                            {
                                user.Password = LoginCfg.Password;
                            }
                            else
                            {
                                user.Password = MD5Encrypt.GetMD5(stbPassword.SkinTxt.Text.Trim());
                            }

                            _globalApplicationData.ApplicationData.IsClient = IsClient;
                            _globalApplicationData.ApplicationData.User = user;
                            base.DialogResult = DialogResult.OK;
                            base.Close();
                            _offlineCheckManager.Start();
                        });
                        return;
                }

                Invoke(() =>
                {
                    MessageBoxEx.Show(this, info, "登录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            };
        }

        internal bool IsClient
        {
            private get { return _isClient; }
            set
            {
                if (_isClient != value)
                {
                    _isClient = value;

                    if (_isClient)
                    {
                        this.Text = string.Concat(ViewResources.ClientName, "登录"); ;
                        this.btnRegister.Visible = false;
                        this.btnForgotPassword.Visible = false;
                        this.Width -= 50;
                        this.errorProvider.SetIconAlignment(
                            stbAccount, ErrorIconAlignment.MiddleRight);
                        this.errorProvider.SetIconAlignment(
                            stbPassword, ErrorIconAlignment.MiddleRight);
                    }
                }
            }
        }

        internal string Account
        {
            get { return stbAccount.SkinTxt.Text.Trim().ToLower(); }
        }

        internal LoginCfg LoginCfg
        {
            get;
            set;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoginCfg = _loginCfgBll.Get();
            if (LoginCfg != null)
            {
                stbAccount.SkinTxt.Text = LoginCfg.Account;
                if (LoginCfg.RememberPassword || LoginCfg.AutoLogin)
                {
                    stbPassword.SkinTxt.Text = LoginCfg.Password.Substring(3, 6);
                    checkBoxRememberPwd.Checked = true;
                    stbPassword.SkinTxt.MouseDown += (sender, fe) =>
                    {
                        stbPassword.SkinTxt.SelectAll();
                    };
                    stbPassword.SkinTxt.KeyUp += (sender, ke) =>
                    {
                        _useInputPassword = true;
                    };
                }

                if (LoginCfg.AutoLogin)
                {
                    checkBoxAutoLogin.Checked = true;
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if(LoginCfg != null && LoginCfg.AutoLogin)
            {
                btnLogin.PerformClick();
            }
        }

        void InitUI()
        {
            this.TopMost = true;
            this.Text = string.Concat(ViewResources.OptName, "登录");

            skinPanelAvatar.NormlBack =
                skinPanelAvatar.MouseBack =
                skinPanelAvatar.DownBack = ViewResources.NormlBack;

            stbPassword.Icon = ViewResources.PasswordIcon;
            picBoxAvatar.Image = ViewResources.favicon.ToBitmap();

            btnLogin.NormlBack = ViewResources.button_login_normal;
            btnLogin.MouseBack = ViewResources.button_login_hover;
            btnLogin.DownBack = ViewResources.button_login_down;
        }

        void InitEvents()
        {
            stbPassword.IconClick += delegate
            {
                PassKey passKey = new PassKey(
                    Left + stbPassword.Left,
                    Top + stbPassword.Bottom,
                    stbPassword.SkinTxt);
                passKey.Show(this);
            };

            checkBoxRememberPwd.CheckedChanged += (sender, e) =>
            {
                if(!checkBoxRememberPwd.Checked)
                {
                    checkBoxAutoLogin.Checked = false;
                }
            };

            checkBoxAutoLogin.CheckedChanged += (sender, e) =>
            {
                if(checkBoxAutoLogin.Checked)
                {
                    checkBoxRememberPwd.Checked = true;
                }
            };

            EventHandler btnMouseEnter = (sender, e) =>
            {
                var control = sender as Control;
                control.ForeColor = Color.FromArgb(98, 180, 247);
            };

            EventHandler btnMouseLeave = (sender, e) =>
            {
                var control = sender as Control;
                control.ForeColor = Color.FromArgb(39, 134, 228);
            };

            EventHandler tbFocus = (sender, e) =>
            {
                var control = sender as Control;
                errorProvider.SetError(control.Parent, string.Empty);
            };

            btnRegister.MouseEnter += btnMouseEnter;
            btnForgotPassword.MouseEnter += btnMouseEnter;
            btnRegister.MouseLeave += btnMouseLeave;
            btnForgotPassword.MouseLeave += btnMouseLeave;

            stbAccount.SkinTxt.GotFocus += tbFocus;
            stbPassword.SkinTxt.GotFocus += tbFocus;

            btnLogin.Click += btnLogin_Click;
            btnRegister.Click += (sender, e) =>
            {
                var view = _viewFactory.GetView<ViewRegister>();
                view.ShowDialog(this);
            };
            btnForgotPassword.Click += (sender, e) =>
            {
                MessageBoxEx.Show(this, "请联系管理员！", "忘记密码", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(stbAccount.SkinTxt.Text))
            {
                errorProvider.SetError(stbAccount, "请您输入帐号后再登录！");
                return;
            }

            if (string.IsNullOrEmpty(stbPassword.SkinTxt.Text))
            {
                errorProvider.SetError(stbPassword, "请您输入密码后再登录！");
                return;
            }

            var user = new User
            {
                Account = stbAccount.SkinTxt.Text,
                Password = stbPassword.SkinTxt.Text,
                IsClient = _isClient
            };

            if (LoginCfg != null)
            {
                if (LoginCfg.RememberPassword && !_useInputPassword)
                {
                    user.Password = LoginCfg.Password;
                }
            }

            bool isAutoLogin = !_useInputPassword && LoginCfg != null && 
                (LoginCfg.RememberPassword || LoginCfg.AutoLogin);
            _globalApplicationData.ApplicationData.UpdateInfo = _updateInfoBll.Get();
            _userBll.Login(new LoginInfo
                {
                    User = user,
                    UpdateInfo = _globalApplicationData.ApplicationData.UpdateInfo
                }, isAutoLogin, _loginResponse);
        }
    }
}