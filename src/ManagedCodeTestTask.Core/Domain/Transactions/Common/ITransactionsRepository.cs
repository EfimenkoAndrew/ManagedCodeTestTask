using ManagedCodeTestTask.Core.Domain.Transactions.Models;

namespace ManagedCodeTestTask.Core.Domain.Transactions.Common;

public interface ITransactionsRepository
{
    void Add(Transaction transaction);

    void AddRange(Transaction[] transactions);
}