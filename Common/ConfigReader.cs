using Microsoft.Extensions.Configuration;
using System.IO;

namespace Business
{
    public class ConfigReader
    {
        public static string GetAppSettingValue(string key)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            IConfiguration Configuration = root;
            string strValue = Configuration.GetValue<string>(key);
            return strValue;
        }
    }
}
