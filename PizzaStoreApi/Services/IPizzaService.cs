using PizzaStoreApi.DTOs;

namespace PizzaStoreApi.Services;

public interface IPizzaService
{
    public Task<List<OrderResponseDto>> GetOrders();
}