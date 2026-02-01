using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Application.DTOs
{
    public class LoginDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
