using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Domain
{
    public class AuditLog : BaseEntity<Guid>
    {
        public string EntityName { get; set; }
        public Guid? EntityId { get; set; }
        public AuditActionType ActionType { get; set; }
        public Guid UserId { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
