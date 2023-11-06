using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace C_Web.Extension.DBConn
{
    public class DBConnClass
    {
        public static string GetDBConnString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = builder["appsettingString:ConnectionString"];
            return connectionString;
        }
    }
}
