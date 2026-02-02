using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TekhLoanManagement.Application.CQRS.Commands.Funds;
using TekhLoanManagement.Application.CQRS.Queries.Funds;
using TekhLoanManagement.Application.DTOs.Responses.Funds;
using TekhLoanManagement.Application.DTOs.Responses.Members;

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

        [HttpGet("CalculateSeedMoney")]
        public async Task<ActionResult<decimal>> GetFundSeedMoney ([FromQuery] CalculateSeedMoneyQuery query,
        CancellationToken cancellationToken)
        {
            var seedmoney = await _mediator.Send( query, cancellationToken);

            return Ok(seedmoney);
        }

        [HttpGet ("GetMembersByFund")]
        public async Task<ActionResult<IEnumerable<MemberResponseDto>>> GetMembersByFund(
            [FromQuery] GetMembersByFundQuery query ,
            CancellationToken cancellationToken)
        {
            var memberList = await _mediator.Send(query,cancellationToken);    
            return Ok(memberList);  
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

            return Ok(fundId);
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

    }
}
