using ManagedCodeTestTask.Core.Common;
using ManagedCodeTestTask.Core.Domain.Transactions.Common;
using ManagedCodeTestTask.Infrastructure.Core.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace ManagedCodeTestTask.Infrastructure;

public static class InfrastructureRegistration
{
    public static void RegisterInfrastructure(this IServiceCollection service)
    {
        service.AddScoped<ITransactionsRepository, TransactionsRepository>();
        service.AddScoped<IUnitOfWork, IUnitOfWork>();
    }
}