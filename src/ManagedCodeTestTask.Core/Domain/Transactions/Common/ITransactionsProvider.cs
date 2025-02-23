﻿using ManagedCodeTestTask.Core.Domain.Transactions.Data;
using ManagedCodeTestTask.Core.Domain.Transactions.Models;

namespace ManagedCodeTestTask.Core.Domain.Transactions.Common;

public interface ITransactionsProvider
{
    IAsyncEnumerable<CreateTransactionData> GetTransactionsAsync(string filePath);
}