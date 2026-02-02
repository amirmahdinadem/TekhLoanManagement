using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(AuditLog auditLog, CancellationToken cancellationToken = default);
    }
}
