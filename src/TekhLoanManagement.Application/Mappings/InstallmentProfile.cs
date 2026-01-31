using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.DTOs.Responses.Installments;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Mappings
{
    public class InstallmentProfile : Profile
    {
        public InstallmentProfile()
        {
            CreateMap<Installment, InstallmentDto>();
        }
    }
}
