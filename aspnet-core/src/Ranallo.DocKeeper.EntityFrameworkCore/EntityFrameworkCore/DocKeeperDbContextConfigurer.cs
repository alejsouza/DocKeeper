using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Ranallo.DocKeeper.EntityFrameworkCore
{
    public static class DocKeeperDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DocKeeperDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DocKeeperDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
