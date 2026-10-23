using System.ComponentModel.DataAnnotations;
using PizzaStoreApi.Models;

namespace PizzaStoreApi.DTOs;

public class CreateOrderDto
{
    [Required]
    [MaxLength(100)]
    public string CustomerName { get; set; } = null!;
    [Required]
    public List<OrderItem> OrderItems { get; set; } = null!;
}