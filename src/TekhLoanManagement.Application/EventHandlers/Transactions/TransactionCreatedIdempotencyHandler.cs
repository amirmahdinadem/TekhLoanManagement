using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Events.Transactions;

namespace TekhLoanManagement.Application.EventHandlers.Transactions
{
    public class TransactionCreatedIdempotencyHandler : INotificationHandler<TransactionCreatedEvent>
    {
        private readonly IIdempotencyService _idempotencyService;
        private readonly IMapper _mapper;

        public TransactionCreatedIdempotencyHandler(IIdempotencyService idempotencyService, IMapper mapper)
        {
            _idempotencyService = idempotencyService;
            _mapper = mapper;
        }

        public async Task Handle(TransactionCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            await _idempotencyService.SaveResultAsync(domainEvent.IdempotencyKey,
                                                      _mapper.Map<TransactionResponseDto>(domainEvent.Transaction),
                                                      domainEvent.UserId);
        }
    }
}
