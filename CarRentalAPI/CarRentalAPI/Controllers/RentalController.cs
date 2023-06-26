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
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Rental>> GetRentalById(int id)
    {
        var rental = await _rentalService.GetRentalByIdAsync(id);

        if (rental == null)
        {
            return NotFound();
        }

        return rental;
    }
    
    [HttpPost]
    [Route("AddRental")]
    public async Task<ActionResult<Rental>> AddRental(Rental rental)
    {
        try
        {
            if (rental == null)
            {
                return BadRequest();
            }
            rental.Id = 0; // zabezpieczenie przed podaniem ID przez użytkownika
            var createdRental = await _rentalService.AddRentalAsync(rental);
            return CreatedAtAction(nameof(GetRentalById), new {id = createdRental.Id}, createdRental);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}