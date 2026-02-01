using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Members;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Members
{
    public class DeleteMemberCommandHandler : ICommandHandler<DeleteMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.Members.GetByIdAsync(request.Id, cancellationToken);
            if (item == null) return;

            _unitOfWork.Members.Delete(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
