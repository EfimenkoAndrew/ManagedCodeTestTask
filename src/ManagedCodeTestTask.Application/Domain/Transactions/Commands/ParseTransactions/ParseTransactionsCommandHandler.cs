using ManagedCodeTestTask.Core.Common;
using ManagedCodeTestTask.Core.Domain.Transactions.Common;
using ManagedCodeTestTask.Core.Domain.Transactions.Data;
using ManagedCodeTestTask.Core.Domain.Transactions.Models;
using MediatR;

namespace ManagedCodeTestTask.Application.Domain.Transactions.Commands.ParseTransactions;

public class ParseTransactionsCommandHandle(
    ITransactionsProvider transactionsProvider,
    ITransactionsRepository transactionsRepository,
    IUnitOfWork unitOfWork) 
    : IRequestHandler<ParseTransactionsCommand>
{
    public async Task Handle(ParseTransactionsCommand command, CancellationToken cancellationToken)
    {
        ulong counter = 0;
        await foreach (var transactionData
                       in 
                       transactionsProvider
                           .GetTransactionsAsync(command.FilePath)
                           .WithCancellation(cancellationToken))
        {
            var transaction = Transaction.Create(transactionData);
            transactionsRepository.Add(transaction);
            counter++;
            if (counter % 10_000 == 0)
            {
                await unitOfWork.SaveChangesAsync(cancellationToken);
                counter = 0;
            }
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}