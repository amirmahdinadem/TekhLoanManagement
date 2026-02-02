using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.WalletAccounts
{
    public class DeleteWalletAccountCommandHandler : ICommandHandler<DeleteWalletAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWalletAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteWalletAccountCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.WalletAccounts.GetByIdAsync(request.Id, cancellationToken);
            if (item == null) return;

            WalletAccount.Delete(item, request.UserId);

            _unitOfWork.WalletAccounts.Delete(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
