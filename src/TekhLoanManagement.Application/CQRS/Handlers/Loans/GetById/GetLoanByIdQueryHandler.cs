using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Loans.GetLoan;
using TekhLoanManagement.Application.DTOs.Responses.Loans;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Loans.GetById
{
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
            var loans = await _unitOfWork.Loans.QueryAsync<Loan>(include: x => x.Include(x => x.Installments)
                                                                              .Include(x => x.Lottery)
                                                                              .Include(x => x.Member));
            var loan = loans.FirstOrDefault(x => x.Id == request.LoanId);
            if (loan == null)
                throw new NotFoundException("Loan Not found");
            return _mapper.Map<LoanDto>(loan);
        }
    }
}
