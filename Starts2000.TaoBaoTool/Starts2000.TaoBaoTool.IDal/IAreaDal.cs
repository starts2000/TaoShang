using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IDal
{
    internal interface IAreaDal
    {
        IList<Province> GetProvinceList();
        IList<City> GetCityList(int provinceId);
        IList<District> GetDistrictList(int cityId);
    }
}
