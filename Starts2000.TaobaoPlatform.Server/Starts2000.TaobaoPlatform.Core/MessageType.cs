namespace Starts2000.TaobaoPlatform.Core
{
    internal enum MessageType : ushort
    {
        RegisterRequest = 1,
        RegisterResponse = 10001,
        LoginRequest = 2,
        LoginResponse = 10002,
        ChangePasswordRequest = 3,
        ChangePasswordResponse = 10003,
        ClientLoginRequest = 4,
        ClientLoginReponse = 10004,
        CheckOnlineRequest = 5,
        CheckOnlineResponse = 10005,
        ReLoginRequest = 6,
        ReLoginResponse = 10006,
        ClientReLoginRequest = 7,
        ClientReLoginReponse = 10007,
        LogoutRequest = 8,
        LogoutResponse = 10008,
        ClientLogoutRequest = 9,
        ClientLogoutResponse = 10009,
        GetUserInfoRequest = 10,
        GetUserInfoResponse = 10010,

        AddShopRequest = 100,
        AddShopResponse = 10100,
        DeleteShopRequest = 101,
        DeleteShopResponse = 10101,
        GetShopListRequest = 102,
        GetShopListResponse = 10102,

        AddUserSubAccountRequest = 200,
        AddUserSubAccountResponse = 10200,
        DeleteUserSubAccountRequest = 201,
        DeleteUserSubAccountResponse = 10201,
        GetUserSubAccountListRequest = 202,
        GetUserSubAccountListResponse = 10202,
        UpdateUserSubAccountRequest = 203,
        UpdateUserSubAccountResponse = 10203,

        GetSubAccountPageListRequest = 300,
        GetSubAccountPageListResponse =10300,

        RemoteOperationRequest = 400,
        RemoteOperationResponse = 10400,

        GetOrderRecordRequest = 500,
        GetOrderRecordResponse = 10500,
        AddOrderRecordRequest = 501,
        AddOrderRecordResponse = 10501,
        UpdateOrderRecordRequest = 502,
        UpdateOrderRecordResponse = 10502,
        GetOrderRecordListRequest = 503,
        GetOrderRecordListResponse = 10503,
        GetGetConfirmReceiptInfoRequest = 504,
        GetGetConfirmReceiptInfoResponse = 10504,

        GetOrderTypeListRequest = 600,
        GetOrderTypeListResponse = 10600,
    }
}