using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Application.DTOs.Requests.Members
{
    public class CreateMemberRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
    }
}
