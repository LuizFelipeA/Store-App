using OrderContext.ValueObjects;

namespace OrderContext.Entities;

public class Transaction
{
    public Transaction(CreditCard creditCard) => CreditCard = creditCard;

    public CreditCard CreditCard { get; }
}
