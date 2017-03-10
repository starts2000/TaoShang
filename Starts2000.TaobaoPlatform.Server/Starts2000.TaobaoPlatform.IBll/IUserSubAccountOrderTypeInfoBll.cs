using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starts2000.TaobaoPlatform.IBll
{
    public interface IUserSubAccountOrderTypeInfoBll
    {
        bool UpdateOrderTypeCount(int subAccountId, int orderTypeId);
    }
}
