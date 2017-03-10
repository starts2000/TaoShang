using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IBll
{
    public interface IShopBll
    {
        ShopOptState Add(Shop shop);
        ShopOptState Delete(Shop shop);
        IList<Shop> GetList(int userId, bool isAudit);

        bool HasAuditShop(int userId);

        bool AuditShop(int userId, bool audit);
    }
}
