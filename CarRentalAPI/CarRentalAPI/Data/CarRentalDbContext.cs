using CarRentalAPI.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Data;

public class CarRentalDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<User> Users { get; set; }
    public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .Property(c => c.PricePerDay)
            .HasPrecision(10, 2); // 10 cyfr, 2 po przecinku

        modelBuilder.Entity<Car>()
            .HasData(
                new Car
                {
                    Id = 1, Brand = "Skoda", Model = "Fabia", Color = "Czarny", Year = 2019,
                    FuelType = FuelType.Gasoline, PricePerDay = 100, IsAvailable = true
                },
                new Car
                {
                    Id = 2, Brand = "Skoda", Model = "Octavia", Color = "Biały", Year = 2019,
                    FuelType = FuelType.Gasoline, PricePerDay = 150, IsAvailable = false
                },
                new Car
                {
                    Id = 3, Brand = "Skoda", Model = "Superb", Color = "Czarny", Year = 2022,
                    FuelType = FuelType.Gasoline, PricePerDay = 200, IsAvailable = true
                },
                new Car
                {
                    Id = 4, Brand = "Skoda", Model = "Superb", Color = "Biały", Year = 2022, FuelType = FuelType.Hybrid,
                    PricePerDay = 250, IsAvailable = true
                },
                new Car
                {
                    Id = 5, Brand = "Skoda", Model = "Superb", Color = "Biały", Year = 2021, FuelType = FuelType.Diesel,
                    PricePerDay = 200, IsAvailable = true
                },
                new Car
                {
                    Id = 6, Brand = "Polonez", Model = "Caro", Color = "Czarny", Year = 1999,
                    FuelType = FuelType.Gasoline, PricePerDay = 300, IsAvailable = true
                }
            );

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Car)
            .WithMany()
            .HasForeignKey(r => r.CarId);

        modelBuilder.Entity<Rental>()
            .HasData(
                new Rental
                {
                    Id = 1, UserId = 2, CarId = 5, StartDate = new DateTime(2021, 1, 1), EndDate = new DateTime(2021, 1, 3)
                }
            );

        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 1, UserName = "admin", PasswordHash = "admin", Rank = UserRank.Admin
                },
                new User
                {
                    Id = 2, UserName = "user", PasswordHash = "user", Rank = UserRank.User
                }
            );
    }
}