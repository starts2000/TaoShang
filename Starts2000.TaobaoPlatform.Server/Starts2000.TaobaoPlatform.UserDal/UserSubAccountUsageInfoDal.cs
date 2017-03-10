using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class UserSubAccountUsageInfoDal : DalBase, IUserSubAccountUsageInfoDal
    {
        #region IUserSubAccountUsageInfoDal 成员

        public bool UpdateOrderCount(int subAccountId)
        {
            const string sql = @"
                IF ( EXISTS ( SELECT    1
                              FROM      UserSubAccountUsageInfo
                              WHERE     UserSubAccountId = @UserSubAccountId ) ) 
                    BEGIN
                        UPDATE  UserSubAccountUsageInfo
                        SET     DayOrderCount = DayOrderCount + 1 ,
                                MonthOrderCount = MonthOrderCount + 1
                        WHERE   UserSubAccountId = @UserSubAccountId
                    END
                ELSE 
                    BEGIN
                        INSERT  INTO UserSubAccountUsageInfo
                                ( UserSubAccountId, DayOrderCount, MonthOrderCount )
                        VALUES  ( @UserSubAccountId, 1, 1 )
                    END";

            using(var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new UserSubAccountUsageInfo
                {
                    UserSubAccountId = subAccountId
                }) > 0;
            }
        }

        #endregion
    }
}
