using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;

namespace TekhLoanManagement.Application.CQRS.Queries.WalletAccounts
{
    public class GetAllWalletAccountsQuery : IQuery<IEnumerable<WalletAccountResponseDto>>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class GetAllWalletAccountsQueryValidator : AbstractValidator<GetAllWalletAccountsQuery>
    {
        public GetAllWalletAccountsQueryValidator()
        {
            RuleFor(x => x.Limit)
             .GreaterThan(0)
             .LessThanOrEqualTo(25);

            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);
        }
    }
}
