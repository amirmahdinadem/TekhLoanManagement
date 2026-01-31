using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.DTOs.Responses.Funds;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Mappings
{
    public class FundProfile : Profile
    {
        public FundProfile()
        {
            CreateMap<Fund, FundDto>();
        }
    }}
