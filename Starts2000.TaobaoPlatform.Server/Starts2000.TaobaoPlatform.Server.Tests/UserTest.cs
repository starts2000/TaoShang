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
                Account = "Test-1",
                Password = "123456",
                Name = "Test",
                QQ = "888888",
                Email = "test@qq.com",
                Mobile = "13888888888",
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