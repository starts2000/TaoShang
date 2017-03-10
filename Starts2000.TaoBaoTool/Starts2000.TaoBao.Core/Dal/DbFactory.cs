using System.Data;
using System.Data.SQLite;
using Starts2000.TaoBao.Core.Resource;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Dal
{
    class DbFactory : IDbFactory
    {
        static readonly string _configDbSetting = Resources.ConfigDbConnectionString;

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
            IDbConnection conection = new SQLiteConnection(_configDbSetting);

            if (open)
            {
                conection.Open();
            }

            return conection;
        }
    }
}
