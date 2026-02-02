using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Funds;
using TekhLoanManagement.Application.DTOs.Responses.Funds;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Funds.QueryHandlers
{
    public class GetAllQueryHandler : IQueryHandler<GetAllFundsQuery, IEnumerable<FundDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllQueryHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;   
        }
        public async Task<IEnumerable<FundDto>> Handle(GetAllFundsQuery request, CancellationToken cancellationToken)
        {

            var funds = await _unitOfWork.Funds.GetAllAsync(cancellationToken);

            return _mapper.Map<List<FundDto>>(funds);
        }
    }
}
