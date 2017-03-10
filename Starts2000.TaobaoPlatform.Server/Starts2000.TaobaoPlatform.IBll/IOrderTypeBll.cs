using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IBll
{
    public interface IOrderTypeBll
    {
        IList<OrderType> GetList();
    }
}
