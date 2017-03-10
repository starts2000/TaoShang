namespace Starts2000.TaoBaoTool.IBll
{
    internal enum LoginState
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
