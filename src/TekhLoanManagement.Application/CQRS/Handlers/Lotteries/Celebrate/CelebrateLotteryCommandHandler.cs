using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Application.CQRS.Commands.Lotteries.Celebrate;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Lotteries.Celebrate
{
    public class CelebrateLotteryCommandHandler : ICommandHandler<CelebrateLotteryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CelebrateLotteryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CelebrateLotteryCommand request, CancellationToken cancellationToken)
        {
            var lotteries = await _unitOfWork.Lotteries.QueryAsync<Lottery>(
                predicate: x => x.Id == request.LotteryId,
                include: x => x.Include(x => x.Loan).ThenInclude(x => x.Member).Include(x => x.Members),
                asNoTracking: false,
                selector: x => x
                );
            var lottery = lotteries.FirstOrDefault();
            if (lottery == null)
                throw new NotFoundException("Lottery Not found");
            lottery.Celebration();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
