using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class UserSubAccountDal : DalBase, IUserSubAccountDal
    {
        static UserSubAccountDal()
        {
            SqlMapper.SetTypeMap(
                typeof(OrderTypeDetails),
                new ColumnAttributeTypeMapper<OrderTypeDetails>());
        }

        public IList<UserSubAccount> GetList(int userId)
        {
            const string sql = @"
                SELECT  [Id] ,
                        [TaoBaoAccount] ,
                        [Password] ,
                        [PayPassword] ,
                        [HomePage] ,
                        [Level] ,
                        [ConsumptionLevel] ,
                        [Province] ,
                        [City] ,
                        [District] ,
                        [Age] ,
                        [Sex] ,
                        [UpperLimitAmount] ,
                        [UpperLimitNumber] ,
                        [Commission] ,
                        [ShippingAddress] ,
                        [IsRealName] ,
                        [IsBindingMobile] ,
                        [IsEnabled] ,
                        [IsAudit] ,
                        [UserId]
                FROM    [UserSubAccount]
                WHERE   UserId = @UserId";
            using(var con = DbFactory.CreateConnection())
            {
                return con.Query<UserSubAccount>(sql, new UserSubAccount
                {
                    UserId = userId
                }).ToList();
            }
        }

        public bool Add(UserSubAccount subAccount)
        {
            const string sql = @"
                INSERT  INTO [UserSubAccount]
                        ( [TaoBaoAccount] ,
                          [Password] ,
                          [PayPassword] ,
                          [HomePage] ,
                          [Level] ,
                          [ConsumptionLevel] ,
                          [Province] ,
                          [City] ,
                          [District] ,
                          [Age] ,
                          [Sex] ,
                          [UpperLimitAmount] ,
                          [UpperLimitNumber] ,
                          [Commission] ,
                          [ShippingAddress] ,
                          [IsRealName] ,
                          [IsBindingMobile] ,
                          [IsEnabled] ,
                          [IsAudit] ,
                          [UserId]
                        )
                VALUES  ( @TaoBaoAccount ,
                          @Password ,
                          @PayPassword ,
                          @HomePage ,
                          @Level ,
                          @ConsumptionLevel ,
                          @Province ,
                          @City ,
                          @District ,
                          @Age ,
                          @Sex ,
                          @UpperLimitAmount ,
                          @UpperLimitNumber ,
                          @Commission ,
                          @ShippingAddress ,
                          @IsRealName ,
                          @IsBindingMobile ,
                          @IsEnabled ,
                          @IsAudit ,
                          @UserId
                        )";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, subAccount) > 0;
            }
        }

        public bool Update(UserSubAccount subAccount)
        {
            const string sql = @"
                UPDATE  [UserSubAccount]
                SET     [TaoBaoAccount] = @TaoBaoAccount ,
                        [Password] = @Password ,
                        [PayPassword] = @PayPassword ,
                        [HomePage] = @HomePage ,
                        [Level] = @Level ,
                        [ConsumptionLevel] = @ConsumptionLevel ,
                        [Province] = @Province ,
                        [City] = @City ,
                        [District] = @District ,
                        [Age] = @Age ,
                        [Sex] = @Sex ,
                        [UpperLimitAmount] = @UpperLimitAmount ,
                        [UpperLimitNumber] = @UpperLimitNumber ,
                        [Commission] = @Commission ,
                        [ShippingAddress] = @ShippingAddress ,
                        [IsRealName] = @IsRealName ,
                        [IsBindingMobile] = @IsBindingMobile ,
                        [IsEnabled] = @IsEnabled ,
                        [IsAudit] = 0
                WHERE   Id = @Id";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, subAccount) > 0;
            }
        }

        public bool Delete(UserSubAccount subAccount)
        {
            const string sql = @"
                DELETE  FROM UserSubAccount
                WHERE   Id = @Id";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, subAccount) > 0;
            }
        }

        public int Count(int userId)
        {
            const string sql = @"
                SELECT  COUNT(1)
                FROM    [UserSubAccount]
                WHERE   UserId = @UserId
                        AND IsAudit = 1";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<int>(sql, new UserSubAccount
                {
                    UserId = userId
                }).First();
            }
        }

        public IList<UserSubAccountDetails> GetPageList(int userId,
            PageListQueryInfo<UserSubAccountPageListQuery> info, out int count)
        {
            const string sql = @"
                SELECT  COUNT(1) AS Count
                FROM    UserSubAccount USA
                WHERE   USA.UserId != @UserId
                        AND USA.IsAudit = 1
                        AND USA.IsEnabled = 1{0}
                SELECT  T1.* ,
                        T3.Id AS OrderTypeDetails_Id ,
                        T3.Name AS OrderTypeDetails_Name ,
                        T2.[Count] AS OrderTypeDetails_Count
                FROM    ( SELECT    T.Id ,
                                    T.TaoBaoAccount ,
                                    T.Level ,
                                    T.ConsumptionLevel ,
                                    T.Age ,
                                    T.Sex ,
                                    T.Province ,
                                    T.City ,
                                    T.District ,
                                    T.IsBindingMobile ,
                                    T.IsRealName ,
                                    T.ShippingAddress ,
                                    T.UserId ,
                                    T.DayOrderCount ,
                                    T.MonthOrderCount ,
                                    T.Account ,
                                    T.ClientLogin ,
                                    T.ClientLastLoginIpAddress
                          FROM      ( SELECT    USA.Id ,
                                                USA.TaoBaoAccount ,
                                                USA.Level ,
                                                USA.ConsumptionLevel ,
                                                USA.Age ,
                                                USA.Sex ,
                                                USA.Province ,
                                                USA.City ,
                                                USA.District ,
                                                USA.IsBindingMobile ,
                                                USA.IsRealName ,
                                                USA.ShippingAddress ,
                                                USA.UserId ,
                                                U.Account ,
                                                ULS.ClientLogin ,
                                                ULS.ClientLastLoginIpAddress ,
                                                USAUI.DayOrderCount ,
                                                USAUI.MonthOrderCount ,
                                                ROW_NUMBER() OVER ( ORDER BY ULS.ClientLogin DESC, U.Id, USA.Id ) AS Row
                                      FROM      UserSubAccount USA
                                                LEFT JOIN [User] U ON USA.UserId = U.Id
                                                LEFT JOIN UserLoginState ULS ON USA.UserId = ULS.UserId
                                                LEFT JOIN UserSubAccountUsageInfo USAUI ON USAUI.UserSubAccountId = USA.Id
                                      WHERE     USA.UserId != @UserId
                                                AND USA.IsAudit = 1
                                                AND USA.IsEnabled = 1{0}
                                    ) T
                          WHERE     T.Row BETWEEN @Start AND @End
                        ) T1
                        LEFT JOIN ( SELECT  UserSubAccountId ,
                                            OrderTypeId ,
                                            [Count] ,
                                            ROW_NUMBER() OVER ( PARTITION BY UserSubAccountId ORDER BY [Count] DESC ) AS Num
                                    FROM    UserSubAccountOrderTypeInfo
                                  ) T2 ON T2.UserSubAccountId = T1.Id
                                          AND T2.Num <= 3
                        LEFT JOIN OrderType T3 ON T3.Id = T2.OrderTypeId";

            StringBuilder query = new StringBuilder();
            if(!string.IsNullOrEmpty(info.Query.ProvinceName))
            {
                query.Append(" AND USA.Province = @ProvinceName");
            }

            if (!string.IsNullOrEmpty(info.Query.CityName))
            {
                query.Append(" AND USA.City = @CityName");
            }

            if (!string.IsNullOrEmpty(info.Query.DistrictName))
            {
                query.Append(" AND USA.District = @DistrictName");
            }

            var sqlTmp = string.Format(sql, query.ToString());

            using(var con = DbFactory.CreateConnection())
            {
                var reader = con.QueryMultiple(string.Format(sql, query.ToString()), new
                {
                    UserId = userId,
                    Start = (info.PageIndex - 1) * info.PageSize + 1,
                    End = info.PageIndex  * info.PageSize,
                    ProvinceName = info.Query.ProvinceName,
                    CityName = info.Query.CityName,
                    DistrictName = info.Query.DistrictName,
                });
                count = reader.Read<int>().Single();
                var userSubAccountDetailsDic = new Dictionary<int, UserSubAccountDetails>();
                reader.Read<UserSubAccountDetails, User, UserLoginState, OrderTypeDetails, UserSubAccountDetails>(
                    (details, user, userLoginState, orderTypeDetails) =>
                    {
                        UserSubAccountDetails userSubAccountDetails;
                        if (!userSubAccountDetailsDic.TryGetValue(details.Id, out userSubAccountDetails))
                        {
                            details.User = user;
                            details.UserLoginState = userLoginState;
                            userSubAccountDetailsDic.Add(details.Id, userSubAccountDetails = details);
                        }

                        if (orderTypeDetails != null && orderTypeDetails.Id.HasValue)
                        {
                            userSubAccountDetails.OrderTypeDetails.Add(orderTypeDetails);
                        }
                        return userSubAccountDetails;
                    }, "Account,ClientLogin,OrderTypeDetails_Id");

                return userSubAccountDetailsDic.Values.ToList();
            }
        }
    }
}