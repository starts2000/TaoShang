using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Starts2000.SmartUpdate.Server.Models;

namespace Starts2000.SmartUpdate.Server.Dal
{
    public class UpdateInfoDal
    {
        public UpdateInfo Get(int clientType, DateTime? lastUpdateTime)
        {
            const string sql = @"
                SELECT Id,
                       Version,
                       FileName,
                       Description,
                       DowloadUrl,
                       LastUpdateTime
                  FROM UpdateInfo
                 WHERE ClientType = @ClientType 
                       AND
                       LastUpdateTime > @LastUpdateTime";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<UpdateInfo>(sql, new UpdateInfo
                {
                    ClientType = clientType,
                    LastUpdateTime = lastUpdateTime.Value
                }).FirstOrDefault();
            }
        }

        public IEnumerable<UpdateInfo> GetList()
        {
            const string sql = "SELECT * FROM UpdateInfo";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Query<UpdateInfo>(sql);
            }
        }

        public bool Add(UpdateInfo info)
        {
            const string sql = @"
                INSERT INTO UpdateInfo ( 
                    Version,
                    FileName,
                    Description,
                    DowloadUrl,
                    LastUpdateTime,
                    ClientType 
                ) 
                VALUES ( 
                    @Version,
                    @FileName,
                    @Description,
                    @DowloadUrl,
                    @LastUpdateTime,
                    @ClientType 
                )";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, info) > 0;
            }
        }

        public bool Delete(int id)
        {
            const string sql = "DELETE FROM UpdateInfo WHERE Id = @Id";
            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new UpdateInfo
                {
                    Id = id
                }) > 0;
            }
        }
    }
}
