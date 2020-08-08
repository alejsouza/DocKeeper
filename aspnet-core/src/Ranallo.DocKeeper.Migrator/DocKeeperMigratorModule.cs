using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Ranallo.DocKeeper.Configuration;
using Ranallo.DocKeeper.EntityFrameworkCore;
using Ranallo.DocKeeper.Migrator.DependencyInjection;

namespace Ranallo.DocKeeper.Migrator
{
    [DependsOn(typeof(DocKeeperEntityFrameworkModule))]
    public class DocKeeperMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public DocKeeperMigratorModule(DocKeeperEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(DocKeeperMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                DocKeeperConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DocKeeperMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
