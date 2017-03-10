using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IDal
{
    public interface IShopDal
    {
        bool Add(Shop shop);
        bool Delete(Shop shop);

        IList<Shop> GetList(int userId, bool isAudit);

        int AuditShopCount(int userId);

        bool AuditShop(int userId, bool audit);
    }
}
