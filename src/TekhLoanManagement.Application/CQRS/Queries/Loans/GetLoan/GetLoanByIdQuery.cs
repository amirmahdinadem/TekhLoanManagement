using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Loans;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Queries.Loans.GetLoan
{
    public record GetLoanByIdQuery(Guid LoanId) : IQuery<LoanDto>
    {
    }
    public class GetLoanByIdQueryHandler : IQueryHandler<GetLoanByIdQuery, LoanDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetLoanByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LoanDto> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _unitOfWork.Loans.GetByIdAsync(request.LoanId , cancellationToken);
            return _mapper.Map<LoanDto>(loan);
        }
    }
}
