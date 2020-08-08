using Abp.MultiTenancy;
using Ranallo.DocKeeper.Authorization.Users;

namespace Ranallo.DocKeeper.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
