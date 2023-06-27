using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalAPI.Storage.Models;

public class Rental
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int CarId { get; set; }
    public int? UserId { get; set; }
    [Required]
    [MaxLength(50)]
    public string CustomerFirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string CustomerLastName { get; set; }
    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
}