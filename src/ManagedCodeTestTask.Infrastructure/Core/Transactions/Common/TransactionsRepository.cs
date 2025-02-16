using ManagedCodeTestTask.Core.Domain.Transactions.Common;
using ManagedCodeTestTask.Core.Domain.Transactions.Models;
using ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb;

namespace ManagedCodeTestTask.Infrastructure.Core.Transactions.Common
{
    internal class TransactionsRepository(ManagedCodeTestTaskDbContext dbContext) : ITransactionsRepository
    {
        public void Add(Transaction transaction)
        {
            dbContext.Transactions.Add(transaction);
        }
    }
}
