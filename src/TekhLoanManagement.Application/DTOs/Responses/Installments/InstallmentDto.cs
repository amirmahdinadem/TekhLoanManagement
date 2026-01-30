namespace TekhLoanManagement.Application.DTOs.Responses.Installments
{
    public class InstallmentDto
    {
        public decimal Amount { get; set; }
        public DateOnly DueDate { get; set; }
        //public enum Status { get; set; }
    }


}
