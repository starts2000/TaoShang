using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface IOrderRecordBll
    {
        void Get(int clientUserSubAaccountId,
            Action<DataResponse<OrderRecordOptState, OrderRecord>> getResponse);

        void GetResponse(DataResponse<OrderRecordOptState, OrderRecord> response);

        void Add(OrderRecord record, Action<OrderRecordOptState> addResponse);

        void AddResponse(OrderRecordOptState state);

        void Update(OrderRecord record, Action<OrderRecordOptState> updateResponse);

        void UpdateResponse(OrderRecordOptState state);

        void GetPageList(PageListQueryInfo<OrderRecordPageListQuery> info, Action<DataResponse<
            OrderRecordOptState, Page<OrderRecordDetails>>> getPageListResponse);

        void GetPageListResponse(DataResponse<
            OrderRecordOptState, Page<OrderRecordDetails>> response);

        void GetConfirmReceiptInfo(OrderRecord record,
            Action<DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo>> getConfirmReceiptInfoResponse);

        void GetConfirmReceiptInfoResponse(DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo> response);
    }
}
