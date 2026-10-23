using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            .ThenInclude(orderItems => orderItems.Pizza)
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

    public async Task<OrderResponseDto> CreateOrder(CreateOrderDto createOrderDto)
    {
        if (createOrderDto.OrderItems == null || !createOrderDto.OrderItems.Any()) return null;
        if (string.IsNullOrWhiteSpace(createOrderDto.CustomerName)) return null;

        var orderItems = await _context.OrderItems
            .Include(orderItems => orderItems.Pizza)
            .ToListAsync();
        
        var newOrder = new Order()
            { 
                CustomerName = createOrderDto.CustomerName, 
                OrderDate = DateTime.UtcNow, 
                Status = Status.New, 
                OrderItems = orderItems
            };

        _context.Orders.Add(newOrder);
        await _context.SaveChangesAsync();

        return new OrderResponseDto()
        {
            Id = newOrder.Id,
            CustomerName = newOrder.CustomerName,
            OrderDate = newOrder.OrderDate,
            OrderItems = orderItems,
            Status = newOrder.Status
        };
    }
}