using IdentityAndAccessManagement.Api.Constants;
using ManagedCodeTestTask.Application.Domain.Transactions.Queries.GetTransactionsAnalysis;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ManagedCodeTestTask.Application.Domain.Transactions.Commands.ParseTransactions;
using ManagedCodeTestTask.Api.Domain.Transactions.Requests;

namespace ManagedCodeTestTask.Api.Domain.Transactions;

[Route(Routes.Transactions)]
public class TransactionsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTransactions(CancellationToken cancellationToken)
    {
        var transactions = await mediator.Send(new GetTransactionsAnalysisQuery(), cancellationToken);
        return Ok(transactions);
    }

    [HttpPost]
    public async Task<IActionResult> ParseTransactions(
        [FromBody] [Required] ParseTransactionsRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new ParseTransactionsCommand(request.FilePath), cancellationToken);
        return Ok();
    }
}