using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TekhLoanManagement.Application.DTOs.Requests.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface IWalletAccountService
    {
        Task<WalletAccountResponseDto> CreateAsync(CreateWalletAccountRequestDto dto, ClaimsPrincipal principal, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, ClaimsPrincipal principal, CancellationToken cancellationToken);
        Task<IEnumerable<WalletAccountResponseDto>> GetAllAsync(int limit, int offset, CancellationToken cancellationToken);
        Task<WalletAccountResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(UpdateWalletAccountRequestDto dto, ClaimsPrincipal principal, CancellationToken cancellationToken);
        Task<IEnumerable<TransactionResponseDto>> GetDebitTransactionsAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TransactionResponseDto>> GetCreditTransactionsAsync(Guid id, CancellationToken cancellationToken);
    }
}
