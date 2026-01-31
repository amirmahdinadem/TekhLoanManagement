using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Installments;

namespace TekhLoanManagement.Application.CQRS.Queries.Installments.GetByMemberId
{
    public record GetByMemberIdInstallmentQuery(Guid MemberId) : IQuery<IEnumerable<InstallmentDto>> { }
}
