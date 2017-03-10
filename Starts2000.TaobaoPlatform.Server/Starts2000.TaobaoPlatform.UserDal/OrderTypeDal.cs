using System.Collections.Generic;
using System.Linq;
using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class OrderTypeDal : DalBase, IOrderTypeDal
    {
        public IList<OrderType> GetList()
        {
            const string sql = @"
                SELECT  [Id] ,
                        [Name]
                FROM    [OrderType]";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Query<OrderType>(sql).ToList();
            }
        }
    }
}
