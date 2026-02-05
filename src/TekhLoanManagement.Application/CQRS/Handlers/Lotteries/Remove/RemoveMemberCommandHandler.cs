using TekhLoanManagement.Application.CQRS.Commands.Lotteries.RemoveMember;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Lotteries.Remove
{
    public class RemoveMemberCommandHandler : ICommandHandler<RemoveMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(RemoveMemberCommand request, CancellationToken cancellationToken)
        {
            var lottery = await _unitOfWork.Lotteries.GetByIdAsync(request.LotteryId, cancellationToken);
            if (lottery == null)
                throw new NotFoundException("Lottery Not Found");
            lottery.RemoveMember(request.MemberId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
