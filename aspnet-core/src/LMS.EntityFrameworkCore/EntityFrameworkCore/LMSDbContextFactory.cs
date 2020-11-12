using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LMS.Configuration;
using LMS.Web;

namespace LMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LMSDbContextFactory : IDesignTimeDbContextFactory<LMSDbContext>
    {
        public LMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LMSConsts.ConnectionStringName));

            return new LMSDbContext(builder.Options);
        }
    }
}
