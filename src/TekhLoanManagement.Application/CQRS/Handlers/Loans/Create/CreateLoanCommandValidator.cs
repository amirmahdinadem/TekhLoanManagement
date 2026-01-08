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
        }
    }
}
