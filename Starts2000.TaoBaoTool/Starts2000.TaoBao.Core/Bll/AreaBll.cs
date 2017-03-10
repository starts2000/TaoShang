using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Bll
{
    class AreaBll : IAreaBll
    {
        readonly IAreaDal _areaDal;

        public AreaBll(IAreaDal areaDal)
        {
            _areaDal = areaDal;
        }

        #region IAreaBll 成员

        public IList<Province> GetProvinceList()
        {
            return _areaDal.GetProvinceList();
        }

        public IList<City> GetCityList(int provinceId)
        {
            return _areaDal.GetCityList(provinceId);
        }

        public IList<District> GetDistrictList(int cityId)
        {
            return _areaDal.GetDistrictList(cityId);
        }

        #endregion
    }
}
