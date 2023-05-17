using CarRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Data;

public class CarDBContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    
    public CarDBContext(DbContextOptions<CarDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarRentalDB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasData(
                new Car { Id = 1, Brand = "Skoda", Model = "Fabia", Color = "Czarny", Year = 2019, FuelType = FuelType.Gasoline, PricePerDay = 100, IsAvailable = true },
                new Car { Id = 2, Brand = "Skoda", Model = "Octavia", Color = "Biały", Year = 2019, FuelType = FuelType.Gasoline, PricePerDay = 150, IsAvailable = true },
                new Car { Id = 3, Brand = "Skoda", Model = "Superb", Color = "Czarny", Year = 2022, FuelType = FuelType.Gasoline, PricePerDay = 200, IsAvailable = true },
                new Car { Id = 4, Brand = "Skoda", Model = "Superb", Color = "Biały", Year = 2022, FuelType = FuelType.Hybrid, PricePerDay = 250, IsAvailable = true },
                new Car { Id = 5, Brand = "Skoda", Model = "Superb", Color = "Biały", Year = 2021, FuelType = FuelType.Diesel, PricePerDay = 200, IsAvailable = true }
            );
    }
}