using ManagedCodeTestTask.Core.Domain.Transactions.Common;
using ManagedCodeTestTask.Core.Domain.Transactions.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ManagedCodeTestTask.Infrastructure.Core.Transactions.Common;

public class TransactionsProvider(IOptions<string> options) : ITransactionsProvider
{
    public IAsyncEnumerable<Transaction> GetTransactionsAsync()
    {
        throw new NotImplementedException();
    }
}