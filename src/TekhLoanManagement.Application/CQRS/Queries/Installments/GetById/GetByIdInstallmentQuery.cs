using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Installments;

namespace TekhLoanManagement.Application.CQRS.Queries.Installments.GetById
{
    public record GetByIdInstallmentQuery(Guid InstallmentId) : IQuery<InstallmentDto>
    {
    }
}
