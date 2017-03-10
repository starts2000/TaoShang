using System.Collections.Generic;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class OrderTypeBll : IOrderTypeBll
    {
        readonly IOrderTypeDal _orderTypeDal;

        public OrderTypeBll(IOrderTypeDal orderTypeDal)
        {
            _orderTypeDal = orderTypeDal;
        }

        public IList<OrderType> GetList()
        {
            return _orderTypeDal.GetList();
        }
    }
}
