using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;

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

            _unitOfWork.WalletAccounts.Delete(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
