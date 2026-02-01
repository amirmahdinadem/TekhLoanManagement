using AutoMapper;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Requests.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Mappings
{
    public class WalletAccountProfile : Profile
    {
        public WalletAccountProfile()
        {
            CreateMap<WalletAccount, WalletAccountResponseDto>()
                 .ForMember("OwnerId", opt => opt.MapFrom((src, dest) => src.GetOwnerId()));

            CreateMap<CreateWalletAccountRequestDto, CreateWalletAccountCommand>();
            CreateMap<UpdateWalletAccountRequestDto, UpdateWalletAccountCommand>();
        }
    }
}
