using AutoMapper;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.WalletAccounts
{
    public class CreateWalletAccountCommandHandler : ICommandHandler<CreateWalletAccountCommand, WalletAccountResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly INumberGenerator _numberGenerator;

        public CreateWalletAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, INumberGenerator numberGenerator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _numberGenerator = numberGenerator;
        }

        public async Task<WalletAccountResponseDto> Handle(CreateWalletAccountCommand request, CancellationToken cancellationToken)
        {
            var walletAccount = _mapper.Map<WalletAccount>(request);

            walletAccount.WalletAccountNumber = await _numberGenerator.GenerateAccountNumberAsync();
            await _unitOfWork.WalletAccounts.AddAsync(walletAccount, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<WalletAccountResponseDto>(walletAccount);

        }
    }
}
