using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Ranallo.DocKeeper.Authorization;

namespace Ranallo.DocKeeper
{
    [DependsOn(
        typeof(DocKeeperCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DocKeeperApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DocKeeperAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DocKeeperApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
