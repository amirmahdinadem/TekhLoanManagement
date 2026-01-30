using FluentValidation;
using TekhLoanManagement.Application.CQRS.Commands.Loans.Create;

namespace TekhLoanManagement.Application.CQRS.Handlers.Loans.Create
{
    public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanCommandValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must not be less than zero.");
            RuleFor(x => x.InstallmentCount)
                .GreaterThan(0).WithMessage("Amount must not be less than zero.");
            RuleFor(x => x.StartYear)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("The year cannot be less than this year.");
            RuleFor(x => x.StartMonth)
                .GreaterThan(0).LessThan(13).WithMessage("Month cannot be less than zero and greater than 12.");
        }
    }
}
