using Dapper;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class UserSubAccountOrderTypeInfoDal : DalBase, IUserSubAccountOrderTypeInfoDal
    {
        #region IUserSubAccountOrderTypeInfoDal 成员

        public bool UpdateOrderTypeCount(int subAccountId, int orderTypeId)
        {
            const string sql = @"
                IF ( EXISTS ( SELECT    1
                              FROM      UserSubAccountOrderTypeInfo
                              WHERE     UserSubAccountId = @UserSubAccountId
                                        AND OrderTypeId = @OrderTypeId ) ) 
                    BEGIN
                        UPDATE  UserSubAccountOrderTypeInfo
                        SET     [Count] = [Count] + 1
                        WHERE   UserSubAccountId = @UserSubAccountId
                                AND OrderTypeId = @OrderTypeId
                    END
                ELSE 
                    BEGIN
                        INSERT  INTO UserSubAccountOrderTypeInfo
                                ( UserSubAccountId ,
                                  OrderTypeId ,
                                  [Count] 
                                )
                        VALUES  ( @UserSubAccountId ,
                                  @OrderTypeId ,
                                  1 
                                )
                    END";

            using (var con = DbFactory.CreateConnection())
            {
                return con.Execute(sql, new UserSubAccountOrderTypeInfo
                {
                    UserSubAccountId = subAccountId,
                    OrderTypeId = orderTypeId
                }) > 0;
            }
        }

        #endregion
    }
}