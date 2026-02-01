using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Infrastructure.Context;
using TekhLoanManagement.Infrastructure.Generators;

namespace TekhLoanManagement.Infrastructure.Security
{
    public class RefreshTokenService:IRefreshTokenService
    {
        private readonly TekhLoanDbContext _context;
       
        public RefreshTokenService(TekhLoanDbContext context)
        {
            _context = context;
            
        }
        public async Task<string> GenerateTokenAsync(Guid userId)
        {

            await RevokeTokenAsync(userId, "New Login");

            var refreshToken = new RefreshToken
            {
                Token = SecureTokenGenerator.GenerateSecureToken(),
                UserId = userId,
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(30)
            };

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();
            return refreshToken.Token;
        }
        public async Task<RefreshToken?> GetTokenAsync(string refreshToken)
        {
            return await _context.RefreshTokens
       .Include(x => x.User)
       .FirstOrDefaultAsync(x => x.Token == refreshToken);
        }
        public async Task<IEnumerable<RefreshToken>> GetActiveTokenAsync(Guid userId)
        {
            return await _context.RefreshTokens
           .Where(x => x.UserId == userId && x.RevokedAt == null)
           .ToListAsync();
        }
        public async Task RevokeTokenAsync(Guid userId, string reason)
        {
            var tokens = await GetActiveTokenAsync(userId);

            foreach (var token in tokens)
            {
                token.RevokedAt = DateTime.Now;
                token.RevokedReason = reason;
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
