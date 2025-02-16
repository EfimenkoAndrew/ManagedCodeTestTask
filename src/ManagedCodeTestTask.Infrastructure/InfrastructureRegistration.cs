using ManagedCodeTestTask.Core.Common;
using ManagedCodeTestTask.Core.Domain.Transactions.Common;
using ManagedCodeTestTask.Infrastructure.Core.Common;
using ManagedCodeTestTask.Infrastructure.Core.Transactions.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ManagedCodeTestTask.Infrastructure;

public static class InfrastructureRegistration
{
    public static void RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ITransactionsProvider, TransactionsProvider>();
    }
}