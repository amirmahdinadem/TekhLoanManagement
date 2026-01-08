using MediatR;
using Microsoft.AspNetCore.Mvc;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.CQRS.Queries.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletAccountResponseDto>>> GetWalletAccounts(CancellationToken cancellationToken)
        {
            var walletAccounts = await _mediator.Send(new GetAllWalletAccountsQuery());
            return Ok(walletAccounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WalletAccountResponseDto>> GetWalletAccounts(Guid id, CancellationToken cancellationToken)
        {
            var walltAccount = await _mediator.Send(new GetWalletAccountByIdQuery { Id = id });


            if (walltAccount == null)
            {
                return NotFound();
            }

            return Ok(walltAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWalletAccounts(Guid id, UpdateWalletAccountCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<WalletAccountResponseDto>> PostWalletAccounts(CreateWalletAccountCommand command, CancellationToken cancellationToken)
        {
            var account = await _mediator.Send(command);

            return CreatedAtAction("GetWalletAccounts", new { id = account.Id }, account);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWalletAccounts(Guid id, CancellationToken cancellationToken)
        {
            var walletAccount = await _mediator.Send(new GetWalletAccountByIdQuery { Id = id });
            if (walletAccount == null)
            {
                return NotFound();
            }

            await _mediator.Send(new DeleteWalletAccountCommand { Id = id });

            return NoContent();
        }
    }
}
