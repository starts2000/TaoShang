using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface IOrderStateBll
    {
        IList<OrderState> GetList();
    }
}