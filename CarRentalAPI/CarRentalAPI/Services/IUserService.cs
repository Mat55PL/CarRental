using CarRentalAPI.Storage.Models;

namespace CarRentalAPI.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<User> AddUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<User> DeleteUserAsync(int id);
    Task<User> GetUserByUserNameAsync(string userName);
    Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password);
}