using Microsoft.EntityFrameworkCore;
using RegistrationWizard.Entities;

namespace RegistrationWizard.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Country> Country { get; set; } = null!;
        public DbSet<Province> Province { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
        }
    }
}
