using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TekhLoanManagement.Application.CQRS.Commands.Members;
using TekhLoanManagement.Application.DTOs.Requests.Members;
using TekhLoanManagement.Application.DTOs.Responses.Members;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;

        public MemberService(IMapper mapper, UserManager<User> userManager, IMediator mediator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<MemberResponseDto> CreateAsync(CreateMemberRequestDto dto, ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(principal);
            var command = _mapper.Map<CreateMemberCommand>(dto);
            command.userId = user.Id;
            return await _mediator.Send(command);
        }
    }
}
