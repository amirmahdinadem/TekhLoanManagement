using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TekhLoanManagement.Application.DTOs.Requests.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionResponseDto> CreateAsync(CreateTransactionRequestDto dto, ClaimsPrincipal principal, string idempotencyKey, CancellationToken cancellationToken);
        Task<IEnumerable<TransactionResponseDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<TransactionResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
