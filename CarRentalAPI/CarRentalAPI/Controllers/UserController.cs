using CarRentalAPI.Services;
using CarRentalAPI.Storage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
    //GetUserByUserNameAndPasswordAsync
    [HttpGet]
    [Route("GetUserByUserNameAndPasswordAsync")]
    public async Task<ActionResult<User>> GetUserByUserNameAndPasswordAsync(string userName, string password)
    {
        try
        {
            var user = await _userService.GetUserByUserNameAndPasswordAsync(userName, password);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
    
}