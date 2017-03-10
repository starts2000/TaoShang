using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class UserSubAccountOrderTypeInfoBll : IUserSubAccountOrderTypeInfoBll
    {
        readonly IUserSubAccountOrderTypeInfoDal _userSubAccountOrderTypeInfoDal;

        public UserSubAccountOrderTypeInfoBll(IUserSubAccountOrderTypeInfoDal userSubAccountOrderTypeInfoDal)
        {
            _userSubAccountOrderTypeInfoDal = userSubAccountOrderTypeInfoDal;
        }

        #region IUserSubAccountOrderTypeInfoBll 成员

        public bool UpdateOrderTypeCount(int subAccountId, int orderTypeId)
        {
            return _userSubAccountOrderTypeInfoDal.UpdateOrderTypeCount(subAccountId, orderTypeId);
        }

        #endregion
    }
}
