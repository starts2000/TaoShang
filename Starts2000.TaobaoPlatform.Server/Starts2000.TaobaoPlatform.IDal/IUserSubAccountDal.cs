using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IDal
{
    public interface IUserSubAccountDal
    {
        IList<UserSubAccount> GetList(int userId);

        bool Add(UserSubAccount subAccount);

        bool Delete(UserSubAccount subAccount);

        bool Update(UserSubAccount subAccount);

        int Count(int userId);

        IList<UserSubAccountDetails> GetPageList(int userId, PageListQueryInfo<UserSubAccountPageListQuery> info, out int count);
    }
}