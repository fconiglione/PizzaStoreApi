namespace PizzaStoreApi.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int PizzaId { get; set; }
    public int Quantity { get; set; }
    public Pizza Pizza { get; set; } = null!;
}