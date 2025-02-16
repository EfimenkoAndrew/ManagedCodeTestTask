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
        var transactions = new List<Transaction>();
        await foreach (var transactionData
                       in 
                       transactionsProvider
                           .GetTransactionsAsync(command.FilePath)
                           .WithCancellation(cancellationToken))
        {
            transactions.Add(Transaction.Create(transactionData));
            
            counter++;
            if (counter % 10_000 == 0)
            {
                transactionsRepository.AddRange(transactions.ToArray());
                await unitOfWork.SaveChangesAsync(cancellationToken);
                transactions.Clear();
                counter = 0;
            }
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}