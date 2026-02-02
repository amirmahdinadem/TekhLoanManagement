namespace TekhLoanManagement.Application.CQRS.Handlers.Loans.GetByFundId;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Loans.GetLoaosByFundId;
using TekhLoanManagement.Application.DTOs.Responses.Loans;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

public class GetLoansByFundIdQueryHandler : IQueryHandler<GetLoansByFundIdQuery, List<LoanDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLoansByFundIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<LoanDto?>> Handle(GetLoansByFundIdQuery request, CancellationToken cancellationToken)
    {
        var loans = await _unitOfWork.Loans.QueryAsync<Loan>(
            predicate: x => x.FundId == request.FundId,
            include: x => x.Include(x => x.Installments).Include(x => x.Lottery).Include(x => x.Member),
            asNoTracking: false

            );
        var result = loans.Where(x => x.FundId == request.FundId);
        return _mapper.Map<List<LoanDto?>>(result);
    }
}
