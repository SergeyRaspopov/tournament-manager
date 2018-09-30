﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using trmgr.DAL;

namespace trmgr.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180930170637_Tournament")]
    partial class Tournament
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Affiliation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Affiliations");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<string>("Appartment");

                    b.Property<int?>("CityId");

                    b.Property<int?>("ClubId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("Division");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<int>("Level");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("StreetAddress");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(4,1)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ClubId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.City", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int?>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AffiliationId");

                    b.Property<int?>("CityId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AffiliationId");

                    b.HasIndex("CityId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Country", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Province", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int?>("CountryId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.AgeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("MaxAge");

                    b.Property<byte>("MinAge");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AgeCategories");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.Bracket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgeCategoryId");

                    b.Property<int?>("GenderId");

                    b.Property<bool>("NoGi");

                    b.Property<int?>("TournamentId");

                    b.Property<int?>("WeightClassId");

                    b.HasKey("Id");

                    b.HasIndex("AgeCategoryId");

                    b.HasIndex("GenderId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WeightClassId");

                    b.ToTable("Brackets");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.GenderCategory", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GenderCaegories");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Advantages1");

                    b.Property<byte>("Advantages2");

                    b.Property<int?>("BracketId");

                    b.Property<string>("Competitor1Id");

                    b.Property<string>("Competitor2Id");

                    b.Property<bool>("IsCompetitor1DQed");

                    b.Property<bool>("IsCompetitor2DQed");

                    b.Property<byte>("Penalties1");

                    b.Property<byte>("Penalties2");

                    b.Property<byte>("Score1");

                    b.Property<byte>("Score2");

                    b.Property<int>("SeedNumber");

                    b.Property<int?>("WinnerMatchId");

                    b.HasKey("Id");

                    b.HasIndex("BracketId");

                    b.HasIndex("Competitor1Id");

                    b.HasIndex("Competitor2Id");

                    b.HasIndex("WinnerMatchId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("RegistrationEnd");

                    b.Property<DateTime>("RegistrationStart");

                    b.Property<string>("StreetAddress");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.WeightCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Absolute");

                    b.Property<decimal>("MaxWeight")
                        .HasColumnType("decimal(4,1)");

                    b.Property<decimal>("MinWeight")
                        .HasColumnType("decimal(4,1)");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("WeightCategories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("trmgr.Models.DatabaseModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.ApplicationUser", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("trmgr.Models.DatabaseModels.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.City", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Club", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.Affiliation", "Affiliation")
                        .WithMany()
                        .HasForeignKey("AffiliationId");

                    b.HasOne("trmgr.Models.DatabaseModels.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Province", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.Bracket", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.Tournament.AgeCategory", "AgeCategory")
                        .WithMany()
                        .HasForeignKey("AgeCategoryId");

                    b.HasOne("trmgr.Models.DatabaseModels.Tournament.GenderCategory", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("trmgr.Models.DatabaseModels.Tournament.Tournament")
                        .WithMany("Brackets")
                        .HasForeignKey("TournamentId");

                    b.HasOne("trmgr.Models.DatabaseModels.Tournament.WeightCategory", "WeightClass")
                        .WithMany()
                        .HasForeignKey("WeightClassId");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.Match", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.Tournament.Bracket")
                        .WithMany("Matches")
                        .HasForeignKey("BracketId");

                    b.HasOne("trmgr.Models.DatabaseModels.ApplicationUser", "Competitor1")
                        .WithMany()
                        .HasForeignKey("Competitor1Id");

                    b.HasOne("trmgr.Models.DatabaseModels.ApplicationUser", "Competitor2")
                        .WithMany()
                        .HasForeignKey("Competitor2Id");

                    b.HasOne("trmgr.Models.DatabaseModels.Tournament.Match", "WinnerMatch")
                        .WithMany()
                        .HasForeignKey("WinnerMatchId");
                });

            modelBuilder.Entity("trmgr.Models.DatabaseModels.Tournament.Tournament", b =>
                {
                    b.HasOne("trmgr.Models.DatabaseModels.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}