using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Events.WalletAccounts;

namespace TekhLoanManagement.Application.EventHandlers.WalletAccounts
{
    public class WalletAccountCreatedAuditHandler : INotificationHandler<WalletAccountCreatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public WalletAccountCreatedAuditHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(WalletAccountCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var auditLog = _mapper.Map<AuditLog>(domainEvent.WalletAccount);
            auditLog.ActionType = AuditActionType.Create;
            auditLog.UserId = domainEvent.UserId;
            await _auditLogService.LogAsync(auditLog);
        }
    }
}
