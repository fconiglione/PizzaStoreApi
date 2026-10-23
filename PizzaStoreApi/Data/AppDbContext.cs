using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PizzaStoreApi.Models;

namespace PizzaStoreApi.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pizza>().HasData(
            new Pizza { Id = 1, Name = "Margherita", IsAvailable = true, Price = 15.99},
            new Pizza { Id = 2, Name = "Pepperoni", IsAvailable = true, Price = 17.99},
            new Pizza { Id = 3, Name = "BBQ Chicken", IsAvailable = true, Price = 18.99}
        );
    }
}