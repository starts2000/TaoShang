using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starts2000.TaobaoPlatform.IBll
{
    public interface IUserSubAccountUsageInfoBll
    {
        bool UpdateOrderCount(int subAccountId);
    }
}
