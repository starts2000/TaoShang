using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using Starts2000.TaobaoPlatform.IDal;

namespace Starts2000.TaobaoPlatform.Dal
{
    public class DbFactory : IDbFactory
    {
        static readonly ConnectionStringSettings _taobaoPlatFormDbSetting =
            ConfigurationManager.ConnectionStrings["TaobaoPlatFormDb"];

        static DbFactory _instance = new DbFactory();

        public static DbFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        public IDbConnection CreateConnection(bool open = true)
        {
            IDbConnection conection = null;

            switch (_taobaoPlatFormDbSetting.ProviderName)
            {
                case "System.Data.SqlClient":
                    conection = new SqlConnection(_taobaoPlatFormDbSetting.ConnectionString);
                    break;
                case "System.Data.SQLite":
                    conection = new SQLiteConnection(_taobaoPlatFormDbSetting.ConnectionString);
                    break;
            }

            if (open)
            {
                conection.Open();
            }

            return conection;
        }
    }
}
