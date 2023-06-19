using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalAPI.Storage.Models;

public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Brand { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Model { get; set; }
    
    [Required]
    [Range(1900, 2050)]
    public int Year { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Color { get; set; }
    
    [Required]
    public decimal PricePerDay { get; set; }
    
    [Required]
    public FuelType FuelType { get; set; }
    
    [Required]
    public bool IsAvailable { get; set; }
}

public enum FuelType
{
    Gasoline,
    Diesel,
    Electric,
    Hybrid
}