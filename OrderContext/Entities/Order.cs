using SharedContext.Entities;

namespace OrderContext.Entities;

public class Order : Entity, IAggregateRoot
{
    public Order(User user)
    {
        User = user;
        LastUpdatedDate = DateTime.Now;
    }

    private List<Transaction> _transactions = new();

    public event EventHandler OnOrderPlaced;
    public event EventHandler OnOrderPaid;

    public User User { get; }

    public DateTime LastUpdatedDate { get; private set; }

    public IReadOnlyCollection<Transaction> Transactions => _transactions;

    public void Place()
    {
        LastUpdatedDate = DateTime.Now;

        var args = EventArgs.Empty;
        var handler = OnOrderPlaced;
        handler.Invoke(this, args);
    }

    public void Pay(Transaction transaction)
    {
        LastUpdatedDate = DateTime.Now;
        _transactions.Add(transaction);
    }
}
