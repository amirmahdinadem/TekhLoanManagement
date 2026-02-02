using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain;
using TekhLoanManagement.Infrastructure.Context;

namespace TekhLoanManagement.Infrastructure.Idempotency
{
    public class IdempotencyService : IIdempotencyService
    {
        private readonly TekhLoanDbContext _context;

        public IdempotencyService(TekhLoanDbContext context)
        {
            _context = context;
        }

        public async Task<string?> GetResultAsync(string key, Guid userId)
        {
            var record = await _context.IdempotencyKeys
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Key == key && x.UserId == userId);
            return record?.Result;
        }

        public async Task SaveResultAsync(string key, object result, Guid userId)
        {
            var record = new IdempotencyKey(userId, key, JsonSerializer.Serialize(result));

            _context.IdempotencyKeys.Add(record);
            await _context.SaveChangesAsync();
        }
    }
}
