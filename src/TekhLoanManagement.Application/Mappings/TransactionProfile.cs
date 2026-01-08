using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionResponseDto>();

            CreateMap<CreateTransactionCommand, Transaction>();
        }
    }
}
