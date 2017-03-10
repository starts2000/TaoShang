using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaoBao.Core.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.Bll
{
    internal class UserBll : IUserBll
    {
        Action<LoginState> _loginResponse;
        Action<LoginState> _reLoginResponse;
        Action<RegisterState> _registerResponse;
        Action<DataResponse<UserOptState, User>> _getInfoResponse;
        Action<ChangePasswordState> _changePasswordResponse;

        public void Login(LoginInfo info, bool isAutoLogin = false, Action<LoginState> loginResponse = null)
        {
            _loginResponse = loginResponse;

            if (!isAutoLogin)
            {
                info.User.Password = MD5Encrypt.GetMD5(info.User.Password);
            }

            var messageType = info.User.IsClient ? 
                MessageType.ClientLoginRequest : MessageType.LoginRequest;

            var future = Global.SendToServer(info, messageType);
            if(future == null)
            {
                LoginResponse(LoginState.CannotConnectServer);
            }
        }

        public void LoginResponse(LoginState state)
        {
            if(_loginResponse != null)
            {
                _loginResponse(state);
            }
        }

        public void ReLogin(LoginInfo info, Action<LoginState> reLoginResponse = null)
        {
            _reLoginResponse = reLoginResponse;

            var messageType = info.User.IsClient ?
                MessageType.ClientReLoginRequest : MessageType.ReLoginRequest;

            var future = Global.SendToServer(info, messageType);
            if (future == null)
            {
                ReLoginResponse(LoginState.CannotConnectServer);
            }
        }

        public void ReLoginResponse(LoginState state)
        {
            if (_reLoginResponse != null)
            {
                _reLoginResponse(state);
            }
        }

        public void Register(User user, Action<RegisterState> registerResponse)
        {
            _registerResponse = registerResponse;

            if(!ValidateHelper.CheckUserName(user.Account))
            {
                RegisterResponse(RegisterState.InvalidAccount);
                return;
            }

            if(!ValidateHelper.CheckPassword(user.Password))
            {
                RegisterResponse(RegisterState.InvalidPassword);
                return;
            }

            if (!ValidateHelper.CheckQQ(user.QQ))
            {
                RegisterResponse(RegisterState.InvalidQQ);
                return;
            }

            if(!ValidateHelper.CheckEmail(user.Email))
            {
                RegisterResponse(RegisterState.InvalidEmail);
                return;
            }

            if (!ValidateHelper.CheckMobile(user.Mobile))
            {
                RegisterResponse(RegisterState.InvalidMobile);
                return;
            }

            var future = Global.SendToServer(user, MessageType.RegisterRequest);
            if (future == null)
            {
                RegisterResponse(RegisterState.CannotConnectServer);
            }
        }

        public void RegisterResponse(RegisterState state)
        {
            if(_registerResponse != null)
            {
                _registerResponse(state);
            }
        }

        public void ChangePassword(ChangePassword password, Action<ChangePasswordState> changePasswordResponse)
        {
            _changePasswordResponse = changePasswordResponse;

             if(!ValidateHelper.CheckPassword(password.NewPassword))
            {
                ChangePasswordResponse(ChangePasswordState.InvalidNewPassword);
                return;
            }

             var future = Global.SendToServer(password, MessageType.ChangePasswordRequest);
             if (future == null)
             {
                 ChangePasswordResponse(ChangePasswordState.CannotConnectServer);
             }
        }

        public void ChangePasswordResponse(ChangePasswordState state)
        {
            if(_changePasswordResponse != null)
            {
                _changePasswordResponse(state);
            }
        }

        public void Logout(Action<LogoutState> logoutResponse = null)
        {
            throw new NotImplementedException();
        }

        public void LogoutResponse(LogoutState state)
        {
            throw new NotImplementedException();
        }

        public void ClientLogout(Action<LogoutState> clientLogoutResponse = null)
        {
            throw new NotImplementedException();
        }

        public void ClientLogoutResponse(LogoutState state)
        {
            throw new NotImplementedException();
        }

        public void GetInfo(Action<DataResponse<UserOptState, User>> getInfoResponse)
        {
            _getInfoResponse = getInfoResponse;

            var future = Global.SendToServer(1, MessageType.GetUserInfoRequest);
            if (future == null)
            {
                GetInfoResponse(new DataResponse<UserOptState, User>
                {
                    State = UserOptState.CannotConnectServer
                });
            }
        }

        public void GetInfoResponse(DataResponse<UserOptState, User> response)
        {
            if(_getInfoResponse != null)
            {
                _getInfoResponse(response);
            }
        }
    }
}