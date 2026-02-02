using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TekhLoanManagement.Application.DTOs.Requests.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Accessibility")]
    [Authorize]
    public class WalletAccountsController : ControllerBase
    {
        private readonly IWalletAccountService _walletAccountService;

        public WalletAccountsController(IWalletAccountService walletAccountService)
        {
            _walletAccountService = walletAccountService;
        }

        // GET: api/WalletAccounts
        [HttpGet]
        [SwaggerOperation(Summary = "Get All Wallet Accounts")]
        public async Task<ActionResult<IEnumerable<WalletAccountResponseDto>>> GetWalletAccounts(CancellationToken cancellationToken, int limit = 25, int offset = 0)
        {
            var walletAccounts = await _walletAccountService.GetAllAsync(limit, offset, cancellationToken);
            return Ok(walletAccounts);
        }

        // GET: api/WalletAccounts/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a Wallet Accounts By ID")]
        public async Task<ActionResult<WalletAccountResponseDto>> GetWalletAccount(Guid id, CancellationToken cancellationToken)
        {
            var walletAccount = await _walletAccountService.GetByIdAsync(id, cancellationToken);


            if (walletAccount == null)
            {
                return NotFound();
            }

            return Ok(walletAccount);
        }

        // GET: api/WalletAccounts/5/DebitTransactions
        [HttpGet("{id}/DebitTransactions")]
        [SwaggerOperation(Summary = "Get a Wallet Accounts Debit Transactions By Id")]
        public async Task<ActionResult<IEnumerable<TransactionResponseDto>>> GetWalletAccountDebitTransactions(Guid id, CancellationToken cancellationToken)
        {
            var walletAccount = await _walletAccountService.GetByIdAsync(id, cancellationToken);


            if (walletAccount == null)
            {
                return NotFound();
            }

            return Ok(await _walletAccountService.GetDebitTransactionsAsync(id, cancellationToken));
        }

        // GET: api/WalletAccounts/5/CreditTransactions
        [HttpGet("{id}/CreditTransactions")]
        [SwaggerOperation(Summary = "Get a Wallet Accounts Credit Transactions By Id")]
        public async Task<ActionResult<IEnumerable<TransactionResponseDto>>> GetWalletAccountCreditTransactions(Guid id, CancellationToken cancellationToken)
        {
            var walletAccount = await _walletAccountService.GetByIdAsync(id, cancellationToken);


            if (walletAccount == null)
            {
                return NotFound();
            }

            return Ok(await _walletAccountService.GetCreditTransactionsAsync(id, cancellationToken));
        }

        // PUT: api/WalletAccounts/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Edit a Wallet Accounts By Id")]
        public async Task<IActionResult> PutWalletAccount(Guid id, UpdateWalletAccountRequestDto dto, CancellationToken cancellationToken)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            await _walletAccountService.UpdateAsync(dto, User, cancellationToken);

            return NoContent();
        }

        // POST: api/WalletAccounts
        [HttpPost]
        [SwaggerOperation(Summary = "Create a Wallet Accounts")]
        public async Task<ActionResult<WalletAccountResponseDto>> PostWalletAccount(CreateWalletAccountRequestDto dto, CancellationToken cancellationToken)
        {
            var walletAccount = await _walletAccountService.CreateAsync(dto, User, cancellationToken);

            return CreatedAtAction("GetWalletAccount", new { id = walletAccount.Id }, walletAccount);
        }

        // DELETE: api/WalletAccounts/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Wallet Accounts By Id")]
        public async Task<IActionResult> DeleteWalletAccount(Guid id, CancellationToken cancellationToken)
        {
            var walletAccount = await _walletAccountService.GetByIdAsync(id, cancellationToken);
            if (walletAccount == null)
            {
                return NotFound();
            }

            await _walletAccountService.DeleteAsync(id, User, cancellationToken);

            return NoContent();
        }
    }
}
