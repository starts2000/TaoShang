using System.Linq;
using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class UserDal : DalBase, IUserDal
    {
        public bool Exists(string account)
        {
            const string sql = @"
            SELECT  COUNT(1) AS Count
            FROM    [User]
            WHERE   Account = @Account";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Query<int>(sql, new User
                {
                    Account = account
                }).First() > 0;
            }
        }

        public bool Add(User user)
        {
            const string sql = @"
                INSERT  INTO [User]
                        ( Account ,
                          Password ,
                          Name ,
                          QQ ,
                          Email ,
                          Mobile ,
                          ReferrerAccount ,
                          Salt                        
                        )
                VALUES  ( @Account ,
                          @Password ,
                          @Name ,
                          @QQ ,
                          @Email ,
                          @Mobile ,
                          @ReferrerAccount ,
                          @Salt                        
                        )";
            using(var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, user) > 0;
            }
        }

        public User Get(string account)
        {
            const string sql = @"
                SELECT  Id ,
                        Account ,
                        Password ,
                        IsAudit ,
                        Lock ,
                        Salt ,
                        ExpireDate
                FROM    [User]
                WHERE   Account = @Account";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Query<User>(sql, new User
                    {
                        Account = account
                    }).FirstOrDefault();
            }
        }

        public User Get(int id)
        {
            const string sql = @"
                SELECT  Id ,
                        Account ,
                        Password ,
                        IsAudit ,
                        Lock ,
                        Salt ,
                        ExpireDate
                FROM    [User]
                WHERE   Id = @Id";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<User>(sql, new User
                {
                    Id = id
                }).FirstOrDefault();
            }
        }

        public User GetInfo(int id)
        {
            const string sql = @"
                SELECT  UT.Account ,
                        UT.Gold ,
                        UT.ExpireDate ,
                        UT.MemberLevelId ,
                        MLT.Name
                FROM    [User] UT
                        LEFT JOIN MemberLevel MLT ON MLT.Id = UT.MemberLevelId
                WHERE   UT.Id = @Id";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<User>(sql, new User
                {
                    Id = id
                }).FirstOrDefault();
            }
        }

        public int GetGold(int id)
        {
            const string sql = @"
                SELECT  Gold
                FROM    [User]
                WHERE   Id = @Id";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<int>(sql, new User
                {
                    Id = id
                }).First();
            }
        }

        public bool UpdateGold(int userId, int gold)
        {
            const string sql = @"
                UPDATE  [User]
                SET     [Gold] = [Gold] + @Gold
                WHERE   Id = @Id";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new User
                {
                    Id = userId,
                    Gold = gold
                }) > 0;
            }
        }

        public bool UpdateClientLogin(UserLoginState state)
        {
            const string sql = @"
                IF ( EXISTS ( SELECT    UserId
                              FROM      UserLoginState
                              WHERE     UserId = @UserId ) ) 
                    BEGIN
                        UPDATE  UserLoginState
                        SET     ClientLastLoginIpAddress = @ClientLastLoginIpAddress ,
                                ClientLogin = 1 ,
                                ClientLastLoginTime = @ClientLastLoginTime
                        WHERE   UserId = @UserId
                    END
                ELSE 
                    BEGIN
                        INSERT  INTO UserLoginState
                                ( UserId ,
                                  ClientLastLoginIpAddress ,
                                  ClientLogin ,
                                  ClientLastLoginTime
		                        )
                        VALUES  ( @UserId ,
                                  @ClientLastLoginIpAddress ,
                                  1 ,
                                  @ClientLastLoginTime
                                )
                    END";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, state) > 0;
            }
        }

        public bool UpdateClientLogout(int userId)
        {
            const string sql = @"
                UPDATE  UserLoginState
                SET     ClientLogin = 0
                WHERE   UserId = @UserId";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new UserLoginState
                {
                    UserId = userId
                }) > 0;
            }
        }

        public bool DeductionGold(int id, int gold)
        {
            const string sql = @"
                UPDATE  [User]
                SET     Gold = Gold - @Gold
                WHERE   Id = @Id
                        AND Gold >= @Gold";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new User
                {
                    Id = id,
                    Gold = gold
                }) > 0;
            }
        }

        public bool UpdatePassword(int id, string password)
        {
            const string sql = @"
                UPDATE  [User]
                SET     [Password] = @Password
                WHERE   Id = @Id";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new User
                {
                    Id = id,
                    Password = password
                }) > 0;
            }
        }
    }
}