using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;

namespace Umbraco.Web
{
    public class UmbracoConfig : IUmbracoConfig
    {
        public UmbracoConfig(IApplicationEnvironment appEnv)
        {
            var cfg = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("umbraco.json");
            _config = cfg.Build();
        }

        private readonly IConfigurationRoot _config;

        public string Test => _config["test"];
    }
}