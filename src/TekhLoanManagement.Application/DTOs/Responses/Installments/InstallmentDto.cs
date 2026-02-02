using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.DTOs.Responses.Installments
{
    public class InstallmentDto
    {
        public Guid LoanId { get; set; }
        public decimal Amount { get; set; }
        public DateOnly DueDate { get; set; }
        public InstallmentStatus Status { get; set; } = InstallmentStatus.NotPaid;
        //public enum Status { get; set; }
    }


}
