using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Application.DTOs.Responses.Members
{
    public class MemberResponseDto
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateOnly BirthDate { get; set; }
        public DateTime JoinDate { get; set; }


    }
}
