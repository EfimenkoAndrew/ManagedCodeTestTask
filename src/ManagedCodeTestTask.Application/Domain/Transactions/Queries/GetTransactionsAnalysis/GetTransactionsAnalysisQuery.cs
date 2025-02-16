using MediatR;

namespace ManagedCodeTestTask.Application.Domain.Transactions.Queries.GetTransactionsAnalysis;

public record GetTransactionsAnalysisQuery() : IRequest<object>;