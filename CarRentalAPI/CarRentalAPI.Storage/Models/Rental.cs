namespace CarRentalAPI.Storage.Models;

public class Rental
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}