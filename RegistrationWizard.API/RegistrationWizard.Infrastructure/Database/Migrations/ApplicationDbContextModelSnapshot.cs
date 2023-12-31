﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistrationWizard.Infrastructure.Database;

#nullable disable

namespace RegistrationWizard.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("RegistrationWizard.Domain.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("RegistrationWizard.Domain.Entities.Province", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("ProvinceId");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("RegistrationWizard.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RegistrationWizard.Domain.Entities.Province", b =>
                {
                    b.HasOne("RegistrationWizard.Domain.Entities.Country", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RegistrationWizard.Domain.Entities.User", b =>
                {
                    b.HasOne("RegistrationWizard.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("RegistrationWizard.Domain.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");

                    b.Navigation("Country");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("RegistrationWizard.Domain.Entities.Country", b =>
                {
                    b.Navigation("Provinces");
                });
#pragma warning restore 612, 618
        }
    }
}
