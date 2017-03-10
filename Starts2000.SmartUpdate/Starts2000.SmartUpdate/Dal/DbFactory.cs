using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Starts2000.SmartUpdate.Dal
{
    class DbFactory
    {
        static readonly string _configDbSetting = string.Format(
            @"Data Source={0}\Data\Config.db;Version=3;Pooling=True;Max Pool Size=100;",
            new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName);

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