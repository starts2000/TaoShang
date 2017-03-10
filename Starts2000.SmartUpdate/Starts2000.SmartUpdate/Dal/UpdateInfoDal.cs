using System.Data.SQLite;
using System.Linq;
using Dapper;
using Starts2000.SmartUpdate.Models;
using Starts2000.SmartUpdate.Properties;

namespace Starts2000.SmartUpdate.Dal
{
    public class UpdateInfoDal
    {
        public UpdateInfo Get()
        {
            const string sql = @"
            SELECT *
              FROM UpdateInfo
             ORDER BY Id DESC
             LIMIT 1 OFFSET 0;";

            using (var con = DbFactory.CreateConnection())
           {
               return con.Query<UpdateInfo>(sql).FirstOrDefault();
           }
        }

        public bool Add(UpdateInfo info)
        {
            const string sql = @"
                INSERT INTO UpdateInfo ( 
                    Version,
                    LastUpdateTime 
                ) 
                VALUES ( 
                    @Version,
                    @LastUpdateTime 
                )";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, info) > 0;
            }
        }
    }
}
