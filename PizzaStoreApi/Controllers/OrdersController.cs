using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzaStoreApi.DTOs;
using PizzaStoreApi.Services;

namespace PizzaStoreApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IPizzaService _pizzaService;

    public OrdersController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var result = await _pizzaService.GetOrders();

        if (result is null) BadRequest();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
    {
        if (createOrderDto.OrderItems.IsNullOrEmpty()) return BadRequest("OrderItems are required.");
        
        if (String.IsNullOrWhiteSpace(createOrderDto.CustomerName)) return BadRequest("CustomerName is required.");
        
        var result = _pizzaService.CreateOrder(createOrderDto);
        
        if (result is null) BadRequest();

        return Created($"api/v1/orders/{result.Id}",result);
    }
}