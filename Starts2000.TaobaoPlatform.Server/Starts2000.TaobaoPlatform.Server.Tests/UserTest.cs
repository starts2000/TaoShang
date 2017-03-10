using Starts2000.TaobaoPlatform.Bll;
using Starts2000.TaobaoPlatform.Core;
using Starts2000.TaobaoPlatform.Dal;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;
using Xunit;

namespace Starts2000.TaobaoPlatform.Server.Tests
{
    public class UserTest
    {
        public UserTest()
        {
            NinjectCommon.Start(bindingRoot =>
            {
                bindingRoot.Bind<IDbFactory>().ToConstant(DbFactory.Instance);
                bindingRoot.Bind<IUserDal>().To<UserDal>();
                bindingRoot.Bind<IUserBll>().To<UserBll>();
            });
        }

        [Fact]
        public void Add()
        {
            var user = new User()
            {
                Account = "Starts2000-1",
                Password = "123456",
                Name = "梁香元",
                QQ = "13929619",
                Email = "Starts2000@qq.com",
                Mobile = "13768235640",
                Salt = "12345",
                ReferrerAccount = "Test"
            };

            var userDal = NinjectCommon.Resolve<IUserDal>();
            //var ret = userDal.Add(user);
            //Assert.True(ret);

            var userBll = NinjectCommon.Resolve<IUserBll>();
            userBll.Register(user);
        }
    }
}