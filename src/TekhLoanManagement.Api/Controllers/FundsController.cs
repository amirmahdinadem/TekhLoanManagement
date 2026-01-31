using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TekhLoanManagement.Application.CQRS.Commands.Funds;
using TekhLoanManagement.Application.CQRS.Queries.Funds;
using TekhLoanManagement.Application.DTOs.Responses.Funds;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public FundsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FundDto>>> GetFunds(
            CancellationToken cancellationToken)
        {
            var funds = await _mediator.Send(
                new GetAllFundsQuery(),
                cancellationToken);

            return Ok(funds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FundDto>> GetFunds(
            Guid id,
            CancellationToken cancellationToken)
        {
            var fund = await _mediator.Send(
                new GetFundByIdQuery { Id = id },
                cancellationToken);

            if (fund == null)
                return NotFound();

            return Ok(fund);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> PostFunds(
           CreateFundCommand command,
       CancellationToken cancellationToken)
        {
            var fundId = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(
                nameof(GetFunds),
                new { id = fundId },
                fundId);
        }
        [HttpPost("{fundId}/members")]
        public async Task<IActionResult> AddMember(
            Guid fundId,
            [FromBody] Guid memberId,
            CancellationToken cancellationToken)
        {
            var command = new AddMemberCommand(fundId, memberId);

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }



        [HttpPost("{fundId:guid}/loans")]
        public async Task<IActionResult> AddLoan(
         Guid fundId,
         [FromBody] Guid loanId,
         CancellationToken cancellationToken)
        {
            var command = new AddLoanCommand(fundId, loanId);

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
