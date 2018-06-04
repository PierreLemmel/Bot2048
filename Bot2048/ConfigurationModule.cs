using Microsoft.Extensions.Configuration;
using Ninject.Modules;
using System;
using System.IO;

namespace Bot2048
{
    internal class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            IConfiguration configuration = configurationBuilder.Build();

            Bind<IConfiguration>().ToConstant(configuration);
        }
    }
}