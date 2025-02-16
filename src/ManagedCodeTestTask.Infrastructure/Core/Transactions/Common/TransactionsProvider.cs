using CsvHelper.Configuration;
using CsvHelper;
using ManagedCodeTestTask.Core.Domain.Transactions.Common;
using ManagedCodeTestTask.Core.Domain.Transactions.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Globalization;
using ManagedCodeTestTask.Core.Domain.Transactions.Data;
using nietras.SeparatedValues;

namespace ManagedCodeTestTask.Infrastructure.Core.Transactions.Common;

public class TransactionsProvider: ITransactionsProvider
{
    public async IAsyncEnumerable<CreateTransactionData> GetTransactionsAsync(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);
        while (await csv.ReadAsync())
        {
            yield return csv.GetRecord<CreateTransactionData>();
        }
    }
}