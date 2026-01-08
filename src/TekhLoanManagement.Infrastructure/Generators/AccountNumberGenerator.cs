using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Infrastructure.Context;

namespace TekhLoanManagement.Infrastructure.Generators
{
    public class AccountNumberGenerator : INumberGenerator
    {
        private readonly TekhLoanDbContext _context;

        public AccountNumberGenerator(TekhLoanDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateAccountNumberAsync()
        {
            var connection = _context.Database.GetDbConnection();
            if (connection.State != System.Data.ConnectionState.Open)
                await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT NEXT VALUE FOR AccountNumberSequence";

            var result = await command.ExecuteScalarAsync();
            return $"10{Convert.ToInt64(result)}";
        }
    }

}
