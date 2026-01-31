using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Application.CQRS.Commands.Lotteries.AddMember;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Lotteries.AddMember
{
    public class AddLotteryMemberCommandHandler : ICommandHandler<AddLotteryMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddLotteryMemberCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(AddLotteryMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(request.MemberId, cancellationToken);
            if (member == null)
                throw new NotFoundException("Member Not Found");
            var loan = await _unitOfWork.Loans.GetByIdAsync(request.LoanId, cancellationToken);
            if (loan == null)
                throw new NotFoundException("Loan Not Found");
            // var lottery = await _unitOfWork.Lotteries.GetByIdAsync(loan.LotteryId, cancellationToken);
            var lottery = await _unitOfWork.Lotteries.QueryAsync<Lottery>(
                predicate: x => x.Id == loan.LotteryId,
                include: x => x.Include(x => x.Members),
                selector: x => x
                );
            var lot = lottery.FirstOrDefault();
            if (lot == null)
                throw new NotFoundException("Lotter Not Found");
            lot.AddMember(member);
            await _unitOfWork.SaveChangesAsync();

        }
    }


}
