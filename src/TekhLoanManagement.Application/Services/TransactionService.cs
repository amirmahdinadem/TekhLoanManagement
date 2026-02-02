using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Transactions;
using TekhLoanManagement.Application.CQRS.Queries.Transactions;
using TekhLoanManagement.Application.DTOs.Requests.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;

        public TransactionService(IMapper mapper, UserManager<User> userManager, IMediator mediator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<TransactionResponseDto> CreateAsync(CreateTransactionRequestDto dto, ClaimsPrincipal principal, string idempotencyKey, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(principal);
            var command = _mapper.Map<CreateTransactionCommand>(dto);
            command.UserId = user.Id;
            command.IdempotencyKey = idempotencyKey;
            return await _mediator.Send(command);
        }

        public async Task<IEnumerable<TransactionResponseDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllTransactionsQuery());
        }

        public async Task<TransactionResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetTransactionByIdQuery { Id = id });
        }
    }
}
