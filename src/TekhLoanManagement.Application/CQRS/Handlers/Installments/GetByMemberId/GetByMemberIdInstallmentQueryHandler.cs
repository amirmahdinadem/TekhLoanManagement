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
            var installments = await _unitOfWork.Installments
                .QueryAsync<Installment>(include: x => x.Include(x => x.Transaction)
                                                        .Include(x => x.Loan)
                                                        .ThenInclude(x => x.Member),
                                         predicate: x => x.Loan.MemberId == request.MemberId
            );
            if (installments == null)
                throw new NotFoundException("Installments Not found");
            return _mapper.Map<IEnumerable<InstallmentDto>>(installments);

        }
    }
}
