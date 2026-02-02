using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Members;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Members;

using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Application.Services;
using TekhLoanManagement.Domain.Entities;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.CQRS.Handlers.Members
{
    public class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand, MemberResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly INumberGenerator _numberGenerator;

        public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, INumberGenerator numberGenerator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _numberGenerator = numberGenerator;
        }

        public async Task<MemberResponseDto> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var walletAccountNumber = await _numberGenerator.GenerateAccountNumberAsync();

            var walletAccount = WalletAccount.Create(
                walletAccountNumber,
                WalletAccountType.Member,
                request.userId);

            await _unitOfWork.WalletAccounts.AddAsync(walletAccount, cancellationToken);

            var member = _mapper.Map<Member>(request);
            member.WalletAccountId = walletAccount.Id;
            await _unitOfWork.Members.AddAsync(member, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<MemberResponseDto>(member);

        }
    }
}
