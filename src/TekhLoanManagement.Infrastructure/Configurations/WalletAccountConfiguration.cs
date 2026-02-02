using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Infrastructure.Configurations
{
    public class WalletAccountConfiguration : IEntityTypeConfiguration<WalletAccount>
    {
        public void Configure(EntityTypeBuilder<WalletAccount> builder)
        {

            builder.Metadata.FindNavigation(nameof(WalletAccount.DebitTransactions))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(WalletAccount.CreditTransactions))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasIndex(a => a.WalletAccountNumber)
                      .IsUnique();

            builder.Property(a => a.WalletAccountNumber)
                      .HasMaxLength(20);

            builder
                .HasOne(t => t.Member)
                .WithOne(a => a.WalletAccount)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Fund)
                .WithOne(a => a.WalletAccount)
                .OnDelete(DeleteBehavior.Restrict);

            builder
            .Property(t => t.Balance)
            .HasPrecision(18, 2);

            builder.HasIndex(a => a.WalletAccountNumber)
                 .IsUnique();

            builder.Property(a => a.WalletAccountNumber)
                  .HasMaxLength(20);
        }
    }
}
