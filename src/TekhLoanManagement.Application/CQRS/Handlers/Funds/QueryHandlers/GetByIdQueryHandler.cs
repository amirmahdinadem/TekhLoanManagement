using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Funds;
using TekhLoanManagement.Application.DTOs.Responses.Funds;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Funds.QueryHandlers
{
    public class GetByIdQueryHandler : IQueryHandler<GetFundByIdQuery, FundDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;   
            _unitOfWork = unitOfWork;
        }
        public async Task<FundDto> Handle(GetFundByIdQuery request, CancellationToken cancellationToken) 
        {
            var fund = await _unitOfWork.Funds.GetByIdAsync(request.Id, cancellationToken);


            if (fund == null)
                throw new Exception("Fund not found");
            var fund1 = await _unitOfWork.Funds.QuerySingleAsync(

            return _mapper.Map<FundDto>(fund);
        }
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

    }
}
