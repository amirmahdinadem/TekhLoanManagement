namespace TekhLoanManagement.Application.CQRS.Handlers.Loans.Create;

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
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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

        var loan = new Loan(request.FundId, request.Amount, request.InstallmentCount, request.StartMonth, request.StartYear);
        var fund = await _unitOfWork.Funds.GetByIdAsync(request.FundId, cancellationToken);
        loan.CreateLoanInstallment(fund.ProfitRate);
        var lottery = await _unitOfWork.Lotteries.AddAsync(loan.CreateLottery(), cancellationToken);
        loan.LotteryId = lottery.Id;
        //var a = await _unitOfWork.Loans.QueryAsync(
        //    include: x => x.Include(x => x.Fund),
        //    predicate: x => x.StartDate > DateOnly.FromDateTime(DateTime.Now) && x.Amount < 1000_000,

        //    orderBy: x => x.OrderByDescending(z => z.Id),
        //    selector: x => new LoanDto
        //    {
        //        Id = x.Id,
        //        Amount = x.Amount,
        //        InstallmentCount = x.InstallmentCount,
        //        MemberId = x.MemberId,
        //        StartDate = x.StartDate,
        //    },
        //    asNoTracking: true);
        foreach (var item in loan.Installments)
        {
            await _unitOfWork.Installments.AddAsync(item, cancellationToken);
        }
        await _unitOfWork.Loans.AddAsync(loan, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<LoanDto>(loan);

    }

}
