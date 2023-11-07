using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Infrastructure.Database.EntityConfigs
{
    internal class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.CountryId);
            builder
                .Property(x => x.CountryId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .HasMany(x => x.Provinces)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId)
                    .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
