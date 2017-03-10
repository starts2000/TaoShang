using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Starts2000.TaobaoPlatform.Manager.Dal;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager.Server
{
    public class ManagerController : ApiController
    {
        readonly UserDal _user = new UserDal();
        readonly ShopDal _shop = new ShopDal();
        readonly HangUpTimeDal _hangupTime = new HangUpTimeDal();
        readonly UserSubAccountDal _subAccount = new UserSubAccountDal();

        [HttpGet]
        [Route("user/list/{pageIndex:int}/{pageSize:int}/{account?}")]
        public Tuple<int, IList<User>> GetUsers(int pageIndex, int pageSize, string account = null)
        {
            int total;
            var users = _user.GetList(account, pageIndex, pageSize, out total);
            return new Tuple<int, IList<User>>(total, users);
        }

        [HttpGet]
        [Route("shop/list/{userId:int}")]
        public IList<Shop> GetShops(int userId)
        {
            return _shop.GetList(userId);
        }

        [HttpGet]
        [Route("subaccount/list/{userId:int}")]
        public IList<UserSubAccount> GetSubAccounts(int userId)
        {
            return _subAccount.GetList(userId);
        }

        [HttpPost]
        [Route("user/audit")]
        public bool UserAudit(User user)
        {
            return _user.Audit(user.Id, user.IsAudit, user.Lock, user.ExpireDate);
        }

        [HttpPost]
        [Route("user/addgold")]
        public bool UserAddGold(JObject data)
        {
            return _user.UpdateGold((int)data["UserId"], (int)data["Gold"]);
        }

        [HttpPost]
        [Route("user/resetpwd")]
        public bool ResetPassword(JObject data)
        {
            return _user.ChangePassword((int)data["UserId"], (string)data["Password"], (string)data["Salt"]);
        }

        [HttpPost]
        [Route("shop/audit")]
        public bool ShopAudit(Shop shop)
        {
            return _shop.Audit(shop.Id, shop.Audit);
        }

        [HttpPost]
        [Route("shop/update")]
        public bool UpdateShop(Shop shop)
        {
            return _shop.Update(shop);
        }

        [HttpPost]
        [Route("shop/delete")]
        public bool DeleteShop(JObject data)
        {
            return _shop.Delete((int)data["ShopId"]);
        }

        [HttpPost]
        [Route("subaccount/audit")]
        public bool SubAccountAudit(UserSubAccount subAccount)
        {
            return _subAccount.Audit(subAccount.Id, subAccount.IsAudit);
        }

        [HttpPost]
        [Route("subaccount/delete")]
        public bool DeleteSubAccount(JObject data)
        {
            return _subAccount.Delete((int)data["SubAccountId"]);
        }

        [HttpPost]
        [Route("hangupTime/add")]
        public bool AddHangupTime(JObject data)
        {
            return _hangupTime.Insert((int)data["UserId"], (int)data["Minutes"]);
        }
    } 
}
