using System.Text.Json.Serialization;

namespace ManagedCodeTestTask.Application.Domain.Transactions.Queries.GetTransactionsAnalysis;

public record HighestSpenderDto
{
    [JsonPropertyName("user_id")]
    public Guid UserId { get; init; }

    [JsonPropertyName("total_expense")]
    public decimal TotalExpense { get; init; }
}