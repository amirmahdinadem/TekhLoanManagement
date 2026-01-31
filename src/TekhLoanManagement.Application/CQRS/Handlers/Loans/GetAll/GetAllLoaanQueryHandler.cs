using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Loans.GetAll;
using TekhLoanManagement.Application.DTOs.Responses.Loans;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Loans.GetAll
{
    public class GetAllLoaanQueryHandler : IQueryHandler<GetAllLoanQuery, IEnumerable<LoanDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllLoaanQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDto>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
        {
            var loans = await _unitOfWork.Loans.QueryAsync<Loan>(include: x => x
                                                                                
                                                                                .Include(x => x.Installments)
                                                                                .Include(x => x.Lottery)
                                                                                .Include(x => x.Member));
            return _mapper.Map<IEnumerable<LoanDto>>(loans);

        }
    }


}
