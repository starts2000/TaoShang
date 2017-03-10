using Ninject;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Dal
{
    internal abstract class DalBase
    {
        [Inject]
        public IDbFactory DbFactory { get; set; }

        protected DalBase()
        {
        }
    }
}
