using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Fund, Guid> Funds { get; }
        IGenericRepository<Installment, Guid> Installments { get; }
        IGenericRepository<Loan, Guid> Loans { get; }
        IGenericRepository<Lottery, Guid> Lotteries { get; }
        IGenericRepository<Member, Guid> Members { get; }
        IGenericRepository<Transaction, Guid> Transactions { get; }
        IGenericRepository<WalletAccount, Guid> WalletAccounts { get; }

        Task BeginTransactionAsync();
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
