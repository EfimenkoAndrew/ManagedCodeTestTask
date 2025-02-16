using System.Text.Json.Serialization;

namespace ManagedCodeTestTask.Application.Domain.Transactions.Queries.GetTransactionsAnalysis;

public record TopCategoriesDto
{
    [JsonPropertyName("category")]
    public string Category { get; init; }

    [JsonPropertyName("transactions_count")]
    public int TransactionsCount { get; init; }
}