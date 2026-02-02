using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Application.DTOs
{
    public class RegisterDto
    {
        public string UserName { get; set; }=null!;
        public string Password { get; set; } = null!;
        public Guid MemberId { get; set; }

        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        //public DateOnly BirthDate { get; set; }
        //public DateTime JoinDate { get; set; }= DateTime.Now;
        //public Guid WalletAccountId { get; set; }
    }
}
