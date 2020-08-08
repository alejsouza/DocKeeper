using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Ranallo.DocKeeper.Configuration;
using Ranallo.DocKeeper.Web;

namespace Ranallo.DocKeeper.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DocKeeperDbContextFactory : IDesignTimeDbContextFactory<DocKeeperDbContext>
    {
        public DocKeeperDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DocKeeperDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DocKeeperDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DocKeeperConsts.ConnectionStringName));

            return new DocKeeperDbContext(builder.Options);
        }
    }
}
