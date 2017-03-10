using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace Starts2000.SmartUpdate.Server.Dal
{
    class DbFactory
    {
        static readonly string _configDbSetting = string.Format(
            @"Data Source={0}\DataBase\UpdateDb.db;Version=3;Pooling=True;Max Pool Size=100;",
            AppDomain.CurrentDomain.BaseDirectory);

        public static IDbConnection CreateConnection(bool open = true)
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