using CarRentalAPI.Data;
using CarRentalAPI.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Services;

public class UserService : IUserService
{
    private readonly CarRentalDbContext _carRentalDbContext;
    
    public UserService(CarRentalDbContext context)
    {
        _carRentalDbContext = context;
    }
    
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        try
        {
            return await _carRentalDbContext.Users.ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving all users: {e.Message}");
        }
    }

    public Task<User> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUserAsync(int id)
    {
        try
        {
            var userToDelete = _carRentalDbContext.Users.Find(id);
            if (userToDelete == null)
            {
                throw new Exception($"User with ID {id} not found");
            }
            _carRentalDbContext.Users.Remove(userToDelete);
            _carRentalDbContext.SaveChanges();
            return Task.FromResult(userToDelete);
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting user with ID {id}: {e.Message}");
        }
    }

    public Task<User> GetUserByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password)
    {
        try
        {
            return await _carRentalDbContext.Users.SingleOrDefaultAsync(u =>
                u.UserName == userName && u.PasswordHash == password);
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving user by username and password: {e.Message}");
        };
    }
}