using System;
using System.Collections.Generic;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core.MessageFilters
{
    internal class OrderRecordMessageFilter : MessageFilterBase
    {
        readonly IOrderRecordBll _orderRecordBll;
        readonly IUserBll _userBll;
        readonly IUserSubAccountUsageInfoBll _subAccountUsageInfoBll;
        readonly IUserSubAccountOrderTypeInfoBll _subAccountOrderTypeInfoBll;

        public OrderRecordMessageFilter(
            IOrderRecordBll orderRecordBll, IUserBll userBll,
            IUserSubAccountUsageInfoBll subAccountUsageInfoBll, 
            IUserSubAccountOrderTypeInfoBll subAccountOrderTypeInfoBll)
        {
            _orderRecordBll = orderRecordBll;
            _userBll = userBll;
            _subAccountUsageInfoBll = subAccountUsageInfoBll;
            _subAccountOrderTypeInfoBll = subAccountOrderTypeInfoBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.GetOrderRecordRequest:
                        OnGetOrderRecordRequest(msg, e);
                        break;
                    case MessageType.AddOrderRecordRequest:
                        OnAddOrderRecordRequest(msg, e);
                        break;
                    case MessageType.UpdateOrderRecordRequest:
                        OnUpdateOrderRecordRequest(msg, e);
                        break;
                    case MessageType.GetOrderRecordListRequest:
                        OnGetOrderRecordListRequest(msg, e);
                        break;
                    case MessageType.GetGetConfirmReceiptInfoRequest:
                        OnGetGetConfirmReceiptInfoRequest(msg, e);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }

        void OnGetOrderRecordRequest(IMessage msg, SessionEventArgs e)
        {
            var state = OrderRecordOptState.Failed;

            OrderRecord orderRecord = msg.Obj as OrderRecord;
            if (e.Session.SessionId != null)
            {
                try
                {
                    orderRecord = _orderRecordBll.Get(
                        (e.Session.SessionId as UserSessionIdMetaData).Id,
                        orderRecord.ClientUserSubAccountId);
                    state = OrderRecordOptState.Successed;
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                }
            }
            else
            {
                state = OrderRecordOptState.InvalidOpt;
            }

            e.Session.Send(new DataResponse<OrderRecordOptState, OrderRecord>
            {
                State = state,
                Data = orderRecord
            }, MessageType.GetOrderRecordResponse);
        }

        void OnAddOrderRecordRequest(IMessage msg, SessionEventArgs e)
        {
            var state = OrderRecordOptState.Failed;

            OrderRecord orderRecord = msg.Obj as OrderRecord;
            if (e.Session.SessionId != null)
            {
                try
                {
                    orderRecord.UserId = (e.Session.SessionId as UserSessionIdMetaData).Id;

                    if(orderRecord.OrderStateId == 999999)
                    {
                        state = OrderRecordOptState.ReturnGold;
                    }
                    else
                    {
                        if (!_orderRecordBll.HasNotCompletedOrder(orderRecord.UserId,
                            orderRecord.ClientUserId, orderRecord.ClientUserSubAccountId))
                        {
                            if (_userBll.UpdateGold(orderRecord.UserId, -100))
                            {
                                state = OrderRecordOptState.DeductionGold;
                            }
                        }

                        if(orderRecord.OrderStateId >= 10 && orderRecord.OrderStateId <= 40)
                        {
                            _subAccountOrderTypeInfoBll.UpdateOrderTypeCount(
                                orderRecord.ClientUserSubAccountId, orderRecord.OrderTypeId.Value);

                            if (orderRecord.OrderStateId >= 20)
                            {
                                _subAccountUsageInfoBll.UpdateOrderCount(orderRecord.ClientUserSubAccountId);
                            }
                        }
                    }

                    if (!_orderRecordBll.Add(orderRecord))
                    {
                        state = OrderRecordOptState.Failed;
                    }
                }
                catch (Exception ex)
                {
                    state = OrderRecordOptState.Failed;
                    ErrorLog(msg.Header.Type, ex);
                }
            }
            else
            {
                state = OrderRecordOptState.InvalidOpt;
            }

            e.Session.Send(state, MessageType.AddOrderRecordResponse);
        }

        void OnUpdateOrderRecordRequest(IMessage msg, SessionEventArgs e)
        {
            var state = OrderRecordOptState.Failed;

            OrderRecord orderRecord = msg.Obj as OrderRecord;
            if (e.Session.SessionId != null)
            {
                try
                {
                    var record = _orderRecordBll.GetSubAccountIdAndOrderState(orderRecord.Id);
                    if(record.OrderStateId < 20)
                    {
                        if (orderRecord.OrderStateId >= 20 && orderRecord.OrderStateId <= 40)
                        {
                            _subAccountUsageInfoBll.UpdateOrderCount(record.ClientUserSubAccountId);
                        }
                    }
                }
                catch(Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                }

                try
                {
                    if (_orderRecordBll.Update(orderRecord))
                    {
                        state = OrderRecordOptState.Successed;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                }
            }
            else
            {
                state = OrderRecordOptState.InvalidOpt;
            }

            e.Session.Send(state, MessageType.UpdateOrderRecordResponse);
        }

        void OnGetOrderRecordListRequest(IMessage msg, SessionEventArgs e)
        {
            var pageListInfo = msg.Obj as PageListQueryInfo<OrderRecordPageListQuery>;
            var state = OrderRecordOptState.Failed;
            Page<OrderRecordDetails> page = null;
            if (e.Session.SessionId == null)
            {
                state = OrderRecordOptState.InvalidOpt;
            }
            else
            {
                if (pageListInfo != null)
                {
                    try
                    {
                        var userId = (e.Session.SessionId as UserSessionIdMetaData).Id;
                        page = _orderRecordBll.GetPageList(userId, pageListInfo);
                        state = OrderRecordOptState.Successed;
                    }
                    catch (Exception ex)
                    {
                        ErrorLog(msg.Header.Type, ex);
                    }
                }
            }

            e.Session.Send(new DataResponse<OrderRecordOptState, Page<OrderRecordDetails>>
            {
                State = state,
                Data = page
            }, MessageType.GetOrderRecordListResponse);
        }

        void OnGetGetConfirmReceiptInfoRequest(IMessage msg, SessionEventArgs e)
        {
            var state = OrderRecordOptState.Failed;
            OrderRecordConfirmReceiptInfo info = null;

            if (e.Session.SessionId != null)
            {
                OrderRecord orderRecord = msg.Obj as OrderRecord;
                try
                {
                    if (orderRecord != null)
                    {
                        info = _orderRecordBll.GetConfirmReceiptInfo(
                            orderRecord.UserId,
                            (e.Session.SessionId as UserSessionIdMetaData).Id,
                            orderRecord.ClientUserSubAccountId);
                        state = OrderRecordOptState.Successed;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                }
            }
            else
            {
                state = OrderRecordOptState.InvalidOpt;
            }

            e.Session.Send(new DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo>
            {
                State = state,
                Data = info
            }, MessageType.GetGetConfirmReceiptInfoResponse);
        }
    }
}
