using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb;

public static class ManagedCodeTestTaskDbRegistration
{
    public static void RegisterManagedCodeTestTaskDbContext(
        this IServiceCollection service,
        IConfiguration configuration)
    {
        // Register ManagedCodeTestTaskDbContext here
    }
}