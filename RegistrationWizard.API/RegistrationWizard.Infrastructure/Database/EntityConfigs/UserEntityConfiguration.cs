using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Infrastructure.Database.EntityConfigs
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);
            builder
                .Property(x => x.UserId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);


            //builder
            //    .HasOne(x => x.Country)
            //    .WithOne()
            //    .HasForeignKey<Country>(x => x.CountryId)
            //    .IsRequired(false);

            //builder
            //    .HasOne(x => x.Province)
            //    .WithOne()
            //    .HasForeignKey<Province>(x => x.ProvinceId)
            //    .IsRequired(false);
        }
    }
}
