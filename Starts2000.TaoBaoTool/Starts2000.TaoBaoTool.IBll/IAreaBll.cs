using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface IAreaBll
    {
        IList<Province> GetProvinceList();
        IList<City> GetCityList(int provinceId);
        IList<District> GetDistrictList(int cityId);
    }
}
