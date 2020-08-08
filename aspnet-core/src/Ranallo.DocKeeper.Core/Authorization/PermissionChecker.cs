using Abp.Authorization;
using Ranallo.DocKeeper.Authorization.Roles;
using Ranallo.DocKeeper.Authorization.Users;

namespace Ranallo.DocKeeper.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
