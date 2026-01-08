using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Queries.Loans.GetAll
{
    public record GetAllLoanQuery : IQuery<IEnumerable<LoanDto>>
    {
    }
    //public class GetAllLoaanQueryHandler : IQueryHandler<GetAllLoanQuery, IEnumerable<LoanDto>>
    //{
    //    private readonly IUnitOfWork _unitOfWork;

    //    public GetAllLoaanQueryHandler(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task<IEnumerable<LoanDto>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
    //    {
    //        var loans = await _unitOfWork.Loans.GetAllAsync(cancellationToken);
    //        var loansDto = new GetAllLoanDto()
    //        {
    //            Loans = loans.Select(x => x.)
    //        }

    //    }
    //}

    public class LoanDto
    {
        public DateOnly StartDate { get; set; }
        public string MemberName { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentCount { get; set; }
        public List<InstallmentDto> Installments { get; set; } = new List<InstallmentDto>();
    }
    public class InstallmentDto
    {
        public decimal Amount { get; set; }
        public DateOnly DueDate { get; set; }
        public string Status { get; set; }
    }

    
}
