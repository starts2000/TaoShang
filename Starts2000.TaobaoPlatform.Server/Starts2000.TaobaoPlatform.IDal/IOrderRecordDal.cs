using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IDal
{
    public interface IOrderRecordDal
    {
        OrderRecord Get(int userId, int clientSubUserId);

        OrderRecord GetSubAccountIdAndOrderState(int id);

        bool Add(OrderRecord record);

        bool Update(OrderRecord record);

        IList<OrderRecordDetails> GetPageList(int userId,
            int? shopId, int? orderStateId, int start, int end, out int total);

        OrderRecordConfirmReceiptInfo GetConfirmReceiptInfo(
            int userId, int clientUserId, int clientSubUserAccountId);

        bool HasNotCompletedOrder(int userId, int clientUserId, int clientSubUserAccountId);
    }
}
