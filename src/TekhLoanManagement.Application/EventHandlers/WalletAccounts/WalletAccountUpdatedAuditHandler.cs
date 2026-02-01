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
    public class WalletAccountUpdatedAuditHandler : INotificationHandler<WalletAccountUpdatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public WalletAccountUpdatedAuditHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(WalletAccountUpdatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var auditLog = _mapper.Map<AuditLog>(domainEvent.WalletAccount);
            auditLog.ActionType = AuditActionType.Update;
            auditLog.UserId = domainEvent.UserId;
            auditLog.OldValue = domainEvent.OldValue;
            await _auditLogService.LogAsync(auditLog);
        }
    }
}
