using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Bll
{
    class UpdateInfoBll : IUpdateInfoBll
    {
        readonly IUpdateInfoDal _updateInfoDal;

        public UpdateInfoBll(IUpdateInfoDal updateInfoDal)
        {
            _updateInfoDal = updateInfoDal;
        }

        public UpdateInfo Get()
        {
            return _updateInfoDal.Get();
        }
    }
}
