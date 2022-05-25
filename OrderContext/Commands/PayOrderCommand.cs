using SharedContext.Commands;

namespace OrderContext.Commands;

public class PayOrderCommand : ICommand
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Number { get; set; }

    public string Expiration { get; set; }

    public string Cvv { get; set; }
}
