using System;
using System.Collections.Generic;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core.MessageFilters
{
    internal class OrderTypeMessageFilter : MessageFilterBase
    {
        readonly IOrderTypeBll _orderTypeBll;

        public OrderTypeMessageFilter(IOrderTypeBll orderTypeBll)
        {
            _orderTypeBll = orderTypeBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.GetOrderTypeListRequest:
                        OnGetOrderTypeListRequest(msg, e);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }

        void OnGetOrderTypeListRequest(IMessage msg, SessionEventArgs e)
        {
            var state = OrderTypeOptState.Failed;
            IList<OrderType> orderTypeList = null;
            if (e.Session.SessionId != null)
            {
                try
                {
                    orderTypeList = _orderTypeBll.GetList();
                    state = OrderTypeOptState.Successed;
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                }
            }
            else
            {
                state = OrderTypeOptState.InvalidOpt;
            }

            e.Session.Send(new DataResponse<OrderTypeOptState, IList<OrderType>>
            {
                State = state,
                Data = orderTypeList
            }, MessageType.GetOrderTypeListResponse);
        }
    }
}
