using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;

namespace TekhLoanManagement.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
    }
}
