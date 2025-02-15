namespace ManagedCodeTestTask.Core.Domain.Transactions.Data;

public record CreateTransactionData(
Guid TransactionId,
Guid UserId,
DateTime Date,
string Category,
decimal Amount,
string Description,
string Merchant);