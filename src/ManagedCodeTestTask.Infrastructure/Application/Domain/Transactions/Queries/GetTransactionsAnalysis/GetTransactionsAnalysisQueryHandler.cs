using ManagedCodeTestTask.Application.Domain.Transactions.Queries.GetTransactionsAnalysis;
using ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ManagedCodeTestTask.Infrastructure.Application.Domain.Transactions.Queries.GetTransactionsAnalysis;

public class GetTransactionsAnalysisQueryHandler(ManagedCodeTestTaskDbContext dbContext) 
    : IRequestHandler<GetTransactionsAnalysisQuery, TransactionsAnalysisDto>
{
    private const string _filePath = "output/output_file.json";

    public async Task<TransactionsAnalysisDto> Handle(GetTransactionsAnalysisQuery query, CancellationToken cancellationToken)
    {
        var users = await dbContext
            .Transactions
            .AsNoTracking()
            .GroupBy(x => x.UserId)
            .Select(x => new UserDto
            {
                UserId = x.Key,
                TotalIncome = x.Where(x => x.Amount > 0).Sum(x => x.Amount),
                TotalExpense = x.Where(x => x.Amount < 0).Sum(x => x.Amount)
            })
            .OrderBy(x=>x.TotalExpense)
            .ToArrayAsync(cancellationToken);

        var categories = await dbContext
            .Transactions
            .AsNoTracking()
            .GroupBy(x => x.Category)
            .Select(x => new TopCategoriesDto
            {
                Category = x.Key,
                TransactionsCount = x.Count()
            })
            .OrderByDescending(x => x.TransactionsCount)
            .Take(3)
            .ToArrayAsync(cancellationToken);

        var userWithMaxExpense = users.Select(x => new HighestSpenderDto()
        {
            UserId = x.UserId,
            TotalExpense = x.TotalExpense
        }).First();

        var transactionsAnalysis =  new TransactionsAnalysisDto
        {
            UsersSummary = users,
            TopCategories = categories,
            HighestSpender = userWithMaxExpense
        };

        if (query.GenerateReport)
        {
            await using var createStream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(createStream, transactionsAnalysis, cancellationToken: cancellationToken);
        }

        return transactionsAnalysis;
    }
}