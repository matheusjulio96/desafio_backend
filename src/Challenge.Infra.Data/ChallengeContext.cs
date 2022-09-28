using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Infra.Data
{
    public class ChallengeContext : DbContext
    {
        public DbSet<Domain.ChallengeAggregate.Person> Person { get; set; }
        public DbSet<Domain.ChallengeAggregate.City> City { get; set; }
        public ChallengeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.Entity<Domain.ChallengeAggregate.Person>();
            modelBuilder.Entity<Domain.ChallengeAggregate.City>();
        }
    }

    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ChallengeAggregate.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.ChallengeAggregate.Person> orderConfiguration)
        {
            orderConfiguration.ToTable("Person", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Name).IsRequired();
            orderConfiguration.Property(o => o.Age).IsRequired();
        }
    }

    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ChallengeAggregate.City>
    {
        public void Configure(EntityTypeBuilder<Domain.ChallengeAggregate.City> orderConfiguration)
        {
            orderConfiguration.ToTable("City", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Name).IsRequired();
        }
    }
}
