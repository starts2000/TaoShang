using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class UpdateInfoBll : IUpdateInfoBll
    {
        readonly IUpdateInfoDal _updateInfoDal;

        public UpdateInfoBll(IUpdateInfoDal updateInfoDal)
        {
            _updateInfoDal = updateInfoDal;
        }

        public UpdateInfo Get(int clientType)
        {
            return _updateInfoDal.Get(clientType);
        }
    }
}
