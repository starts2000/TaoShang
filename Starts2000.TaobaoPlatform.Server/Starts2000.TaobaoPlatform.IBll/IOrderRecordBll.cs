using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IBll
{
    public interface IOrderRecordBll
    {
        OrderRecord Get(int userId, int clientSubUserId);

        OrderRecord GetSubAccountIdAndOrderState(int id);

        bool Add(OrderRecord record);

        bool Update(OrderRecord record);

        Page<OrderRecordDetails> GetPageList(
            int userId, PageListQueryInfo<OrderRecordPageListQuery> info);

        OrderRecordConfirmReceiptInfo GetConfirmReceiptInfo(
            int userId, int clientUserId, int clientSubUserAccountId);

        bool HasNotCompletedOrder(int userId, int clientUserId, int clientSubUserAccountId);
    }
}
