using AutoMapper;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.WalletAccounts
{
    public class GetWalletAccountByIdQueryHandler : IQueryHandler<GetWalletAccountByIdQuery, WalletAccountResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWalletAccountByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WalletAccountResponseDto> Handle(GetWalletAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var walletAccount = await _unitOfWork.WalletAccounts.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<WalletAccountResponseDto>(walletAccount);
        }
    }
}
