using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.Bll
{
    internal class OrderRecordBll : IOrderRecordBll
    {
        Action<DataResponse<OrderRecordOptState, OrderRecord>> _getResponse;
        Action<OrderRecordOptState> _addResponse;
        Action<OrderRecordOptState> _updateResponse;
        Action<DataResponse<OrderRecordOptState, Page<OrderRecordDetails>>> _getPageListResponse;
        Action<DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo>> _getConfirmReceiptInfoResponse;

        public void Get(int clientUserSubAaccountId, 
            Action<DataResponse<OrderRecordOptState, OrderRecord>> getResponse)
        {
            _getResponse = getResponse;

            var future = Global.SendToServer(new OrderRecord
                {
                    ClientUserSubAccountId = clientUserSubAaccountId
                }, MessageType.GetOrderRecordRequest);

            if(future == null)
            {
                GetResponse(new DataResponse<OrderRecordOptState, OrderRecord>
                {
                    State = OrderRecordOptState.CannotConnectServer
                });
            }
        }

        public void GetResponse(DataResponse<OrderRecordOptState, OrderRecord> response)
        {
            if(_getResponse != null)
            {
                _getResponse(response);
            }
        }

        public void Add(OrderRecord record, Action<OrderRecordOptState> addResponse)
        {
            _addResponse = addResponse;

            var future = Global.SendToServer(record, MessageType.AddOrderRecordRequest);

            if (future == null)
            {
                AddResponse(OrderRecordOptState.CannotConnectServer);
            }
        }

        public void AddResponse(OrderRecordOptState state)
        {
            if(_addResponse != null)
            {
                _addResponse(state);
            }
        }

        public void Update(OrderRecord record, Action<OrderRecordOptState> updateResponse)
        {
            _updateResponse = updateResponse;

            var future = Global.SendToServer(record, MessageType.UpdateOrderRecordRequest);

            if (future == null)
            {
                UpdateResponse(OrderRecordOptState.CannotConnectServer);
            }
        }

        public void UpdateResponse(OrderRecordOptState state)
        {
            if (_updateResponse != null)
            {
                _updateResponse(state);
            }
        }

        public void GetPageList(PageListQueryInfo<OrderRecordPageListQuery> info,
            Action<DataResponse<OrderRecordOptState, Page<OrderRecordDetails>>> getPageListResponse)
        {
            _getPageListResponse = getPageListResponse;
            var future = Global.SendToServer(info, MessageType.GetOrderRecordListRequest);

            if (future == null)
            {
                GetPageListResponse(new DataResponse<OrderRecordOptState, Page<OrderRecordDetails>>
                {
                    State = OrderRecordOptState.CannotConnectServer
                });
            }
        }

        public void GetPageListResponse(
            DataResponse<OrderRecordOptState, Page<OrderRecordDetails>> response)
        {
            if(_getPageListResponse != null)
            {
                _getPageListResponse(response);
            }
        }

        public void GetConfirmReceiptInfo(OrderRecord record,
            Action<DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo>> getConfirmReceiptInfoResponse)
        {
            _getConfirmReceiptInfoResponse = getConfirmReceiptInfoResponse;

            var future = Global.SendToServer(record, MessageType.GetGetConfirmReceiptInfoRequest);

            if (future == null)
            {
                GetConfirmReceiptInfoResponse(new DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo>
                {
                    State = OrderRecordOptState.CannotConnectServer
                });
            }
        }

        public void GetConfirmReceiptInfoResponse(DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo> response)
        {
            if(_getConfirmReceiptInfoResponse != null)
            {
                _getConfirmReceiptInfoResponse(response);
            }
        }
    }
}