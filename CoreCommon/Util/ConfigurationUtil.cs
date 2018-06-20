using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoreCommon.Util
{
    public static class ConfigurationUtil
    {
        public static IConfiguration DefaultConfig { get; set; }

        private static Dictionary<String, IConfiguration> ConfigurationDic { get; set; }

        public static T GetAppSettings<T>(String key)
        {
            T resultT = default(T);
            if (!String.IsNullOrEmpty(key))
            {
                int splitIndex = key.LastIndexOf('.');
                String configName = key;
                IConfiguration fileConfig = DefaultConfig;
                if (splitIndex > 0)
                {
                    String fileName = key.Substring(0, splitIndex);
                    configName = key.Substring(splitIndex+1);
                    fileConfig = ConfigurationDic.GetValueOrDefault(fileName, null);
                }
                if (fileConfig != null)
                {
                    IConfigurationSection configurationSection = fileConfig.GetSection(configName);
                    if (configurationSection != null)
                    {
                        resultT = Convert<T>(configurationSection.Value);
                    }
                }
            }
            return resultT;
        }

        public static String GetAppSettings(String key)
        {
            return GetAppSettings<String>(key);
        }

        public static void AddConfiguration(String pattern, String fileLocation)
        {
            if (ConfigurationDic == null)
            {
                ConfigurationDic = new Dictionary<string, IConfiguration>();
            }
            if (!String.IsNullOrEmpty(pattern) && !String.IsNullOrEmpty(fileLocation))
            {
                if (!ConfigurationDic.ContainsKey(pattern))
                {
                    IConfiguration Configuration = new ConfigurationBuilder()
                        .Add(new JsonConfigurationSource { Path = fileLocation, ReloadOnChange = true })
                        .Build();
                    ConfigurationDic.Add(pattern, Configuration);
                }
            }
        }

        private static T Convert<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(input);
                }
                return default(T);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }
    }
}
