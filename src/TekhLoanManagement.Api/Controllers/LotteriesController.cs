using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TekhLoanManagement.Application.CQRS.Commands.Lotteries.AddMember;
using TekhLoanManagement.Application.CQRS.Commands.Lotteries.Celebrate;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotteriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LotteriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddMember(AddLotteryMemberCommand addLotteryMemberCommand)
        {
            await _mediator.Send(addLotteryMemberCommand);
            return Ok();
        }
        [HttpPut("{lotteryId}/Celebration")]
        public async Task<ActionResult> Celebration(Guid lotteryId)
        {
            await _mediator.Send(new CelebrateLotteryCommand(lotteryId));
            return Ok();
        }
    }
}
