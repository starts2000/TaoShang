using System;
using Ninject;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.MessageFilters
{
    class RemoteOperrationMessageFilter : MessageFilterBase
    {
        readonly IRemoteOperationBll _remoteOperrationBll;

        [Inject]
        public RemoteOperrationMessageFilter(IRemoteOperationBll remoteOperrationBll)
        {
            _remoteOperrationBll = remoteOperrationBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.RemoteOperationResponse:
                        _remoteOperrationBll.RequestConnectToClientResponse(
                            msg.Obj as DataResponse<RemoteOperationState, RemoteClientInfo>);
                        break;
                    case MessageType.RemoteOperationRequest:
                        _remoteOperrationBll.RequestRemoteInfo(msg.Obj as RemoteInfoQuery);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }
    }
}