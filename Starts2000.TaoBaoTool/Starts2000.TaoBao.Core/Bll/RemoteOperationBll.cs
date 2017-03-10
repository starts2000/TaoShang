using System;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.Bll
{
    internal class RemoteOperationBll : IRemoteOperationBll
    {
        Action<DataResponse<RemoteOperationState, RemoteClientInfo>> _requestConnectToClientResponse;

        public Action<RemoteInfoQuery> OnRequestRemoteInfo
        {
            get;
            set;
        }

        public void RequestConnectToClient(int userId, int subAccountId, string subAccount,
            Action<DataResponse<RemoteOperationState, RemoteClientInfo>> requestConnectToClientResponse)
        {
            _requestConnectToClientResponse = requestConnectToClientResponse;

            var future = Global.SendToServer(new TransmitData<RemoteInfoQuery>
                {
                    ToUser = new User
                    {
                        Id = userId,
                    },
                    Data = new RemoteInfoQuery
                    {
                        SubAccountId = subAccountId,
                        SubAccount = subAccount
                    }
                }, MessageType.RemoteOperationRequest);

            if(future == null)
            {
                RequestConnectToClientResponse(new DataResponse<RemoteOperationState, RemoteClientInfo>
                {
                    State = RemoteOperationState.CannotConnectServer
                });
            }
        }

        public void RequestConnectToClientResponse(
            DataResponse<RemoteOperationState, RemoteClientInfo> data)
        {
            if(_requestConnectToClientResponse != null)
            {
                _requestConnectToClientResponse(data);
            }
        }

        public void RequestRemoteInfo(RemoteInfoQuery query)
        {
            var info = OnRequestRemoteInfo;
            if(info != null)
            {
                info(query);
            }
        }

        public void ResponseRequetRemoteInfo(
            int requestUserId, RemoteOperationState state, RemoteClientInfo info)
        {
            Global.SendToServer(new TransmitData<DataResponse<RemoteOperationState, RemoteClientInfo>>
            {
                ToUser = new User { Id = requestUserId },
                Data = new DataResponse<RemoteOperationState, RemoteClientInfo>
                {
                    State = state,
                    Data = info
                }
            }, MessageType.RemoteOperationResponse);
        }
    }
}