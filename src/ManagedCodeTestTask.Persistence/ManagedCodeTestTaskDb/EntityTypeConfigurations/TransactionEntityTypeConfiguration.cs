using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagedCodeTestTask.Core.Domain.Transactions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb.EntityTypeConfigurations
{
    internal class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.TransactionId);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Date);

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.Category)
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(550);

            builder.Property(x => x.Merchant)
                .HasMaxLength(550);
        }
    }
}
