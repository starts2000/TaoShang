using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Dal
{
    internal class OrderStateDal : IOrderStateDal
    {
        public IList<OrderState> GetList()
        {
            return new List<OrderState>
            {
                new OrderState
                {
                    Id = 999999,
                    Name = "刷单失败"
                },
                new OrderState
                {
                    Id = 10,
                    Name = "查看商品"
                },
                new OrderState
                {
                    Id = 20,
                    Name = "已经下单"
                },
                new OrderState
                {
                    Id = 30,
                    Name = "已经付款"
                },
                new OrderState
                {
                    Id = 40,
                    Name = "收货评价"
                }
            };
        }
    }
}