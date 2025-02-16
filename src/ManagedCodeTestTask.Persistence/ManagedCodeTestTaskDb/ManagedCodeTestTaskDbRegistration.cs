using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb;

public static class ManagedCodeTestTaskDbRegistration
{
    private const string ConnectionStringName = "ManagedCodeTestTask";

    public static void RegisterManagedCodeTestTaskDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
                               ?? throw new AggregateException($"Connection string: '{ConnectionStringName}' is not found in configurations.");

        services.AddDbContext<ManagedCodeTestTaskDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        ManagedCodeTestTaskDbContext.MigrationsHistoryTable,
                        ManagedCodeTestTaskDbContext.Schema);
                });
        });

        services.AddScoped<DbContext>(provider => provider.GetRequiredService<ManagedCodeTestTaskDbContext>());
    }
}