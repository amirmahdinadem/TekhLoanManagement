using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Loans.Create;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Loans;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Loans.Create
{
    public class CreateLoanCommandHandler : ICommandHandler<CreateLoanCommand, LoanDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateLoanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LoanDto> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {

            var loan = new Loan(request.FundId, request.Amount, request.InstallmentCount , request.StartMonth , request.StartYear);
            loan.CreateLoanInstallment();
            var lottery = await _unitOfWork.Lotteries.AddAsync(loan.CreateLottery(), cancellationToken);
            loan.LotteryId = lottery.Id;
            foreach (var item in loan.Installments)
            {
                await _unitOfWork.Installments.AddAsync(item, cancellationToken);
            }
            await _unitOfWork.Loans.AddAsync(loan, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<LoanDto>(loan);

        }

    }
}
