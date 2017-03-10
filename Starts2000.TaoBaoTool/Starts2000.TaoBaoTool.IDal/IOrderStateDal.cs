using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IDal
{
    internal interface IOrderStateDal
    {
        IList<OrderState> GetList();
    }
}
