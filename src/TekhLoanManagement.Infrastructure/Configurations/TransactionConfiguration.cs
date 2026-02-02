using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Infrastructure.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
             .HasOne(t => t.DebitWalletAccount)
             .WithMany(a => a.DebitTransactions)
             .HasForeignKey(t => t.DebitWalletAccountId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(t => t.CreditWalletAccount)
             .WithMany(a => a.CreditTransactions)
             .HasForeignKey(t => t.CreditWalletAccountId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .Property(t => t.Amount)
             .HasPrecision(18, 2);
        }
    }
}
