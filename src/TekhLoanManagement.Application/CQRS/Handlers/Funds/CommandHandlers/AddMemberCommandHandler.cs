using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Funds;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Funds.CommandHandlers
{
    public class AddMemberCommandHandler : ICommandHandler<AddMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            var fund = await _unitOfWork.Funds.GetByIdAsync(request.FundId, cancellationToken);
            if (fund == null) {
                throw new Exception("invalid Fund");
            }
            var member = await _unitOfWork.Members.GetByIdAsync(request.MemberId, cancellationToken);
            if (member == null)
            {
                throw new Exception("Invalid Member");
            }
            fund.AddMember(member);
            member.WalletAccount.Frezze(fund.FrozenCalculator());
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
