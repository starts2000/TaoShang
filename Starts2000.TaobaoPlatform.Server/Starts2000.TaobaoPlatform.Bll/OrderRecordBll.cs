using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class OrderRecordBll : IOrderRecordBll
    {
        readonly IOrderRecordDal _orderRecordDal;

        public OrderRecordBll(IOrderRecordDal orderRecordDal)
        {
            _orderRecordDal = orderRecordDal;
        }

        public OrderRecord Get(int userId, int clientSubUserId)
        {
            return _orderRecordDal.Get(userId, clientSubUserId);
        }

        public OrderRecord GetSubAccountIdAndOrderState(int id)
        {
            return _orderRecordDal.GetSubAccountIdAndOrderState(id);
        }

        public bool Add(OrderRecord record)
        {
            return _orderRecordDal.Add(record);
        }

        public bool Update(OrderRecord record)
        {
            return _orderRecordDal.Update(record);
        }

        public Page<OrderRecordDetails> GetPageList(int userId, PageListQueryInfo<OrderRecordPageListQuery> info)
        {
           int count;
           var list = _orderRecordDal.GetPageList(userId, info.Query.ShopId, info.Query.OrderStateId,
               (info.PageIndex - 1) * info.PageSize + 1, info.PageIndex * info.PageSize, out count);
            info.Count = count;
            return new Page<OrderRecordDetails>
            {
                Info = info as PageListInfo,
                List = list
            };
        }

        public OrderRecordConfirmReceiptInfo GetConfirmReceiptInfo(
            int userId, int clientUserId, int clientSubUserAccountId)
        {
            return _orderRecordDal.GetConfirmReceiptInfo(userId, clientUserId, clientSubUserAccountId);
        }

        public bool HasNotCompletedOrder(int userId, int clientUserId, int clientSubUserAccountId)
        {
            return _orderRecordDal.HasNotCompletedOrder(userId, clientUserId, clientSubUserAccountId);
        }
    }
}
