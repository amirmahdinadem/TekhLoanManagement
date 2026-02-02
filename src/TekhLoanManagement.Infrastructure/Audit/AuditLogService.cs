using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain;
using TekhLoanManagement.Infrastructure.Context;

namespace TekhLoanManagement.Infrastructure.Audit
{
    public class AuditLogService : IAuditLogService
    {
        private readonly TekhLoanDbContext _context;

        public AuditLogService(TekhLoanDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(AuditLog auditLog, CancellationToken cancellationToken = default)
        {
            await _context.AuditLogs.AddAsync(auditLog, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
