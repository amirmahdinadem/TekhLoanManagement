using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Funds;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Funds
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
            var member = await _unitOfWork.Members.GetByIdAsync(request.MemberId, cancellationToken);            
            fund.AddMember(member);
            await _unitOfWork.SaveChangesAsync(cancellationToken); 
        }
    }
}
