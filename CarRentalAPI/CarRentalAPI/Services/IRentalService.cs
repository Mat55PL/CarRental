using System.Collections;
using CarRentalAPI.Storage.Models;

namespace CarRentalAPI.Services;

public interface IRentalService
{
    Task<IEnumerable<Rental>> GetAllRentalsAsync();
    Task<Rental> GetRentalByIdAsync(int id);
    Task<Rental> AddRentalAsync(Rental rental);
    Task<Rental> UpdateRentalAsync(Rental rental);
    Task<Rental> DeleteRentalAsync(int id);
    Task<IEnumerable<Rental>> GetRentalByCarIdAsync(int carId);
    Task<IEnumerable<Rental>> GetRentalsByDateRangeAsync(DateTime startDate, DateTime endDate);
}