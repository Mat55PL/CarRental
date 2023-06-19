using CarRentalAPI.Data;
using CarRentalAPI.Services;
using CarRentalAPI.Storage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    [Route("GetAllCars")]
    public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
    {
        try
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
    
    [HttpGet]
    [Route("GetAvailableCars")]
    public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCars()
    {
        try
        {
            var cars = await _carService.GetAvailableCarsAsync();
            return Ok(cars);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
    
    [HttpGet]
    [Route("GetAvailableCarsByDateRange")]
    public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCarsByDateRange(DateTime startDate, DateTime endDate)
    {
        try
        {
            var cars = await _carService.GetAvailableCarsByDateRangeAsync(startDate, endDate);
            return Ok(cars);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
    
    [HttpGet]
    [Route("GetAvailableCarsByFuelTypeAndDateRange")]
    public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCarsByFuelTypeAndDateRange(FuelType fuelType, DateTime startDate, DateTime endDate)
    {
        try
        {
            var cars = await _carService.GetAvailableCarsByFuelTypeAndDateRangeAsync(fuelType, startDate, endDate);
            return Ok(cars);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
}