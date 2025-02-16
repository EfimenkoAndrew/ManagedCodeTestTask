using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ManagedCodeTestTask.Application;

public static class ApplicationRegistration
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}