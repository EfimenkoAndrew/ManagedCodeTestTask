using MediatR;

namespace ManagedCodeTestTask.Application.Domain.Transactions.Commands.ParseTransactions;

public record ParseTransactionsCommand(string FilePath) : IRequest;