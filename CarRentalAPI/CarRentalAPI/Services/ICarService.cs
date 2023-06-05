using CarRentalAPI.Models;

namespace CarRentalAPI.Services;

public interface ICarService
{
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<Car> GetCarByIdAsync(int id);
    Task<Car> AddCarAsync(Car car); // async ponieważ dodajemy do bazy danych i to może potrwać chwilę (np. 1s) i w tym czasie może być wykonywany inny kod
    Task<Car> UpdateCarAsync(Car car);
    Task<Car> DeleteCarAsync(int id);
    Task<List<Car>> GetAvailableCarsAsync();
}