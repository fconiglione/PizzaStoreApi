using System.ComponentModel.DataAnnotations;
using PizzaStoreApi.Models;

namespace PizzaStoreApi.DTOs;

public class OrderResponseDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public Status Status { get; set; }
    public List<OrderItem> OrderItems { get; set; } = null!;
}