using PizzaStoreApi.DTOs;
using PizzaStoreApi.Models;

namespace PizzaStoreApi.Services;

public interface IPizzaService
{
    public Task<List<OrderResponseDto>> GetOrders();
    public Task<OrderResponseDto> CreateOrder(CreateOrderDto createOrderDto);
}