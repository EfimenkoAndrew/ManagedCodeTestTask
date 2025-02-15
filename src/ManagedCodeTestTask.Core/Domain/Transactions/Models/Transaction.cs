using ManagedCodeTestTask.Core.Domain.Transactions.Data;

namespace ManagedCodeTestTask.Core.Domain.Transactions.Models;

public class Transaction
{
    private Transaction()
    {
    }

    public Transaction(
        Guid transactionId, 
        Guid userId, 
        DateTime date, 
        decimal amount, 
        string category, 
        string description, 
        string merchant)
    {
        TransactionId = transactionId;
        UserId = userId;
        Date = date;
        Amount = amount;
        Category = category;
        Description = description;
        Merchant = merchant;
    }

    public Guid TransactionId { get; private set; }

    public Guid UserId { get; private set; }

    public DateTime Date { get; private set; }

    public decimal Amount { get; private set; }

    public string Category { get; private set; }

    public string Description { get; private set; }

    public string Merchant { get; private set; }

    public static Transaction Create(CreateTransactionData data)
    {
        return new Transaction(
            data.TransactionId,
            data.UserId,
            data.Date,
            data.Amount,
            data.Category,
            data.Description,
            data.Merchant);
    }
}