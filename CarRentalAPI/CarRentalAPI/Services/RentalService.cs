using CarRentalAPI.Data;
using CarRentalAPI.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Services;

public class RentalService : IRentalService
{
    private readonly CarRentalDbContext _carRentalDbContext;
    
    public RentalService(CarRentalDbContext carRentalDbContext)
    {
        _carRentalDbContext = carRentalDbContext;
    }
    
    public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
    {
        try
        {
            return await _carRentalDbContext.Rentals.ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving all rentals: {e.Message}");
        }
    }

    public async Task<Rental> GetRentalByIdAsync(int id)
    {
        try
        {
            return await _carRentalDbContext.Rentals.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"An error occurred while retrieving rental by ID {id} {e.Message}");
        }
    }

    public async Task<Rental> AddRentalAsync(Rental rental)
    {
        try
        {
            _carRentalDbContext.Rentals.Add(rental);
            await _carRentalDbContext.SaveChangesAsync();
            return await Task.FromResult(rental);
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while adding a new rental: ${e.Message}");
        }
    }

    public Task<Rental> UpdateRentalAsync(Rental rental)
    {
        throw new NotImplementedException();
    }

    public Task<Rental> DeleteRentalAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Rental>> GetRentalByCarIdAsync(int carId)
    {
        try
        {
            return await _carRentalDbContext.Rentals
                .Include(r => r.Car)
                .Where(r => r.CarId == carId)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"An error occurred while retrieving rental by car ID {carId}" + $" | {e.Message}");
        }
    }

    public async Task<IEnumerable<Rental>> GetRentalsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            return await _carRentalDbContext.Rentals
                .Include(r => r.Car)
                .Where(r => r.StartDate >= startDate && r.EndDate <= endDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"An error occurred while retrieving rentals by date range {startDate} - {endDate}" + $" | {e.Message}");
        }
    }
}