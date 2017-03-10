using System;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Core.Cache;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core.MessageFilters
{
    internal class UserMessageFilter : MessageFilterBase
    {
        readonly IUserBll _userBll;
        readonly IHangUpTimeBll _hangUpTimeBll;
        readonly IUpdateInfoBll _updateInfoBll;
        readonly Func<int, UpdateInfo> _updateInfoCtreator;

        public UserMessageFilter(IUserBll userBll, 
            IUpdateInfoBll updateInfoBll, IHangUpTimeBll hangUpTimeBll)
        {
            _userBll = userBll;
            _updateInfoBll = updateInfoBll;
            _hangUpTimeBll = hangUpTimeBll;
            _updateInfoCtreator = clientType => _updateInfoBll.Get(clientType);
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.RegisterRequest:
                        OnRegisterRequest(msg, e);
                        break;
                    case MessageType.LoginRequest:
                        OnLoginRequest(msg, e);
                        break;
                    case MessageType.ReLoginRequest:
                        OnLoginRequest(msg, e, true);
                        break;
                    case MessageType.ClientLoginRequest:
                        OnClientLoginRequest(msg, e);
                        break;
                    case MessageType.ClientReLoginRequest:
                        OnClientLoginRequest(msg, e, true);
                        break;
                    case MessageType.CheckOnlineRequest:
                        OnCheckOnlineRequest(msg, e);
                        break;
                    case MessageType.GetUserInfoRequest:
                        OnGetUserInfoRequest(msg, e);
                        break;
                    case MessageType.ChangePasswordRequest:
                        OnChangePasswordRequest(msg, e);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }

        void OnCheckOnlineRequest(IMessage msg, SessionEventArgs e)
        {
            var info = msg.Obj as string;
            var state = OnlineCheckState.Failed;

            if (e.Session.SessionId != null)
            {
                if (!string.IsNullOrEmpty(info) && info.Equals("CheckOnline"))
                {
                    state = OnlineCheckState.Successed;
                }
            }
            else
            {
                state = OnlineCheckState.InvalidOpt;
            }

            e.Session.Send(state, MessageType.CheckOnlineResponse);
        }

        void OnRegisterRequest(IMessage msg, SessionEventArgs e)
        {
            var rUser = msg.Obj as User;
            var regState = RegisterState.Failed;

            if (rUser != null)
            {
                try
                {
                    regState = _userBll.Register(rUser);
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                    regState = RegisterState.Failed;
                }
            }
            e.Session.Send(regState, MessageType.RegisterResponse);
        }

        void OnLoginRequest(IMessage msg, SessionEventArgs e, bool reLogin = false)
        {
            var loginInfo = msg.Obj as LoginInfo;
            LoginState state = LoginState.Failed;

            if (loginInfo != null)
            {
                var session = Global.GetSession(new UserSessionIdMetaData
                {
                    Account = loginInfo.User.Account
                });

                if (!reLogin && session != null)
                {
                    state = LoginState.LoggedIn;
                    goto Response;
                }

                if (reLogin && session != null)
                {
                    session.SessionId = null;
                }

                try
                {
                    state = _userBll.Login(loginInfo.User);

                    if (state == LoginState.NotAudit)
                    {
                        e.Session.SessionId = new UserSessionIdMetaData
                        {
                            Id = loginInfo.User.Id,
                            Account = loginInfo.User.Account
                        };

                        goto Response;
                    }

                    if (state == LoginState.Successed)
                    {
                        if (!reLogin)
                        {
                            var clientSession = Global.GetSession(new UserSessionIdMetaData
                            {
                                Account = loginInfo.User.Account,
                                IsClient = true
                            });

                            if (clientSession == null)
                            {
                                state = LoginState.ClientOffline;
                                goto Response;
                            }

                            var clientLoginUpdateInfo = (clientSession.SessionId as UserSessionIdMetaData).UpdateInfo;
                            var clientLastUpdateInfo = CacheManager.GetUpdateInfo(2, _updateInfoCtreator);
                            if (clientLastUpdateInfo != null)
                            {
                                if (clientLoginUpdateInfo == null ||
                                    (clientLastUpdateInfo.Version.Equals(
                                    clientLoginUpdateInfo.Version, StringComparison.InvariantCultureIgnoreCase) &&
                                    clientLastUpdateInfo.LastUpdateTime >= clientLoginUpdateInfo.LastUpdateTime))
                                    state = LoginState.ClientIsNotLatestVersion;
                                goto Response;
                            }

                            if (_hangUpTimeBll.TotalMinutes(loginInfo.User.Id) < 6 * 60)
                            {
                                state = LoginState.HangUpTimeNotEnough;
                                goto Response;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                    state = LoginState.Failed;
                }
            }

        Response:
            if(state == LoginState.Successed)
            {
                e.Session.SessionId = new UserSessionIdMetaData
                {
                    Id = loginInfo.User.Id,
                    Account = loginInfo.User.Account
                };
            }
            e.Session.Send(state, reLogin ?
                MessageType.ReLoginResponse : MessageType.LoginResponse);
        }

        void OnClientLoginRequest(IMessage msg, SessionEventArgs e, bool reLogin = false)
        {
            var loginInfo = msg.Obj as LoginInfo;
            LoginState clientLoginstate = LoginState.Failed;

            if (loginInfo != null)
            {
                var session = Global.GetSession(new UserSessionIdMetaData
                {
                    Account = loginInfo.User.Account,
                    IsClient = true
                });

                if (!reLogin && session != null)
                {
                    clientLoginstate = LoginState.LoggedIn;
                }
                else
                {
                    if (reLogin && session != null)
                    {
                        session.SessionId = null;
                    }

                    try
                    {
                        clientLoginstate = _userBll.Login(loginInfo.User);
                        if (clientLoginstate == LoginState.Successed)
                        {
                            e.Session.SessionId = new UserSessionIdMetaData
                            {
                                Id = loginInfo.User.Id,
                                Account = loginInfo.User.Account,
                                IsClient = true,
                                LastCalcTime = DateTime.Now,
                                UpdateInfo = loginInfo.UpdateInfo
                            };

                            _userBll.UpdateClientLogin(new UserLoginState
                            {
                                UserId = loginInfo.User.Id,
                                ClientLastLoginIpAddress = e.Session.RemoteEndPoint.Address.ToString(),
                                ClientLastLoginTime = DateTime.Now
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog(msg.Header.Type, ex);
                    }
                }
            }
            e.Session.Send(clientLoginstate, reLogin ?
                MessageType.ClientReLoginReponse : MessageType.ClientLoginReponse);
        }

        void OnGetUserInfoRequest(IMessage msg, SessionEventArgs e)
        {
            UserOptState state = UserOptState.Failed;

            User user = null;
            if (e.Session.SessionId != null)
            {
                try
                {
                    user = _userBll.GetInfo((e.Session.SessionId as UserSessionIdMetaData).Id);
                    state = UserOptState.Successed;
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                    state = UserOptState.Failed;
                }
            }
            else
            {
                state = UserOptState.InvalidOpt;
            }

            e.Session.Send(new DataResponse<UserOptState, User>
            {
                State = state,
                Data = user
            }, MessageType.GetUserInfoResponse);
        }

        void OnChangePasswordRequest(IMessage msg, SessionEventArgs e)
        {
            var changePassword = msg.Obj as ChangePassword;
            ChangePasswordState state = ChangePasswordState.Failed;

            if (changePassword != null && e.Session.SessionId != null)
            {
                changePassword.Id = (e.Session.SessionId as UserSessionIdMetaData).Id;
                try
                {
                   state = _userBll.ChangePassword(changePassword);
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                    state = ChangePasswordState.Failed;
                }
            }
            else
            {
                state = ChangePasswordState.InvalidOpt;
            }

            e.Session.Send(state, MessageType.ChangePasswordResponse);
        }
    }
}