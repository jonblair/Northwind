using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Northwind.Api.Services
{
    public static class ConfigurationService
    {
        public static string GetConfigurationKey(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName].ToString();
        }

        public static string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();
        }
    }
}