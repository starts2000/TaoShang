namespace Starts2000.TaoBaoTool.IBll
{
    internal enum RemoteOperationState
    {
        Failed,
        Successed,
        InvalidOpt,
        CannotConnectServer,
        NotAuditShop,
        ClientOffline,
        Goldless,
        ToClientOffline,
        ToClientBusy,
        ToClientRemoteDesktopServiceError,
        InvalidClientVersion
    }
}
