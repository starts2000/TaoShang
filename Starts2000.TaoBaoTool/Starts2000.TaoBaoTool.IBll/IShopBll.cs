using System;
using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface IShopBll
    {
        void Add(Shop shop, Action<ShopOptState> addResponse);

        void Delete(Shop shop, Action<ShopOptState> deleteResponse);

        void GetList(bool isAudit, Action<DataResponse<ShopOptState, IList<Shop>>> getListResponse);

        void AddResponse(ShopOptState state);

        void DeleteResponse(ShopOptState state);

        void GetListResponse(DataResponse<ShopOptState, IList<Shop>> listResponse);
    }
}