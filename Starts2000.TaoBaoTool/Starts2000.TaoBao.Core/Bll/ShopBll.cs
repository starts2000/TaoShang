using System;
using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.Bll
{
    class ShopBll : IShopBll
    {
        Action<ShopOptState> _addResponse;
        Action<ShopOptState> _deleteResponse;
        Action<DataResponse<ShopOptState, IList<Shop>>> _getListResponse;

        public void Add(Shop shop, Action<ShopOptState> addResponse)
        {
            _addResponse = addResponse;
            var future = Global.SendToServer(shop, MessageType.AddShopRequest);
            if (future == null)
            {
                addResponse(ShopOptState.CannotConnectServer);
            }
        }

        public void Delete(Shop shop, Action<ShopOptState> deleteResponse)
        {
            _deleteResponse = deleteResponse;
            var future = Global.SendToServer(shop, MessageType.DeleteShopRequest);
            if (future == null)
            {
                deleteResponse(ShopOptState.CannotConnectServer);
            }
        }

        public void GetList(bool isAudit, Action<DataResponse<ShopOptState, IList<Shop>>> getListResponse)
        {
            _getListResponse = getListResponse;

            var future = Global.SendToServer(isAudit, MessageType.GetShopListRequest);
            if(future == null)
            {
                getListResponse(new DataResponse<ShopOptState, IList<Shop>>
                {
                    State = ShopOptState.CannotConnectServer
                });
            }
        }

        public void AddResponse(ShopOptState state)
        {
            if(_addResponse != null)
            {
                _addResponse(state);
            }
        }

        public void DeleteResponse(ShopOptState state)
        {
            if(_deleteResponse != null)
            {
                _deleteResponse(state);
            }
        }

        public void GetListResponse(DataResponse<ShopOptState, IList<Shop>> listResponse)
        {
            if(_getListResponse != null)
            {
                _getListResponse(listResponse);
            }
        }
    }
}
