using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TekhLoanManagement.Application.DTOs.Requests.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Accessibility")]
    [Authorize]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET: api/Transactions
        [HttpGet]
        [SwaggerOperation(Summary = "Get All Transactions")]
        public async Task<ActionResult<IEnumerable<TransactionResponseDto>>> GetTransactions(CancellationToken cancellationToken)
        {
            var transaction = await _transactionService.GetAllAsync(cancellationToken);
            return Ok(transaction);
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a Transaction By ID")]
        public async Task<ActionResult<TransactionResponseDto>> GetTransaction(Guid id, CancellationToken cancellationToken)
        {
            var transaction = await _transactionService.GetByIdAsync(id, cancellationToken);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // POST: api/Transactions
        [HttpPost]
        [SwaggerOperation(Summary = "Create a Transaction")]
        public async Task<ActionResult<TransactionResponseDto>> PostTransaction(CreateTransactionRequestDto createTransactionRequestDto, [FromHeader(Name = "Idempotency-Key")] string idempotencyKey, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(idempotencyKey))
                return BadRequest("Idempotency-Key is required");

            var transaction = await _transactionService.CreateAsync(createTransactionRequestDto, User, idempotencyKey, cancellationToken);

            return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
        }
    }
}
