using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.DTOs;
using TekhLoanManagement.Domain;
using TekhLoanManagement.Infrastructure.Security;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<string> GenerateTokenAsync(Guid userId);
        Task<RefreshToken?> GetTokenAsync(string refreshToken);
        Task RevokeTokenAsync(Guid userId, string reason);
        Task SaveChangesAsync();
    }
}
