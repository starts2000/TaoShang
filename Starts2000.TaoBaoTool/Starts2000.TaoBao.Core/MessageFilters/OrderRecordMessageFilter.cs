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
    internal class OrderRecordMessageFilter : MessageFilterBase
    {
        readonly IOrderRecordBll _orderRecordBll;

        public OrderRecordMessageFilter(IOrderRecordBll orderRecordBll)
        {
            _orderRecordBll = orderRecordBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.GetOrderRecordResponse:
                        _orderRecordBll.GetResponse(
                            msg.Obj as DataResponse<OrderRecordOptState, OrderRecord>);
                        break;
                    case MessageType.AddOrderRecordResponse:
                        _orderRecordBll.AddResponse((OrderRecordOptState)msg.Obj);
                        break;
                    case MessageType.UpdateOrderRecordResponse:
                        _orderRecordBll.UpdateResponse((OrderRecordOptState)msg.Obj);
                        break;
                    case MessageType.GetOrderRecordListResponse:
                        _orderRecordBll.GetPageListResponse(
                            msg.Obj as DataResponse<OrderRecordOptState, Page<OrderRecordDetails>>);
                        break;
                    case MessageType.GetGetConfirmReceiptInfoResponse:
                        _orderRecordBll.GetConfirmReceiptInfoResponse(
                            msg.Obj as DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo>);
                        break;
                }
            }
            catch(Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }
    }
}
