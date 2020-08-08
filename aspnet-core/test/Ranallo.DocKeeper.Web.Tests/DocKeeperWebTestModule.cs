using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Ranallo.DocKeeper.EntityFrameworkCore;
using Ranallo.DocKeeper.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Ranallo.DocKeeper.Web.Tests
{
    [DependsOn(
        typeof(DocKeeperWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class DocKeeperWebTestModule : AbpModule
    {
        public DocKeeperWebTestModule(DocKeeperEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DocKeeperWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(DocKeeperWebMvcModule).Assembly);
        }
    }
}