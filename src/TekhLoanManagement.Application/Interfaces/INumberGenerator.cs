using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface INumberGenerator
    {
        Task<string> GenerateAccountNumberAsync();
    }
}
