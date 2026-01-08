using AutoMapper;
using System;
using System.Collections.Generic;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.WalletAccounts
{
    public class UpdateWalletAccountCommandHandler : ICommandHandler<UpdateWalletAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateWalletAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateWalletAccountCommand request, CancellationToken cancellationToken)
        {
            var walletAccount = await _unitOfWork.WalletAccounts.GetByIdAsync(request.Id, cancellationToken);
            if (walletAccount == null) throw new NotFoundException("");

            _mapper.Map(request, walletAccount);

            _unitOfWork.WalletAccounts.Update(walletAccount);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
