using Starts2000.TaobaoPlatform.Bll;
using Starts2000.TaobaoPlatform.Core;
using Starts2000.TaobaoPlatform.Dal;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;
using Xunit;

namespace Starts2000.TaobaoPlatform.Server.Tests
{
    public class UserSubAccountTest
    {
        public UserSubAccountTest()
        {
            NinjectCommon.Start(bindingRoot =>
            {
                bindingRoot.Bind<IDbFactory>().ToConstant(DbFactory.Instance);
                bindingRoot.Bind<IUserSubAccountDal>().To<UserSubAccountDal>();
                bindingRoot.Bind<IUserSubAccountBll>().To<UserSubAccountBll>();
            });
        }

        [Fact]
        public void GetPageList()
        {
            var userBll = NinjectCommon.Resolve<IUserSubAccountBll>();
            var data = userBll.GetPageList(1, new PageListQueryInfo<UserSubAccountPageListQuery>
            {
                PageSize = 15,
                PageIndex = 1,
                Query = new UserSubAccountPageListQuery
                {
                    ProvinceName = "北京市",
                    CityName = "",
                    DistrictName = ""
                }
            });

            Assert.True(data.Info.Count > 0);
        }
    }
}