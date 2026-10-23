using Microsoft.EntityFrameworkCore;
using PizzaStoreApi.Controllers;
using PizzaStoreApi.Data;
using PizzaStoreApi.DTOs;
using PizzaStoreApi.Models;

namespace PizzaStoreApi.Services;

public class PizzaService: IPizzaService
{
    private readonly AppDbContext _context;
    public PizzaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderResponseDto>> GetOrders()
    {
        var orders = await _context.Orders
            .AsNoTracking()
            .Include(orders => orders.OrderItems)
            .Select(order => new OrderResponseDto{
                Id = order.Id,
                CustomerName = order.CustomerName,
                OrderDate = order.OrderDate,
                Status = order.Status,
                OrderItems = order.OrderItems
            })
            .ToListAsync();
        
        return orders;
    }
}