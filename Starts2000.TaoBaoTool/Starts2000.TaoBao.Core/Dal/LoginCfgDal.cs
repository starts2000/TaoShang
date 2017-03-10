using System.Linq;
using Dapper;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Dal
{
    internal class LoginCfgDal : DalBase, ILoginCfgDal
    {
        #region ILoginCfgDal 成员

        public bool Exits(LoginCfg cfg)
        {
            const string sql = @"
                SELECT  COUNT(1) AS Count
                FROM    LoginCfg
                WHERE   Account = @Account";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Query<int>(sql, cfg).Single() > 0;
            }
        }

        public bool Add(LoginCfg cfg)
        {
            const string sql = @"
                INSERT  INTO LoginCfg
                        ( Account ,
                          Password ,
                          RememberPassword ,
                          AutoLogin
                        )
                VALUES  ( @Account ,
                          @Password ,
                          @RememberPassword ,
                          @AutoLogin
                        )";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, cfg) > 0;
            }
        }

        public bool Update(LoginCfg cfg)
        {
            const string sql = @"
                UPDATE  LoginCfg
                SET     Password = @Password ,
                        RememberPassword = @RememberPassword ,
                        AutoLogin = @AutoLogin
                WHERE   Account = @Account";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, cfg) > 0;
            }
        }

        public bool UpdatePassword(string account, string password)
        {
            const string sql = @"
                UPDATE  LoginCfg
                SET     Password = @Password
                WHERE   Account = @Account";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new LoginCfg
                {
                    Account = account,
                    Password = password
                }) > 0;
            }
        }

        public LoginCfg Get()
        {
            const string sql = @"
                SELECT  Account ,
                        Password ,
                        RememberPassword ,
                        AutoLogin
                FROM    LoginCfg LIMIT 0,1";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<LoginCfg>(sql).FirstOrDefault();
            }
        }

        public bool Delete(LoginCfg cfg)
        {
            const string sql = @"
                DELETE  FROM LoginCfg
                WHERE   Account = @Account";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, cfg) > 0;
            }
        }

        #endregion
    }
}
