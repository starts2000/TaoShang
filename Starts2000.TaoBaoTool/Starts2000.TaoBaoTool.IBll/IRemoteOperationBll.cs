using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface IRemoteOperationBll
    {
        Action<RemoteInfoQuery> OnRequestRemoteInfo { get; set; }

        void RequestConnectToClient(
            int userId, int subAccountId, string subAccount, 
            Action<DataResponse<RemoteOperationState,
            RemoteClientInfo>> requestConnectToClientResponse);

        void RequestConnectToClientResponse(
            DataResponse<RemoteOperationState, RemoteClientInfo> data);

        void RequestRemoteInfo(RemoteInfoQuery query);

        void ResponseRequetRemoteInfo(int requestUserId,
            RemoteOperationState state, RemoteClientInfo info);
    }
}