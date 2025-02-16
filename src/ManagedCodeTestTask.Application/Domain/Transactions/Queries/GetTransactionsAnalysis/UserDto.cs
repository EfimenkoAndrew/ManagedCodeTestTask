using System.Text.Json.Serialization;

namespace ManagedCodeTestTask.Application.Domain.Transactions.Queries.GetTransactionsAnalysis;

public record UserDto
{
    [JsonPropertyName("user_id")]
    public Guid UserId { get; init; }

    [JsonPropertyName("total_income")]
    public decimal TotalIncome { get; init; }

    [JsonPropertyName("total_expense")]
    public decimal TotalExpense { get; init; }
}