using Ninject;
using Starts2000.TaobaoPlatform.IDal;

namespace Starts2000.TaobaoPlatform.Dal
{
    public abstract class DalBase
    {
        [Inject]
        public IDbFactory DbFactory { get; set; }

        protected DalBase()
        {
        }
    }
}