using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IDal;
using Dapper;

namespace Starts2000.TaoBao.Core.Dal
{
    class UpdateInfoDal : DalBase, IUpdateInfoDal
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
    }
}