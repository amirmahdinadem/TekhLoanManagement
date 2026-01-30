using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.DTOs.Responses.Loans;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Mappings
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanDto>();
        }
    }
}
