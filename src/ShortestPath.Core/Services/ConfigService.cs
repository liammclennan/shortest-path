using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ShortestPath.Core.Services
{
    public interface IConfigService
    {
        string GoogleMapsAPIKey();
    }

    public class ConfigService : IConfigService
    {
        public string GoogleMapsAPIKey()
        {
            var appSettingKey = "GoogleMapsAPIKey";
            CheckForKey(appSettingKey);
            return ConfigurationManager.AppSettings[appSettingKey];
        }

        private void CheckForKey(string appSettingKey)
        {
            if (ConfigurationManager.AppSettings[appSettingKey] == null 
                || ConfigurationManager.AppSettings[appSettingKey].Equals(string.Empty))
            {
                throw new Exception("Missing appsetting: " + appSettingKey);
            }
        }
    }
}
