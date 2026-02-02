using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Funds;
using TekhLoanManagement.Application.DTOs.Responses.Members;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Funds.QueryHandlers
{
    public class GetMemberByFundQueryHandler : IQueryHandler<GetMembersByFundQuery, IEnumerable<MemberResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetMemberByFundQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<IEnumerable<MemberResponseDto>> Handle(GetMembersByFundQuery request, CancellationToken cancellationToken)
        {
            var fund = await _unitOfWork.Funds.QueryAsync(
                include: x => x.Include(x => x.Members),
                predicate: x => x.Id == request.FundId,
                selector: x => x);
            var MemberList = _mapper.Map<IEnumerable<MemberResponseDto>>(fund.SelectMany(x => x.Members).ToList());
            return MemberList;

        }
    }
}
