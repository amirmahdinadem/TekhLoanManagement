using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Events.Transactions;

namespace TekhLoanManagement.Application.EventHandlers.Transactions
{
    public class TransactionCreatedAuditHandler : INotificationHandler<TransactionCreatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public TransactionCreatedAuditHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(TransactionCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var transactionDto = _mapper.Map<TransactionResponseDto>(domainEvent.Transaction);

            var auditLog = _mapper.Map<AuditLog>(transactionDto);
            auditLog.ActionType = AuditActionType.Create;
            auditLog.UserId = domainEvent.UserId;

            await _auditLogService.LogAsync(auditLog);
        }
    }
}
