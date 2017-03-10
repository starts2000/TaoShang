using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.MessageFilters
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
                    case MessageType.GetOrderTypeListResponse:
                        _orderTypeBll.GetListResponse(
                            msg.Obj as DataResponse<OrderTypeOptState, IList<OrderType>>);
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
