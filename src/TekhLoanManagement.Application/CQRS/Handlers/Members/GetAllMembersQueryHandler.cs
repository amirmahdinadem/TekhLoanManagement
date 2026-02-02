using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Members;
using TekhLoanManagement.Application.DTOs.Responses.Members;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Members
{
    public class GetAllMembersQueryHandler : IQueryHandler<GetAllMembersQuery, IEnumerable<MemberResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMembersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task<IEnumerable<MemberResponseDto>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            
            return await _unitOfWork.Members.QueryAsync(selector: m => new MemberResponseDto
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName= m.LastName,
                BirthDate = m.BirthDate,
                JoinDate= m.JoinDate,
            });
            
      
        }
    }
}
