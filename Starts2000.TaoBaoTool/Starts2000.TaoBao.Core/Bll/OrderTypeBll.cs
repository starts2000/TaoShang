using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.Bll
{
    internal class OrderTypeBll : IOrderTypeBll
    {
        Action<DataResponse<OrderTypeOptState, IList<OrderType>>> _getListResponse;

        #region IOrderTypeBll 成员

        public void GetList(Action<DataResponse<OrderTypeOptState, IList<OrderType>>> getListResponse)
        {
            _getListResponse = getListResponse;

            var future = Global.SendToServer(1, MessageType.GetOrderTypeListRequest);
            if(future == null)
            {
                GetListResponse(new DataResponse<OrderTypeOptState, IList<OrderType>>
                {
                    State = OrderTypeOptState.CannotConnectServer
                });
            }
        }

        public void GetListResponse(DataResponse<OrderTypeOptState, IList<OrderType>> response)
        {
            if(_getListResponse!= null)
            {
                _getListResponse(response);
            }
        }

        #endregion
    }
}
