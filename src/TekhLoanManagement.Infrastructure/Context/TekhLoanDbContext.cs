using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Entities;

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



            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.DebitWalletAccount)
                .WithMany(a => a.DebitTransactions)
                .HasForeignKey(t => t.DebitWalletAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.CreditWalletAccount)
                .WithMany(a => a.CreditTransactions)
                .HasForeignKey(t => t.CreditWalletAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WalletAccount>()
                .HasOne(t => t.Member)
                .WithOne(a => a.WalletAccount)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WalletAccount>()
               .HasOne(t => t.Fund)
               .WithOne(a => a.WalletAccount)
               .OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Fund> Funds { get; set; } = default!;
        public DbSet<Installment> Installments { get; set; } = default!;
        public DbSet<Loan> Loans { get; set; } = default!;
        public DbSet<Member> Members { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Transaction> Transactions { get; set; } = default!;
        public DbSet<WalletAccount> walletAccounts { get; set; } = default!;
        public DbSet<Lottery> Lotteries { get; set; } = default!;
    }
}
