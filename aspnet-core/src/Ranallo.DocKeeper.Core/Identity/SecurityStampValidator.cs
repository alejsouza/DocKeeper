using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Ranallo.DocKeeper.Authorization.Roles;
using Ranallo.DocKeeper.Authorization.Users;
using Ranallo.DocKeeper.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace Ranallo.DocKeeper.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
