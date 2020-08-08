using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Ranallo.DocKeeper.Configuration;

namespace Ranallo.DocKeeper.Web.Host.Startup
{
    [DependsOn(
       typeof(DocKeeperWebCoreModule))]
    public class DocKeeperWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DocKeeperWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DocKeeperWebHostModule).GetAssembly());
        }
    }
}
