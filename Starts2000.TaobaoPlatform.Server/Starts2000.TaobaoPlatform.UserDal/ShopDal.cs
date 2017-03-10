using System.Collections.Generic;
using System.Linq;
using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class ShopDal : DalBase, IShopDal
    {
        public bool Add(Shop shop)
        {
            const string sql = @"
                INSERT  INTO [Shop]
                        ( WangWangAccount ,
                          ShopName ,
                          ShopLevel ,
                          ShopUrl ,
                          Audit ,
                          UserId
                        )
                VALUES  ( @WangWangAccount ,
                          @ShopName ,
                          @ShopLevel ,
                          @ShopUrl ,
                          @Audit ,
                          @UserId
                        )";
            using(var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, shop) > 0;
            }
        }

        public bool Delete(Shop shop)
        {
            const string sql = @"
                DELETE  FROM [Shop]
                WHERE   Id = @Id";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, shop) > 0;
            }
        }

        public IList<Shop> GetList(int userId, bool isAudit)
        {
            const string sql = @"
                SELECT  [Id] ,
                        [WangWangAccount] ,
                        [ShopName] ,
                        [ShopLevel] ,
                        [ShopUrl] ,
                        [Audit]
                FROM    [Shop]
                WHERE   UserId = @UserId{0}";
            string sqlTmp = string.Format(sql, isAudit ? " AND Audit = @Audit" : string.Empty);
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<Shop>(sqlTmp, new Shop
                    {
                        UserId = userId,
                        Audit = isAudit
                    }).ToList();
            }
        }

        public int AuditShopCount(int userId)
        {
            const string sql = @"
                SELECT  COUNT(1)
                FROM    [Shop]
                WHERE   [UserId] = @UserId
                        AND Audit = 1";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<int>(sql, new Shop
                {
                    UserId = userId
                }).First();
            }
        }

        public bool AuditShop(int userId, bool audit)
        {
            const string sql = @"
                UPDATE  Shop
                SET     Audit = @Audit
                WHERE   UserId = @UserId";
            using(var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new Shop
                {
                    UserId = userId,
                    Audit = audit
                }) > 0;
            }
        }
    }
}