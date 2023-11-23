using Microsoft.Extensions.Configuration;
using System.IO;

namespace Cross
{
    public class AppSettings
    {
        private static AppSettings? _appSettings;
        public string? _appSettingValue { get; set; }

        public AppSettings(IConfiguration config, string Key)
        {
            this._appSettingValue = config.GetValue<string>(Key);
        }
        public static string? GetConnectionString(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();

            return configuration.GetConnectionString(key);
        }
    }
}
