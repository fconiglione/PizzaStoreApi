namespace PizzaStoreApi.Models;

public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public bool IsAvailable { get; set; }
}