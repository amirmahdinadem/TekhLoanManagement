using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Members;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Members
{
    public class UpdateMemberCommandHandler : ICommandHandler<UpdateMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMemberCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(request.Id, cancellationToken);
            if (member == null) throw new NotFoundException("");

            _mapper.Map(request, member);

            _unitOfWork.Members.Update(member);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
