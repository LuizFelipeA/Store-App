using OrderContext.Entities;
using OrderContext.Repositories;

namespace InfraContext.Repositories;

public class OrderRepository : IOrderRepository
{
    public async Task<Order> GetOrderAsync(Guid id)
    {
        await Task.Delay(18);
        var user = await GetUserAsync("hello@hello.com");
        
        return new Order(user);
    }

    public async Task<User> GetUserAsync(string email)
    {
        await Task.Delay(12);
        return new User(email);
    }
}
