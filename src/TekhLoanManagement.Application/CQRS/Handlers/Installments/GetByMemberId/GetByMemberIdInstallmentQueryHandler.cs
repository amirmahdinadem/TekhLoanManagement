using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Installments.GetByMemberId;
using TekhLoanManagement.Application.DTOs.Responses.Installments;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Installments.GetByMemberId
{
    public class GetByMemberIdInstallmentQueryHandler : IQueryHandler<GetByMemberIdInstallmentQuery, IEnumerable<InstallmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByMemberIdInstallmentQueryHandler(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<InstallmentDto>> Handle(GetByMemberIdInstallmentQuery request, CancellationToken cancellationToken)
        {
            var loan = await _unitOfWork.Loans
                .QueryAsync<Loan>(include: x => x.Include(x => x.Member)
                                                        .Include(x => x.Installments)
                                                        ,
                                                  predicate: x => x.MemberId == request.MemberId,
                                                  selector:x=>x
                                                 
            );
            
            var installments = loan.SelectMany(x => x.Installments).ToList();
            if (installments == null)
                throw new NotFoundException("Installments Not found");
            return _mapper.Map<IEnumerable<InstallmentDto>>(installments);

        }
    }
}
