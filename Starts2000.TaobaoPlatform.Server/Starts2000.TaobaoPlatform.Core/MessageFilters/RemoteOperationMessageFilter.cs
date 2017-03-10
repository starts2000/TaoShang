using System;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Core.Cache;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core.MessageFilters
{
    class RemoteOperationMessageFilter : MessageFilterBase
    {
        readonly IOrderRecordBll _orderRecordBll;
        readonly IUserBll _userBll;
        readonly IShopBll _shopBll;
        readonly IUpdateInfoBll _updateInfoBll;

        public RemoteOperationMessageFilter(
            IOrderRecordBll orderRecordBll, IUserBll userBll, IShopBll shopBll)
        {
            _orderRecordBll = orderRecordBll;
            _userBll = userBll;
            _shopBll = shopBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.RemoteOperationRequest:
                        OnRemoteOperationRequest(msg, e);
                        break;
                    case MessageType.RemoteOperationResponse:
                        OnRemoteOperationResponse(msg, e);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }

        void OnRemoteOperationRequest(IMessage msg, SessionEventArgs e)
        {
            RemoteOperationState state = RemoteOperationState.Failed;

            try
            {
                if (e.Session.SessionId == null)
                {
                    state = RemoteOperationState.InvalidOpt;
                }
                else
                {
                    var query = msg.Obj as TransmitData<RemoteInfoQuery>;
                    if (query == null)
                    {
                        state = RemoteOperationState.Failed;
                    }
                    else
                    {
                        var sessionId = e.Session.SessionId as UserSessionIdMetaData;

                        if(!_shopBll.HasAuditShop(sessionId.Id))
                        {
                            state = RemoteOperationState.NotAuditShop;
                            goto Response;
                        }

                        var clientSession = Global.GetSession(new UserSessionIdMetaData
                         {
                             Id = sessionId.Id,
                             IsClient = true
                         });

                        if (clientSession == null || !clientSession.IsOpened)
                        {
                            state = RemoteOperationState.ClientOffline;
                            goto Response;
                        }

                        var toClientSession = Global.GetSession(new UserSessionIdMetaData
                        {
                            Id = query.ToUser.Id,
                            IsClient = true
                        });

                        if (toClientSession == null || !toClientSession.IsOpened)
                        {
                            state = RemoteOperationState.ToClientOffline;
                            goto Response;
                        }

                        if (_userBll.GetGold(sessionId.Id) < 100)
                        {
                            state = RemoteOperationState.Goldless;
                            goto Response;
                        }

                        query.Data.UserId = sessionId.Id;
                        query.Data.UserAccount = sessionId.Account;

                        var future = toClientSession.Send(query.Data, MessageType.RemoteOperationRequest);
                        if (future == null)
                        {
                            state = RemoteOperationState.ToClientOffline;
                        }
                        else
                        {
                            state = RemoteOperationState.Successed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                state = RemoteOperationState.Failed;
                ErrorLog(msg.Header.Type, ex);
            }

            Response:
            if (state != RemoteOperationState.Successed)
            {
                e.Session.Send(new DataResponse<RemoteOperationState, RemoteClientInfo>
                {
                    State = state
                }, MessageType.RemoteOperationResponse);
            }
        }

        void OnRemoteOperationResponse(IMessage msg, SessionEventArgs e)
        {
            if (e.Session.SessionId == null)
            {
                return;
            }

            var query = msg.Obj as TransmitData<DataResponse<RemoteOperationState, RemoteClientInfo>>;

            if (query != null)
            {
                var session = Global.GetSession(new UserSessionIdMetaData
                {
                    Id = query.ToUser.Id,
                    IsClient = false
                });

                if (session != null && session.IsOpened)
                {
                    session.Send(query.Data, MessageType.RemoteOperationResponse);
                }
            }
        }
    }
}