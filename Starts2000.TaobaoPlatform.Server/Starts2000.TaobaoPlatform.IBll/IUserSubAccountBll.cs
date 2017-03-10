using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IBll
{
    public interface IUserSubAccountBll
    {
        UserSubAccountOptState Add(UserSubAccount subAccount);
        UserSubAccountOptState Delete(UserSubAccount subAccount);
        UserSubAccountOptState Update(UserSubAccount subAccount);
        IList<UserSubAccount> GetList(int userId);
        int Count(int userId);

        Page<UserSubAccountDetails> GetPageList(int userId, PageListQueryInfo<UserSubAccountPageListQuery> info);
    }
}
