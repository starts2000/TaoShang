using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class UserSubAccountUsageInfoBll : IUserSubAccountUsageInfoBll
    {
        readonly IUserSubAccountUsageInfoDal _userSubAccountUsageInfoDal;

        public UserSubAccountUsageInfoBll(IUserSubAccountUsageInfoDal userSubAccountUsageInfoDal)
        {
            _userSubAccountUsageInfoDal = userSubAccountUsageInfoDal;
        }


        #region IUserSubAccountUsageInfoBll 成员

        public bool UpdateOrderCount(int subAccountId)
        {
            return _userSubAccountUsageInfoDal.UpdateOrderCount(subAccountId);
        }

        #endregion
    }
}
