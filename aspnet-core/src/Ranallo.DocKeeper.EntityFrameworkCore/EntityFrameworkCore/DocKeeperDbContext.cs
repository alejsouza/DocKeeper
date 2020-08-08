using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Ranallo.DocKeeper.Authorization.Roles;
using Ranallo.DocKeeper.Authorization.Users;
using Ranallo.DocKeeper.MultiTenancy;
using Ranallo.DocKeeper.Documents;

namespace Ranallo.DocKeeper.EntityFrameworkCore
{
    public class DocKeeperDbContext : AbpZeroDbContext<Tenant, Role, User, DocKeeperDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Document> Documents { get; set; }

        public DocKeeperDbContext(DbContextOptions<DocKeeperDbContext> options)
            : base(options)
        {
        }
    }
}
