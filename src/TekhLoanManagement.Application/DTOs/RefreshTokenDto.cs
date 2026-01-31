using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.DTOs
{
    public class RefreshTokenDto
    {
        public Guid UserId { get; set; }
        public string Token { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public DateTime? RevokedAt { get; set; }
        

     
    }
}
