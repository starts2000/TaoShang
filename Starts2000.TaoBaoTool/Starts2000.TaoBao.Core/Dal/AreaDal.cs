using System.Collections.Generic;
using System.Linq;
using Dapper;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Dal
{
    class AreaDal : DalBase, IAreaDal
    {
        public IList<Province> GetProvinceList()
        {
            const string sql = @"
                SELECT  [ProvinceID] ,
                        [ProvinceName]
                FROM    [Province]";
            using (var con = DbFactory.CreateConnection())
            {
                var list = con.Query<Province>(sql).ToList();
                list.Insert(0, new Province
                {
                    ProvinceID = -1,
                    ProvinceName = string.Empty
                });
                return list;
            }
        }

        public IList<City> GetCityList(int provinceId)
        {
            const string sql = @"
                SELECT  [CityID] ,
                        [CityName]
                FROM    [City]
                WHERE   ProvinceID = @ProvinceID";
            using (var con = DbFactory.CreateConnection())
            {
                var list = con.Query<City>(sql, new Province
                {
                    ProvinceID = provinceId
                }).ToList();
                list.Insert(0, new City
                {
                    CityID = -1,
                    CityName = string.Empty
                });
                return list;
            }
        }

        public IList<District> GetDistrictList(int cityId)
        {
            const string sql = @"
                SELECT  [DistrictID] ,
                        [DistrictName]
                FROM    [District]
                WHERE   CityID = @CityID";
            using (var con = DbFactory.CreateConnection())
            {
                var list = con.Query<District>(sql, new City
                {
                    CityID = cityId
                }).ToList();
                list.Insert(0, new District
                {
                    DistrictID = -1,
                    DistrictName = string.Empty
                });
                return list;
            }
        }
    }
}