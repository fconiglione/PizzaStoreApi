using Microsoft.AspNetCore.Mvc;
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
}