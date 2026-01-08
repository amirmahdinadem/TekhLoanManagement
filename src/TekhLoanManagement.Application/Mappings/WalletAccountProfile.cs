using AutoMapper;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Mappings
{
    public class WalletAccountProfile : Profile
    {
        public WalletAccountProfile()
        {
            CreateMap<WalletAccount, WalletAccountResponseDto>();


            CreateMap<CreateWalletAccountCommand, WalletAccount>();
            CreateMap<UpdateWalletAccountCommand, WalletAccount>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
