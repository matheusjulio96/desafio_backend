using Challenge.Domain.ChallengeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Challenge.Infra.Data
{
    public class ChallengeContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<City> City { get; set; }
        public ChallengeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<City>();
        }
    }

    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> orderConfiguration)
        {
            orderConfiguration.ToTable("Person", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Name).IsRequired().HasMaxLength(300);
            orderConfiguration.Property(o => o.Age).IsRequired();
            orderConfiguration.Property(o => o.Document).HasMaxLength(11);
            orderConfiguration.HasOne<City>().WithMany().HasForeignKey(p => p.CityId);
        }
    }

    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> orderConfiguration)
        {
            orderConfiguration.ToTable("City", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Name).IsRequired().HasMaxLength(200);
            orderConfiguration.Property(o => o.Uf).IsRequired().HasMaxLength(2);
        }
    }
}
