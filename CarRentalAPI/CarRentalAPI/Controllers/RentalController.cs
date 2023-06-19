using CarRentalAPI.Services;
using CarRentalAPI.Storage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RentalController : ControllerBase
{
    private readonly IRentalService _rentalService;
    
    public RentalController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }
    
    [HttpGet]
    [Route("GetAllRentals")]
    public async Task<ActionResult<IEnumerable<Rental>>> GetAllRentals()
    {
        try
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return Ok(rentals);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
}