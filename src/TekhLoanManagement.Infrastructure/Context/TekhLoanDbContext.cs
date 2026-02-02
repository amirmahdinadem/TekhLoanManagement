using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Domain;
using TekhLoanManagement.Domain.Entities;
using TekhLoanManagement.Infrastructure.Security;

namespace TekhLoanManagement.Infrastructure.Context
{

    public class TekhLoanDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public TekhLoanDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TekhLoanDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TekhLoanDbContext).Assembly);

            modelBuilder.HasSequence<long>("AccountNumberSequence")
            .StartsAt(1000000000)
            .IncrementsBy(1);

            modelBuilder.Entity<Loan>()
           .Property(t => t.Amount)
           .HasPrecision(18, 2);

            modelBuilder.Entity<Installment>()
           .Property(t => t.Amount)
           .HasPrecision(18, 2);

            modelBuilder.Entity<Fund>()
           .Property(t => t.MonthlyPaymentAmount)
           .HasPrecision(18, 2);

        }
        public DbSet<Fund> Funds { get; set; } = default!;
        public DbSet<Installment> Installments { get; set; } = default!;
        public DbSet<Loan> Loans { get; set; } = default!;
        public DbSet<Member> Members { get; set; } = default!;
        public DbSet<Transaction> Transactions { get; set; } = default!;
        public DbSet<WalletAccount> WalletAccounts { get; set; } = default!;
        public DbSet<Lottery> Lotteries { get; set; } = default!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
        public DbSet<IdempotencyKey> IdempotencyKeys { get; set; } = default!;
        public DbSet<AuditLog> AuditLogs { get; set; } = default!;

    }
}
