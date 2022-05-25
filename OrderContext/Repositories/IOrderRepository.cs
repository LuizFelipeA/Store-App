using OrderContext.Entities;

namespace OrderContext.Repositories;

public interface IOrderRepository
{
    Task<User> GetUserAsync(string email);

    Task<Order> GetOrderAsync(Guid id);
}
