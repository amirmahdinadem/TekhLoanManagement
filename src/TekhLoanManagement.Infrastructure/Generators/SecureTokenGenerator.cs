using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TekhLoanManagement.Infrastructure.Generators
{
    public class SecureTokenGenerator
    {
        public static string GenerateSecureToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(randomBytes);
        }

    }
}
