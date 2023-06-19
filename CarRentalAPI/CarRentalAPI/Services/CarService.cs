using CarRentalAPI.Data;
using CarRentalAPI.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Services;

public class CarService : ICarService
{
    private readonly CarRentalDbContext _carRentalDbContext;

    public CarService(CarRentalDbContext context)
    {
        _carRentalDbContext = context;
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        try
        {
            return await _carRentalDbContext.Cars.ToListAsync();
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
            return await _carRentalDbContext.Cars.FindAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving car by ID: {e.Message}");
        }
    }

    public async Task<Car> AddCarAsync(Car newCar)
    {
        try
        {
            _carRentalDbContext.Cars.Add(newCar);
            await _carRentalDbContext.SaveChangesAsync();
            return newCar;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while adding a new car: {0}", e.Message);
            throw;
        }
    }

    public Task<Car> UpdateCarAsync(Car car)
    {
        throw new NotImplementedException();
    }

    public Task<Car> DeleteCarAsync(int id)
    {
        try
        {
            var carToDelete = _carRentalDbContext.Cars.Find(id);
            if (carToDelete == null)
            {
                throw new Exception($"Car with ID[{id}] not found");
            }

            _carRentalDbContext.Cars.Remove(carToDelete);
            _carRentalDbContext.SaveChanges();
            return Task.FromResult(carToDelete);
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting car with ID {id}: {e.Message}");
        }
    }

    public Task<List<Car>> GetAvailableCarsAsync()
    {
        try
        {
            return _carRentalDbContext.Cars.Where(c => c.IsAvailable).ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving available cars: {e.Message}");
        }
    }
    
    public async Task<List<Car>> GetAvailableCarsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            return await _carRentalDbContext.Cars
                .Where(car => car.IsAvailable &&
                              !_carRentalDbContext.Rentals.Any(rental => rental.CarId == car.Id &&
                                                                         rental.StartDate <= endDate &&
                                                                         rental.EndDate >= startDate))
                .ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving available cars by date range: {e.Message}");
        }
    }

    public async Task<IEnumerable<Car>> GetAvailableCarsByFuelTypeAndDateRangeAsync(FuelType fuelTypeInt, DateTime startDate, DateTime endDate)
    {
        FuelType fuelType = (FuelType) Enum.ToObject(typeof(FuelType), fuelTypeInt); // konwersja int na enum
        return await _carRentalDbContext.Cars
            .Where(car => car.FuelType == fuelType &&
                          !_carRentalDbContext.Rentals.Any(rental => rental.CarId == car.Id &&
                                                                     rental.StartDate <= endDate &&
                                                                     rental.EndDate >= startDate))
            .ToListAsync();
    }
}