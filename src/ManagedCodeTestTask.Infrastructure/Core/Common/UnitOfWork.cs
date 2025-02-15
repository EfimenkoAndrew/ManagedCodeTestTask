using ManagedCodeTestTask.Core.Common;
using ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb;

namespace ManagedCodeTestTask.Infrastructure.Core.Common;

internal class UnitOfWork(ManagedCodeTestTaskDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
