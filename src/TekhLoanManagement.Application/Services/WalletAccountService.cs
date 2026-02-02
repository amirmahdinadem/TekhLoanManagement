using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.CQRS.Queries.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Requests.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.Services
{
    public class WalletAccountService : IWalletAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;

        public WalletAccountService(IMapper mapper, UserManager<User> userManager, IMediator mediator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<WalletAccountResponseDto> CreateAsync(CreateWalletAccountRequestDto dto, ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(principal);
            var command = _mapper.Map<CreateWalletAccountCommand>(dto);
            command.UserId = user.Id;
            return await _mediator.Send(command);
        }
        public async Task DeleteAsync(Guid id, ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(principal);
            var command = new DeleteWalletAccountCommand { Id = id, UserId = user.Id };
            await _mediator.Send(command);
        }

        public async Task<IEnumerable<WalletAccountResponseDto>> GetAllAsync(int limit, int offset, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllWalletAccountsQuery { Limit = limit, Offset = offset });
        }

        public async Task<WalletAccountResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetWalletAccountByIdQuery { Id = id });

        }

        public async Task<IEnumerable<TransactionResponseDto>> GetDebitTransactionsAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetWalletAccountDebitTransactionsQuery { Id = id });
        }

        public async Task<IEnumerable<TransactionResponseDto>> GetCreditTransactionsAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetWalletAccountCreditTransactionsQuery { Id = id });
        }

        public async Task UpdateAsync(UpdateWalletAccountRequestDto dto, ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(principal);
            var command = _mapper.Map<UpdateWalletAccountCommand>(dto);
            command.UserId = user.Id;
            await _mediator.Send(command);
        }
    }
}
