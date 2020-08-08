using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Ranallo.DocKeeper.Controllers
{
    public abstract class DocKeeperControllerBase: AbpController
    {
        protected DocKeeperControllerBase()
        {
            LocalizationSourceName = DocKeeperConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
