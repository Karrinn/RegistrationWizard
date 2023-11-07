using Microsoft.EntityFrameworkCore;
using RegistrationWizard.Domain.Entities;
using RegistrationWizard.Infrastructure.Database.EntityConfigs;

namespace RegistrationWizard.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Province> Provinces => Set<Province>();

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceEntityConfiguration());

        }
    }
}
