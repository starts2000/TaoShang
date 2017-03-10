using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starts2000.TaobaoPlatform.IDal
{
    public interface IUserSubAccountUsageInfoDal
    {
        bool UpdateOrderCount(int subAccountId);
    }
}
