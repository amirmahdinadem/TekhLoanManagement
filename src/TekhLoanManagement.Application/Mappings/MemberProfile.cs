using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Members;
using TekhLoanManagement.Application.CQRS.Commands.Transactions;
using TekhLoanManagement.Application.DTOs.Requests.Members;
using TekhLoanManagement.Application.DTOs.Requests.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.Members;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Mappings
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberResponseDto>();
            CreateMap<CreateMemberCommand, Member>();
            CreateMap<UpdateMemberCommand, Member>()
                .ForAllMembers(o => o.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateMemberRequestDto, CreateMemberCommand>();

        }
    }
}
