using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text.Json;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.WalletAccounts
{
    public class UpdateWalletAccountCommandHandler : ICommandHandler<UpdateWalletAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWalletAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateWalletAccountCommand request, CancellationToken cancellationToken)
        {
            var walletAccount = await _unitOfWork.WalletAccounts.GetByIdAsync(request.Id, cancellationToken);
            if (walletAccount == null) throw new NotFoundException("");

            var oldValue = JsonSerializer.Serialize(walletAccount);

            walletAccount.ChangeStatus(request.Status, request.UserId, oldValue);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
