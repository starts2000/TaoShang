using System.Collections.Generic;
using Ninject;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class ShopBll : IShopBll
    {
        readonly IShopDal _shopDal;

        [Inject]
        public ShopBll(IShopDal shopDal)
        {
            _shopDal = shopDal;
        }

        #region IShopBll 成员

        public ShopOptState Add(Shop shop)
        {
            return _shopDal.Add(shop) ?
                ShopOptState.Successed : ShopOptState.Failed;
        }

        public ShopOptState Delete(Shop shop)
        {
            return _shopDal.Delete(shop) ? 
                ShopOptState.Successed : ShopOptState.Failed;
        }

        public IList<Shop> GetList(int userId, bool isAudit)
        {
            return _shopDal.GetList(userId, isAudit);
        }

        public bool HasAuditShop(int userId)
        {
            return _shopDal.AuditShopCount(userId) > 0;
        }

        public bool AuditShop(int userId, bool audit)
        {
            return _shopDal.AuditShop(userId, audit);
        }

        #endregion
    }
}