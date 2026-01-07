using AutoMapper;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.WalletAccounts
{
    public class GetAllWalletAccountsQueryHandler : IQueryHandler<GetAllWalletAccountsQuery, IEnumerable<WalletAccountResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWalletAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WalletAccountResponseDto>> Handle(GetAllWalletAccountsQuery request, CancellationToken cancellationToken)
        {
            var walletAccounts = await _unitOfWork.WalletAccounts.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<WalletAccountResponseDto>>(walletAccounts);
        }
    }
}
