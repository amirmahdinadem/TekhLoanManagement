using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;
using TekhLoanManagement.Infrastructure.Context;
using TekhLoanManagement.Infrastructure.Extensions;
using TekhLoanManagement.Infrastructure.Repositories;

namespace TekhLoanManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TekhLoanDbContext _context;
        private readonly IMediator _mediator;
        private IDbContextTransaction? _transaction;

        public IGenericRepository<Fund, Guid> Funds { get; }
        public IGenericRepository<Installment, Guid> Installments { get; }
        public IGenericRepository<Loan, Guid> Loans { get; }
        public IGenericRepository<Lottery, Guid> Lotteries { get; }
        public IGenericRepository<Member, Guid> Members { get; }
        public IGenericRepository<Transaction, Guid> Transactions { get; }
        public IGenericRepository<WalletAccount, Guid> WalletAccounts { get; }

        public UnitOfWork(TekhLoanDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;

            Funds = new GenericRepository<Fund, Guid>(_context);
            Installments = new GenericRepository<Installment, Guid>(_context);
            Loans = new GenericRepository<Loan, Guid>(_context);
            Lotteries = new GenericRepository<Lottery, Guid>(_context);
            Members = new GenericRepository<Member, Guid>(_context);
            Transactions = new GenericRepository<Transaction, Guid>(_context);
            WalletAccounts = new GenericRepository<WalletAccount, Guid>(_context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            if (_transaction != null)
                await _transaction.CommitAsync(cancellationToken);
        }

        public async Task RollbackAsync()
        {
            await _transaction!.RollbackAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(_context);
        }
    }
}
