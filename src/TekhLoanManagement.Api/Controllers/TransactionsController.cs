using MediatR;
using Microsoft.AspNetCore.Mvc;
using TekhLoanManagement.Application.CQRS.Commands.Transactions;
using TekhLoanManagement.Application.CQRS.Queries.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponseDto>>> GetTransactions(CancellationToken cancellationToken)
        {
            var transaction = await _mediator.Send(new GetAllTransactionsQuery());
            return Ok(transaction);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponseDto>> GetTransaction(Guid id, CancellationToken cancellationToken)
        {
            var transaction = await _mediator.Send(new GetTransactionByIdQuery { Id = id });

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionResponseDto>> PostTransaction(CreateTransactionCommand command, CancellationToken cancellationToken)
        {

            var transaction = await _mediator.Send(command);

            return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
        }
    }
}
