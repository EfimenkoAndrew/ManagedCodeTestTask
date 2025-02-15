using ManagedCodeTestTask.Core.Domain.Transactions.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb;

public class ManagedCodeTestTaskDbContext(DbContextOptions<ManagedCodeTestTaskDbContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }
}