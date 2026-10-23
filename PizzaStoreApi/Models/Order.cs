namespace PizzaStoreApi.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public Status Status { get; set; }
    public List<OrderItem> OrderItems { get; set; } = null!;
}

public enum Status
{
    New = 0,
    Pending = 1,
    Ready = 2,
    Delivered = 3
}