using InfraContext.ExternalServices;
using InfraContext.Repositories;
using OrderContext.Commands;
using OrderContext.Commands.Handlers;
using SharedContext.ExternalServices;

var command = new PlaceOrderCommand
{
    Email = "hello@hello.com"
};

var repository = new OrderRepository();
var paymentService = new PaymentService();
var kafkaService = new KafkaEventService();

var handler = new OrderCommandHandler(
    repository,
    paymentService,
    kafkaService);

await handler.HandleAsync(command);