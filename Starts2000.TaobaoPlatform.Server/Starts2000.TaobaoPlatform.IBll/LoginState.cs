namespace Starts2000.TaobaoPlatform.IBll
{
    public enum LoginState
    {
        Failed,
        Successed,
        LoggedIn,
        InvalidAccountOrPassword,
        Locked,
        CannotConnectServer,
        NotAudit,
        Expired,
        HangUpTimeNotEnough,
        ClientOffline,
        ClientIsNotLatestVersion
    }
}