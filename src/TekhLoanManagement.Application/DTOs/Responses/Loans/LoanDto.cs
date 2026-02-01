namespace TekhLoanManagement.Application.DTOs.Responses.Loans
{
    public class LoanDto
    {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public Guid? MemberId { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentCount { get; set; }
    }


}
