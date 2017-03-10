using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class OrderRecordDal : DalBase, IOrderRecordDal
    {
        public OrderRecord Get(int userId, int clientSubUserId)
        {
            const string sql = @"
                SELECT  ORT.[Id] ,
                        ORT.[UserId] ,
                        ORT.[UserShopId] ,
                        ORT.[ClientUserId] ,
                        ORT.[ClientUserSubAccountId] ,
                        USA.TaoBaoAccount AS ClientUserSubAccount ,
                        ORT.[OrderNum] ,
                        ORT.[OrderStateId] ,
                        ORT.[OrderTypeId] ,
                        ORT.[StartDateTime] ,
                        ORT.[LastUpdateDateTime]
                FROM    [OrderRecord] ORT
                        LEFT JOIN UserSubAccount USA ON USA.Id = ORT.ClientUserSubAccountId
                WHERE   ORT.UserId = @UserId
                        AND ORT.ClientUserSubAccountId = @ClientUserSubAccountId
                        AND ( ORT.OrderStateId BETWEEN 10 AND 39 )
                        AND ORT.StartDateTime >= @StartDateTime";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Query<OrderRecord>(sql, new OrderRecord
                    {
                        UserId = userId,
                        ClientUserSubAccountId = clientSubUserId,
                        StartDateTime  = DateTime.Now.AddDays(-30)
                    }).FirstOrDefault();
            }
        }

        public OrderRecord GetSubAccountIdAndOrderState(int id)
        {
            const string sql = @"
                SELECT  ClientUserSubAccountId ,
                        OrderStateId
                FROM    OrderRecord
                WHERE   Id = @Id";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<OrderRecord>(sql, new OrderRecord
                    {
                        Id = id
                    }).FirstOrDefault();
            }
        }

        public bool Add(OrderRecord record)
        {
            const string sql = @"
                INSERT INTO OrderRecord
                           (UserId
                           ,UserShopId
                           ,ClientUserId
                           ,ClientUserSubAccountId
                           ,OrderNum
                           ,OrderStateId
                           ,OrderTypeId
                           ,StartDateTime
                           ,LastUpdateDateTime
                           ,OrderIp)
                     VALUES
                           (@UserId
                           ,@UserShopId
                           ,@ClientUserId
                           ,@ClientUserSubAccountId
                           ,@OrderNum
                           ,@OrderStateId
                           ,@OrderTypeId
                           ,@StartDateTime
                           ,@LastUpdateDateTime
                           ,@OrderIp)";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, record) > 0;
            }
        }

        public bool Update(OrderRecord record)
        {
            const string sql = @"
                UPDATE  [OrderRecord]
                SET     [OrderNum] = @OrderNum ,
                        [OrderStateId] = @OrderStateId ,
                        [LastUpdateDateTime] = @LastUpdateDateTime ,
                        [OrderIp] = @OrderIp
                WHERE   Id = @Id";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, record) > 0;
            }
        }

        public IList<OrderRecordDetails> GetPageList(int userId,
            int? shopId, int? orderStateId, int start, int end, out int total)
        {
            const string sql = @"
                SELECT  COUNT(1) AS Total
                FROM    OrderRecord ORT
                WHERE   ORT.UserId = @UserId{0}

                SELECT  T.Id ,
                        T.UserId ,
                        T.UserShopId ,
                        T.UserShopWangWangAccount ,
                        T.ClientUserId ,
                        T.ClientUserAccount ,
                        T.ClientUserSubAccountId ,
                        T.ClientUserSubAccount ,
                        T.ClientUserLogin ,
                        T.OrderIp ,
                        T.OrderNum ,
                        T.OrderStateId ,
                        T.OrderTypeId ,
                        T.StartDateTime ,
                        T.LastUpdateDateTime
                FROM    ( SELECT    ORT.Id ,
                                    ORT.UserId ,
                                    ORT.UserShopId ,
                                    ST.WangWangAccount AS UserShopWangWangAccount ,
                                    ORT.ClientUserId ,
                                    UT.Account AS ClientUserAccount ,
                                    ORT.ClientUserSubAccountId ,
                                    USAT.TaoBaoAccount AS ClientUserSubAccount ,
                                    ULST.ClientLogin AS ClientUserLogin ,
                                    ULST.ClientLastLoginIpAddress AS OrderIp ,
                                    ORT.OrderNum ,
                                    ORT.OrderStateId ,
                                    ORT.OrderTypeId ,
                                    ORT.StartDateTime ,
                                    ORT.LastUpdateDateTime ,
                                    ROW_NUMBER() OVER ( ORDER BY ORT.OrderStateId, ORT.Id DESC ) AS RowNum
                          FROM      OrderRecord ORT
                                    LEFT JOIN Shop ST ON ST.Id = ORT.UserShopId
                                    LEFT JOIN [User] UT ON UT.Id = ClientUserId
                                    LEFT JOIN UserSubAccount USAT ON USAT.Id = ORT.ClientUserSubAccountId
                                    LEFT JOIN UserLoginState ULST ON ULST.UserId = ORT.ClientUserId
                          WHERE     ORT.UserId = @UserId{0}
                        ) T
                WHERE   T.RowNum BETWEEN @Start AND @End";

            StringBuilder querySb = new StringBuilder();
            if(shopId.HasValue)
            {
                querySb.Append(" AND ORT.UserShopId = @UserShopId");
            }

            if (orderStateId.HasValue)
            {
                querySb.Append(" AND ORT.OrderStateId = @OrderStateId");
            }

            string sqlTmp = string.Format(sql, querySb.ToString());

            using(var con = DbFactory.CreateConnection())
            {
                var reader = con.QueryMultiple(sqlTmp, new
                {
                    UserId = userId,
                    UserShopId = shopId ?? 0,
                    OrderStateId = orderStateId ?? 0,
                    Start = start,
                    End = end
                });

                total = reader.Read<int>().First();
                return reader.Read<OrderRecordDetails>().ToList();
            }
        }

        public OrderRecordConfirmReceiptInfo GetConfirmReceiptInfo(
            int userId, int clientUserId, int clientSubUserAccountId)
        {
            const string sql = @"
                SELECT  USAT.TaoBaoAccount AS ClientUserSubAccount ,
                        ORT.OrderNum ,
                        USAT.PayPassword
                FROM    OrderRecord ORT
                        LEFT JOIN UserSubAccount USAT ON ORT.ClientUserSubAccountId = USAT.Id
                WHERE   ORT.UserId = @UserId
                        AND ORT.ClientUserId = @ClientUserId
                        AND ORT.ClientUserSubAccountId = @ClientUserSubAccountId
                        AND ORT.OrderStateId BETWEEN 10 AND 39
                        AND ORT.StartDateTime >= @StartDateTime";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<OrderRecordConfirmReceiptInfo>(sql, new OrderRecord
                {
                    UserId = userId,
                    ClientUserId = clientUserId,
                    ClientUserSubAccountId = clientSubUserAccountId,
                    StartDateTime = DateTime.Now.AddDays(-30)
                }).FirstOrDefault();
            }
        }

        public bool HasNotCompletedOrder(int userId, int clientUserId, int clientSubUserAccountId)
        {
            const string sql = @"
                SELECT  COUNT(1) AS COUNT
                FROM    [OrderRecord]
                WHERE   UserId = @UserId
                        AND ClientUserId = @ClientUserId
                        AND ClientUserSubAccountId = @ClientUserSubAccountId
                        AND ( OrderStateId BETWEEN 10 AND 39 )
                        AND StartDateTime >= @StartDateTime";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<int>(sql, new OrderRecord
                {
                    UserId = userId,
                    ClientUserId = clientUserId,
                    ClientUserSubAccountId = clientSubUserAccountId,
                    StartDateTime = DateTime.Now.AddDays(-30)
                }).First() > 0;
            }
        }
    }
}