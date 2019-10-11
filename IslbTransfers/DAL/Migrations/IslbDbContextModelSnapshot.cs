﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(IslbDbContext))]
    partial class IslbDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Models.ExchangeTransaction", b =>
                {
                    b.Property<string>("UniqueId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressTo");

                    b.Property<string>("BlockchainFee");

                    b.Property<string>("Commission");

                    b.Property<string>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("ExternalServiceId");

                    b.Property<string>("GivenAmount");

                    b.Property<string>("Rate");

                    b.Property<string>("ReceivedAmount");

                    b.Property<string>("Status");

                    b.Property<string>("Stock");

                    b.Property<string>("TotalAmount");

                    b.Property<int>("UserId");

                    b.HasKey("UniqueId");

                    b.ToTable("ExchangeTransactions");
                });

            modelBuilder.Entity("Model.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Email");

                    b.Property<string>("EmailVerificationCode");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsEmailVerified");

                    b.Property<bool>("IsExtraLogged");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("ProfilePicture");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.Models.UserExternalLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProviderId");

                    b.Property<string>("ProviderName");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserExternalLogins");
                });

            modelBuilder.Entity("Model.Models.UserIdentityKyc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsConfirmed");

                    b.Property<string>("LastName");

                    b.Property<string>("PassportCode");

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime>("RecordCreatedTime");

                    b.Property<string>("Region");

                    b.Property<int>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserIdentityKycs");
                });

            modelBuilder.Entity("Model.Models.UserSession", b =>
                {
                    b.Property<string>("Token")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpiryDateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("Model.Models.UserWallet", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("BTC");

                    b.Property<string>("ETH");

                    b.HasKey("UserId");

                    b.ToTable("UserWallets");
                });

            modelBuilder.Entity("Model.Models.UserExternalLogin", b =>
                {
                    b.HasOne("Model.Models.User")
                        .WithMany("ExternalLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Models.UserIdentityKyc", b =>
                {
                    b.HasOne("Model.Models.User")
                        .WithMany("IdentityKycs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Models.UserSession", b =>
                {
                    b.HasOne("Model.Models.User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Models.UserWallet", b =>
                {
                    b.HasOne("Model.Models.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
