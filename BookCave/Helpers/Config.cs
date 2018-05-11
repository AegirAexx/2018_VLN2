using System;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace BookCave.Helpers
{

    public static class Config
    {
        private static IConfigurationRoot _configurationRoot = null;

        public static IConfigurationRoot Load()
        {
            if (_configurationRoot == null)
            {
                string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                                .AddJsonFile("appsettings.{env}.json", optional:true );
                _configurationRoot = builder.Build();
            }
            return _configurationRoot;
        }
    }

}