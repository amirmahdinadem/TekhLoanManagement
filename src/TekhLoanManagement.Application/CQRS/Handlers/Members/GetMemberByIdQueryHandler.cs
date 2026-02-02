using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Members;
using TekhLoanManagement.Application.DTOs.Responses.Members;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Members
{
    public class GetMemberByIdQueryHandler : IQueryHandler<GetMemberByIdQuery, MemberResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMemberByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MemberResponseDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.Members.QuerySingleAsync(
             predicate: m => m.Id == request.Id,
             selector: m => new MemberResponseDto
             {
                 Id = m.Id,
                 FirstName = m.FirstName,
                 LastName = m.LastName,
                 BirthDate = m.BirthDate,
                 JoinDate = m.JoinDate
             });
            if (member == null) throw new NotFoundException("Member Not Found");
            return member;
        }
    }
}
