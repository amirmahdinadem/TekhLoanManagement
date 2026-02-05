using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Installments.GetByLoanId;
using TekhLoanManagement.Application.DTOs.Responses.Installments;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Installments.GetByLoandId
{
    public class GetByLoanIdInstallmentsQueryHandler : IQueryHandler<GetByLoanIdInstallmentsQuery, IEnumerable<InstallmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByLoanIdInstallmentsQueryHandler(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<InstallmentDto>> Handle(GetByLoanIdInstallmentsQuery request, CancellationToken cancellationToken)
        {
            var installments = await _unitOfWork.Installments
                .QueryAsync<Installment>(include: x => x.Include(x => x.Transaction),
                                         predicate: x => x.LoanId == request.LoanId
                                                        );
            if (installments == null)
                throw new NotFoundException("Installments Not found");
            return _mapper.Map<IEnumerable<InstallmentDto>>(installments);
        }
    }
}
