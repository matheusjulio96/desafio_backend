using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Challenge.Infra.Data
{
    internal class ChallengeContextFactory : IDesignTimeDbContextFactory<ChallengeContext>
    {
        public ChallengeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChallengeContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ChallengeDb;Trusted_Connection=True;");

            return new ChallengeContext(optionsBuilder.Options);
        }
    }
}
