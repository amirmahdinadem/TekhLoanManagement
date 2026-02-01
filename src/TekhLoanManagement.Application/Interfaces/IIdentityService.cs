using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TekhLoanManagement.Application.DTOs;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<(string AccessToken, string RefreshToken)> LoginAsync(LoginDto input);
        Task RegisterAsync(RegisterDto input);
        Task LogoutAsync(Guid userId);
        Task<User> GetUserAsync(ClaimsPrincipal userPrincipal);
        Task<(string AccessToken, string RefreshToken)> RefreshTokenAsync(string refreshToken);

    }
}
