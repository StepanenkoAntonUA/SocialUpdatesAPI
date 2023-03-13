using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Common.Configuration
{
    public class AppConfigurationBuilder
    {
        public IConfiguration Build()
        {
        var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            return builder;
        }
    }
}