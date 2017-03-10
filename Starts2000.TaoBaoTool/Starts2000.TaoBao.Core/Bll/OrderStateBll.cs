using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Bll
{
    internal class OrderStateBll : IOrderStateBll
    {
        readonly IOrderStateDal _orderTypeDal;

        public OrderStateBll(IOrderStateDal orderTypeDal)
        {
            _orderTypeDal = orderTypeDal;
        }

        public IList<OrderState> GetList()
        {
            return _orderTypeDal.GetList();
        }
    }
}
