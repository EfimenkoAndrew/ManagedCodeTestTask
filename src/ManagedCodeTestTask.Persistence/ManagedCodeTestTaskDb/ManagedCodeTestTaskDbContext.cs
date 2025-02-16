using ManagedCodeTestTask.Core.Domain.Transactions.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb;

public class ManagedCodeTestTaskDbContext(DbContextOptions<ManagedCodeTestTaskDbContext> options) : DbContext(options)
{
    public const string Schema = "ManagedCodeTestTask";

    public const string MigrationsHistoryTable = "__ManagedCodeTestTaskMigrationsHistory";

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // todo: do it only for local development
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagedCodeTestTaskDbContext).Assembly);
    }
}