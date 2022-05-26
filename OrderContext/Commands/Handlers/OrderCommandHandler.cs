using OrderContext.Entities;
using OrderContext.Events;
using OrderContext.ExternalServices;
using OrderContext.Repositories;
using OrderContext.ValueObjects;
using SharedContext.Commands.Handlers;
using SharedContext.ExternalServices;

namespace OrderContext.Commands.Handlers;

public class OrderCommandHandler : 
    ICommandHandler<PlaceOrderCommand>,
    ICommandHandler<PayOrderCommand>
{
    private readonly IOrderRepository _repository;

    private readonly IPaymentService _paymentService;

    private readonly IEventService _eventService;

    public OrderCommandHandler(
        IOrderRepository repository,
        IPaymentService paymentService,
        IEventService eventService
    )
    {
        _repository = repository;
        _paymentService = paymentService;
        _eventService = eventService;
    }

    public async Task HandleAsync(PlaceOrderCommand command)
    {
        // Make sure to implement fail fast validation

        var user = await _repository.GetUserAsync(command.Email);

        if(user is null)
            return; // Return fail notification

        var order = new Order(user);
        order.OnOrderPlaced += OnOrderPlaced; // Delegating event

        order.Place();

        // Return success notification
    }

    public async Task HandleAsync(PayOrderCommand command)
    {
        // Make sure to implement fail fast validation

        var order = await _repository.GetOrderAsync(command.Id);
        order.OnOrderPaid += OnOrderPaid;

        var creditCard = new CreditCard
        {
            Name = command.Name,
            Number = command.Number,
            Expiration = command.Expiration,
            Cvv = command.Cvv
        };

        var transaction = await _paymentService.PayAsync(creditCard);

        order.Pay(transaction);
    }

    private void OnOrderPlaced(object sender, EventArgs e)
        => _eventService.Queue(new OrderCreatedEvent((Order) sender));

    private void OnOrderPaid(object sender, EventArgs e)
        => _eventService.Queue(new OrderPaidEvent((Order) sender));
}
