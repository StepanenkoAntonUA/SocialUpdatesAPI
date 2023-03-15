using Microsoft.Extensions.Configuration;

namespace Common.Configuration
{
    public class AppConfigurationBuilder
    {
        public IConfiguration Build()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
               .Build();

            return builder;
        }
    }
}