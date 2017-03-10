using System.Linq;
using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class UpdateInfoDal : DalBase, IUpdateInfoDal
    {
        #region IUpdateInfoDal 成员

        public UpdateInfo Get(int clientType)
        {
            const string sql = @"
                SELECT TOP 1
                        Id ,
                        ClientType ,
                        Version ,
                        LastUpdateTime
                FROM    dbo.UpdateInfo
                WHERE   ClientType = @ClientType
                ORDER BY LastUpdateTime DESC";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Query<UpdateInfo>(sql, new UpdateInfo
                {
                    ClientType = clientType
                }).FirstOrDefault();
            }
        }

        #endregion
    }
}
