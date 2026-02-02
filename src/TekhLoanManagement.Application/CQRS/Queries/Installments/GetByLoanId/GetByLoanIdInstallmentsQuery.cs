using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Installments;

namespace TekhLoanManagement.Application.CQRS.Queries.Installments.GetByLoanId
{
    public record GetByLoanIdInstallmentsQuery(Guid LoanId) : IQuery<IEnumerable<InstallmentDto>> { }
}
