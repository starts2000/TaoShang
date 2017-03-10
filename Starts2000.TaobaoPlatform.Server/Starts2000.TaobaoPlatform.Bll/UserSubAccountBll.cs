using System.Collections.Generic;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaobaoPlatform.Utils.Security;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class UserSubAccountBll : IUserSubAccountBll
    {
        readonly IUserSubAccountDal _subAccountDal;

        public UserSubAccountBll(IUserSubAccountDal subAccountDal)
        {
            _subAccountDal = subAccountDal;
        }

        public UserSubAccountOptState Add(UserSubAccount subAccount)
        {
            return _subAccountDal.Add(subAccount) ?
                UserSubAccountOptState.Successed : UserSubAccountOptState.Failed;
        }

        public UserSubAccountOptState Update(UserSubAccount subAccount)
        {
            return _subAccountDal.Update(subAccount) ?
                UserSubAccountOptState.Successed : UserSubAccountOptState.Failed;
        }


        public UserSubAccountOptState Delete(UserSubAccount subAccount)
        {
            return _subAccountDal.Delete(subAccount) ?
                UserSubAccountOptState.Successed : UserSubAccountOptState.Failed;
        }

        public IList<UserSubAccount> GetList(int userId)
        {
            return _subAccountDal.GetList(userId);
        }

        public int Count(int userId)
        {
            return _subAccountDal.Count(userId);
        }

        public Page<UserSubAccountDetails> GetPageList(int userId, PageListQueryInfo<UserSubAccountPageListQuery> info)
        {
            int count;
            var list = _subAccountDal.GetPageList(userId, info, out count);
            info.Count = count;
            return new Page<UserSubAccountDetails>
            {
                Info = info as PageListInfo,
                List = list
            };
        }
    }
}