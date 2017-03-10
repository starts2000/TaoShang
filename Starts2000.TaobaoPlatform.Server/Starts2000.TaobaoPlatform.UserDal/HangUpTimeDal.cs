using System;
using System.Linq;
using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class HangUpTimeDal : DalBase, IHangUpTimeDal
    {
        public bool Add(HangUpTime hangUpTime)
        {
            const string sql = @"
                INSERT  INTO HangUpTime
                        ( UserId, Minutes )
                VALUES  ( @UserId, @Minutes )";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, hangUpTime) > 0;
            }
        }

        public int TotalMinutes(int userId)
        {
            const string sql = @"
                SELECT  SUM([Minutes]) AS TotalMinutes
                FROM    [HangUpTime]
                WHERE   UserId = @UserId
                        AND ( [DateTime] BETWEEN @StartTime AND @EndTime )";

            using (var con = DbFactory.CreateConnection())
            {
                var dateTime = DateTime.Now;
                return con.Query<int?>(sql, new
                    {
                        UserId = userId,
                        StartTime = dateTime.AddHours(-12),
                        EndTime = dateTime
                    }).First() ?? 0;
            }
        }
    }
}
