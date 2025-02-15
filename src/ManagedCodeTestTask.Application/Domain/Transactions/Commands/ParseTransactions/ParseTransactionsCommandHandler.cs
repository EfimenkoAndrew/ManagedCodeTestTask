using MediatR;

namespace ManagedCodeTestTask.Application.Domain.Transactions.Commands.ParseTransactions;

public class ParseTransactionsCommandHandler : IRequestHandler<ParseTransactionsCommand>
{
    public async Task Handle(ParseTransactionsCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}