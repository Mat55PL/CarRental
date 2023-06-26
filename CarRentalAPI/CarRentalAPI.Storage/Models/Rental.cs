namespace CarRentalAPI.Storage.Models;

public class Rental
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int? UserId { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}