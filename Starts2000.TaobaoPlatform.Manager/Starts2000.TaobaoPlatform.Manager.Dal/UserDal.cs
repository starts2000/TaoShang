using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Starts2000.TaobaoPlatform.Manager.Models;
using Starts2000.TaobaoPlatform.Manager.Utils;

namespace Starts2000.TaobaoPlatform.Manager.Dal
{
    public class UserDal
    {
        public IList<User> GetList(string account, int pageIndex, int pageSize, out int total)
        {
            const string sql = @"
                SELECT  COUNT(1)
                FROM    [User]{0}

                SELECT  T.[Id] ,
                        T.[Account] ,
                        T.[Name] ,
                        T.[QQ] ,
                        T.[Email] ,
                        T.[Mobile] ,
                        T.[Salt] ,
                        T.[Lock] ,
                        T.[Gold] ,
                        T.[IsAudit] ,
                        T.[ExpireDate] ,
                        T.[MemberLevelId]
                FROM    ( SELECT    [Id] ,
                                    [Account] ,
                                    [Name] ,
                                    [QQ] ,
                                    [Email] ,
                                    [Mobile] ,
                                    [Salt] ,
                                    [Lock] ,
                                    [Gold] ,
                                    [IsAudit] ,
                                    [ExpireDate] ,
                                    [MemberLevelId] ,
                                    ROW_NUMBER() OVER ( ORDER BY Id DESC ) AS RowNum
                          FROM      [User]{0}
                        ) T
                WHERE   T.RowNum BETWEEN @Start AND @End";

            string sqlTmp = string.Format(sql, string.IsNullOrEmpty(account) ? 
                "" : " WHERE Account = @Account");

            using(var con = DbFactory.Instance.CreateConnection())
            {
                var reader = con.QueryMultiple(sqlTmp, new
                    {
                        Account = account,
                        Start = (pageIndex - 1) * pageSize + 1,
                        End = pageIndex * pageSize
                    });

                total = reader.Read<int>().First();
                return reader.Read<User>().ToList();
            }
        }

        public bool Audit(int id, bool audit, bool locked, DateTime? expireDate)
        {
            const string sql = @"
                UPDATE  [User]
                SET     IsAudit = @IsAudit ,
                        Lock = @Lock ,
                        ExpireDate = @ExpireDate
                WHERE   Id = @Id";

            using(var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, new User
                    {
                        Id = id,
                        IsAudit = audit,
                        Lock = locked,
                        ExpireDate = expireDate
                    }) > 0;
            }
        }

        public bool UpdateGold(int userId, int gold)
        {
            const string sql = @"
                UPDATE  [User]
                SET     [Gold] = [Gold] + @Gold
                WHERE   Id = @Id";
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, new User
                {
                    Id = userId,
                    Gold = gold
                }) > 0;
            }
        }

        public bool ChangePassword(int userId, string password, string salt)
        {
            const string sql = @"
                UPDATE  [User]
                SET     [Password] = @Password
                WHERE   Id = @Id";

            password = PasswordEncrypt.GetEncryptPassword(password, salt);
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, new User
                {
                    Id = userId,
                    Password = password
                }) > 0;
            }
        }
    }

    public class HangUpTimeDal
    {
        public bool Insert(int userId, int minutes)
        {
            const string sql = @"
                INSERT  INTO [HangUpTime]
                        ( [UserId], [Minutes] )
                VALUES  ( @UserId, @Minutes )";

            using(var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, new
                    {
                        UserId = userId,
                        Minutes = minutes
                    }) > 0;
            }
        }
    }

    public class ShopDal
    {
        public IList<Shop> GetList(int userId, bool isAudit = false)
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
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Query<Shop>(sqlTmp, new Shop
                {
                    UserId = userId,
                    Audit = isAudit
                }).ToList();
            }
        }  
     
        public bool Update(Shop shop)
        {
            const string sql = @"
                UPDATE  [Shop]
                SET     [ShopName] = @ShopName ,
                        [ShopLevel] = @ShopLevel ,
                        [ShopUrl] = @ShopUrl
                WHERE   Id = @Id";
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, shop) > 0;
            }
        }

        public bool Audit(int shopId, bool audit)
        {
            const string sql = @"
                UPDATE  [Shop]
                SET     [Audit] = @Audit
                WHERE   Id = @Id";
            using(var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, new Shop
                {
                    Id = shopId,
                    Audit = audit
                }) > 0;
            }
        }

        public bool Delete(int shopId)
        {
            const string sql = @"
                DELETE FROM  [Shop]
                WHERE   Id = @Id";
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, new Shop
                {
                    Id = shopId
                }) > 0;
            }
        }
    }

    public class UserSubAccountDal
    {
        public IList<UserSubAccount> GetList(int userId)
        {
            const string sql = @"
                SELECT  [Id] ,
                        [TaoBaoAccount] ,
                        [Password] ,
                        [PayPassword] ,
                        [Level] ,
                        [IsRealName] ,
                        [IsBindingMobile] ,
                        [IsEnabled] ,
                        [IsAudit]
                FROM    [UserSubAccount]
                WHERE   UserId = @UserId";
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Query<UserSubAccount>(sql, new UserSubAccount
                {
                    UserId = userId
                }).ToList();
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
                        [IsBindingMobile] = @IsBindingMobile
                WHERE   Id = @Id";
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, subAccount) > 0;
            }
        }

        public bool Audit(int userSubAccountId, bool audit)
        {
            const string sql = @"
                UPDATE  [UserSubAccount]
                SET     [IsAudit] = @IsAudit
                WHERE   Id = @Id";
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, new UserSubAccount
                {
                    Id = userSubAccountId,
                    IsAudit = audit
                }) > 0;
            }
        }

        public bool Delete(int userSubAccountId)
        {
            const string sql = @"
                DELETE FROM  [UserSubAccount]
                WHERE   Id = @Id";
            using (var con = DbFactory.Instance.CreateConnection())
            {
                return con.Execute(sql, new UserSubAccount
                {
                    Id = userSubAccountId
                }) > 0;
            }
        }
    }
}