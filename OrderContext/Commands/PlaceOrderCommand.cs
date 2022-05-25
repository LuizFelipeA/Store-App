using SharedContext.Commands;

namespace OrderContext.Commands;

public class PlaceOrderCommand : ICommand
{
    public string Email { get; set; }
}
