using System.Text.Json.Serialization;

namespace ManagedCodeTestTask.Application.Domain.Transactions.Queries.GetTransactionsAnalysis;

public record TransactionsAnalysisDto
{
    [JsonPropertyName("users_summary")]
    public UserDto[] UsersSummary { get; init; }

    [JsonPropertyName("top_categories")]
    public TopCategoriesDto[] TopCategories { get; init; }

    [JsonPropertyName("highest_spender")]
    public HighestSpenderDto HighestSpender { get; init; }
}