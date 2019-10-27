using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddSheepServiceTest
{
    public static class TestHelper
    {
        private static IConfiguration configurationRoot;
        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables();
            configurationRoot = builder.Build();

            return configurationRoot;
        }
    }
}
