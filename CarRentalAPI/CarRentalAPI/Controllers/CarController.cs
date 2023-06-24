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
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCarById(int id)
    {
        var car = await _carService.GetCarByIdAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        return car;
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
    
    [HttpDelete]
    [Route("DeleteCar")]
    public async Task<ActionResult<Car>> DeleteCar(int id)
    {
        try
        {
            var carToDelete = await _carService.GetCarByIdAsync(id);
            if (carToDelete == null)
            {
                return NotFound($"Car with ID = {id} not found");
            }
            return await _carService.DeleteCarAsync(id);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
    
    [HttpPost]
    [Route("AddCar")]
    public async Task<ActionResult<Car>> AddCar(Car car)
    {
        try
        {
            if (car == null)
            {
                return BadRequest();
            }
            car.Id = 0; // zabezpieczenie przed podaniem ID przez użytkownika
            var createdCar = await _carService.AddCarAsync(car);
            return CreatedAtAction(nameof(GetCarById), new {id = createdCar.Id}, createdCar);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }
    
    [HttpPut]
    [Route("UpdateCar")]
    public async Task<ActionResult<Car>> UpdateCar(Car car)
    {
        try
        {
            var carToUpdate = await _carService.GetCarByIdAsync(car.Id);
            if (carToUpdate == null)
            {
                return NotFound($"Car with ID = {car.Id} not found");
            }
            return await _carService.UpdateCarAsync(car);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message); // ogólny błąd serwera
        }
    }

}