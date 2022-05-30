using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryWebApp.Utils
{
    public static class AppSettings
    {
        public static string SiteName { get { return GetValue<string>("SiteName"); } }

        public static string Salt { get { return GetValue<string>("Salt"); } }

        public static string ConnectionString { get { return System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseCon"].ConnectionString; } }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ObjType"></typeparam>
        /// <param name="configKey"></param>
        /// <returns></returns>
        private static ObjType GetValue<ObjType>(string configKey)
        {
            var configValue = System.Configuration.ConfigurationManager.AppSettings.Get(configKey);

            return (ObjType) Convert.ChangeType(configValue, typeof(ObjType));
        }
    }
}