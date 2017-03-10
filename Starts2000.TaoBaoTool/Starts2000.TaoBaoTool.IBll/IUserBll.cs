using System;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface IUserBll
    {
        void Login(LoginInfo info, bool isAutoLogin = false, Action<LoginState> loginResponse = null);

        void LoginResponse(LoginState state);

        void ReLogin(LoginInfo info, Action<LoginState> reLoginResponse = null);

        void ReLoginResponse(LoginState state);

        void Register(User user, Action<RegisterState> registerResponse);

        void RegisterResponse(RegisterState state);

        void ChangePassword(ChangePassword password, Action<ChangePasswordState> changePasswordResponse);

        void ChangePasswordResponse(ChangePasswordState state);

        void Logout(Action<LogoutState> logoutResponse = null);

        void LogoutResponse(LogoutState state);

        void ClientLogout(Action<LogoutState> clientLogoutResponse = null);

        void ClientLogoutResponse(LogoutState state);

        void GetInfo(Action<DataResponse<UserOptState, User>> getInfoResponse);

        void GetInfoResponse(DataResponse<UserOptState, User> response);
    }
}