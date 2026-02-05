using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;

namespace TekhLoanManagement.Domain.Entities
{
    public class User : IdentityUser<Guid> //Karbar Vorod Be System
    {
        public Guid? MemberId { get; set; }
        public Member? Member { get; set; }
    }
}
