using OrderContext.Entities;
using OrderContext.ExternalServices;
using OrderContext.ValueObjects;

namespace InfraContext.ExternalServices;

public class PaymentService : IPaymentService
{
    public async Task<Transaction> PayAsync(CreditCard creditCard)
    {
        await Task.Delay(5);
        
        return new Transaction(new CreditCard
        {
            Name = "John LP",
            Number = "123456789000",
            Expiration = "05/09",
            Cvv = "123"
        });
    }
}
