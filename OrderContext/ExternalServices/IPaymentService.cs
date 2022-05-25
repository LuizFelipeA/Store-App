using OrderContext.Entities;
using OrderContext.ValueObjects;

namespace OrderContext.ExternalServices;

public interface IPaymentService
{
    Task<Transaction> PayAsync(CreditCard creditCard);
}
