using CarRentalAPI.Data;
using CarRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Services;

public class CarService : ICarService
{
    private readonly CarDBContext _carDbContext;
    
    public CarService(CarDBContext context)
    {
        _carDbContext = context;
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        try
        {
            return await _carDbContext.Cars.ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving all cars: {e.Message}");
        }
    }

    public async Task<Car> GetCarByIdAsync(int id)
    {
        try
        {
            return await _carDbContext.Cars.FindAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving car by ID: {e.Message}");
        }
    }

    public async Task<Car> AddCarAsync(Car newCar)
    {
        _carDbContext.Cars.Add(newCar);
        await _carDbContext.SaveChangesAsync();
        return newCar;
    }

    public Task<Car> UpdateCarAsync(Car car)
    {
        throw new NotImplementedException();
    }

    public Task<Car> DeleteCarAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Car>> GetAvailableCarsAsync()
    {
        throw new NotImplementedException();
    }
}