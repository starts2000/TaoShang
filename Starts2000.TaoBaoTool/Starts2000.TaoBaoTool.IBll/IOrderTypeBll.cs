using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface IOrderTypeBll
    {
        void GetList(Action<DataResponse<OrderTypeOptState, IList<OrderType>>> getListResponse);
        void GetListResponse(DataResponse<OrderTypeOptState, IList<OrderType>> response);
    }
}
