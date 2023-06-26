﻿// <auto-generated />
using System;
using CarRentalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentalAPI.Migrations
{
    [DbContext(typeof(CarRentalDbContext))]
    partial class CarRentalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRentalAPI.Storage.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PricePerDay")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Skoda",
                            Color = "Czarny",
                            FuelType = 0,
                            IsAvailable = true,
                            Model = "Fabia",
                            PricePerDay = 100m,
                            Year = 2019
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Skoda",
                            Color = "Biały",
                            FuelType = 0,
                            IsAvailable = false,
                            Model = "Octavia",
                            PricePerDay = 150m,
                            Year = 2019
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Skoda",
                            Color = "Czarny",
                            FuelType = 0,
                            IsAvailable = true,
                            Model = "Superb",
                            PricePerDay = 200m,
                            Year = 2022
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Skoda",
                            Color = "Biały",
                            FuelType = 3,
                            IsAvailable = true,
                            Model = "Superb",
                            PricePerDay = 250m,
                            Year = 2022
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Skoda",
                            Color = "Biały",
                            FuelType = 1,
                            IsAvailable = true,
                            Model = "Superb",
                            PricePerDay = 200m,
                            Year = 2021
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Polonez",
                            Color = "Czarny",
                            FuelType = 0,
                            IsAvailable = true,
                            Model = "Caro",
                            PricePerDay = 300m,
                            Year = 1999
                        });
                });

            modelBuilder.Entity("CarRentalAPI.Storage.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rentals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 5,
                            CustomerEmail = "test@gmail.com",
                            CustomerFirstName = "Test",
                            CustomerLastName = "Testowy",
                            EndDate = new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("CarRentalAPI.Storage.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "admin",
                            Rank = 1,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = "user",
                            Rank = 2,
                            UserName = "user"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
