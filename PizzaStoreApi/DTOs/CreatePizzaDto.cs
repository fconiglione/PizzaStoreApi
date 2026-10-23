using System.ComponentModel.DataAnnotations;

namespace PizzaStoreApi.DTOs;

public class CreatePizzaDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [Required]
    public double Price { get; set; }
    [Required]
    public bool IsAvailable { get; set; }
}