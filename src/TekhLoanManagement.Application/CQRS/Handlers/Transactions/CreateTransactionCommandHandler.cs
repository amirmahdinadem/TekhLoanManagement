using AutoMapper;
using TekhLoanManagement.Application.CQRS.Commands.Transactions;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Transactions
{
    public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, TransactionResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIdempotencyService _idempotencyService;

        public CreateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IIdempotencyService idempotencyService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _idempotencyService = idempotencyService;
        }

        public async Task<TransactionResponseDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            if (request.DebitWalletAccountId == request.CreditWalletAccountId)
                throw new ConflictException("The parties to the transaction are the same.");

            var previousResult = await _idempotencyService.GetResultAsync(request.IdempotencyKey, request.UserId);
            if (previousResult != null)
            {
                throw new ConflictException(previousResult);
            }

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var from = await _unitOfWork.WalletAccounts.GetByIdAsync(request.DebitWalletAccountId, cancellationToken);
                var to = await _unitOfWork.WalletAccounts.GetByIdAsync(request.CreditWalletAccountId, cancellationToken);

                from.Debit(request.Amount);
                to.Credit(request.Amount);

                var transaction = Transaction.Create(
                    request.DebitWalletAccountId,
                    request.CreditWalletAccountId,
                    request.Amount,
                    request.Description,
                    request.Type,
                    request.IdempotencyKey,
                    request.UserId);

                await _unitOfWork.Transactions.AddAsync(transaction, cancellationToken);

                if (request.InstallmentId is not null)
                {
                    var installment = await _unitOfWork.Installments.GetByIdAsync(request.InstallmentId.Value, cancellationToken);
                    if (installment == null)
                        throw new NotFoundException("Installment Not Found!");

                    installment.Payment(transaction.Id);
                }

                await _unitOfWork.CommitAsync();
                return _mapper.Map<TransactionResponseDto>(transaction);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

        }
    }
}
