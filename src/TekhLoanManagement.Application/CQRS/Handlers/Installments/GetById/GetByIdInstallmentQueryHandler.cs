using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Installments.GetById;
using TekhLoanManagement.Application.DTOs.Responses.Installments;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Installments.GetById
{
    public class GetByIdInstallmentQueryHandler : IQueryHandler<GetByIdInstallmentQuery, InstallmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdInstallmentQueryHandler(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<InstallmentDto> Handle(GetByIdInstallmentQuery request, CancellationToken cancellationToken)
        {
            var installments = await _unitOfWork.Installments
                .QueryAsync<Installment>(include: x => x.Include(x => x.Transaction)
                                                        
                                                        );
            var installment = installments.FirstOrDefault(x => x.Id == request.InstallmentId);
            if (installment == null)
                throw new NotFoundException("Installment Not found ");
            return _mapper.Map<InstallmentDto>(installment);
        }
    }
}
