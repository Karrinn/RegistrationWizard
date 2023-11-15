using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Infrastructure.Database.EntityConfigs
{
    internal class ProvinceEntityConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(x => x.ProvinceId);
            builder
                .Property(x => x.ProvinceId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
