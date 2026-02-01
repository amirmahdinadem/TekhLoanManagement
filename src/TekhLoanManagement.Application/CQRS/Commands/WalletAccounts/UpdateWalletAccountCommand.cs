using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.CQRS.Commands.WalletAccounts
{
    public class UpdateWalletAccountCommand : ICommand
    {
        public Guid Id { get; set; }
        public WalletAccountStatus Status { get; set; }
        public Guid UserId { get; set; }
    }
}
