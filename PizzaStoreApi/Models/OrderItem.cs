using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStoreApi.Models;

public class OrderItem
{
    public int Id { get; set; }
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }
    [ForeignKey(nameof(Pizza))]
    public int PizzaId { get; set; }
    public int Quantity { get; set; }
    public virtual Pizza? Pizza { get; set; }
    public virtual Order? Order { get; set; }
}