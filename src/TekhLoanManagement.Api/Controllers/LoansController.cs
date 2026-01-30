using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TekhLoanManagement.Application.CQRS.Commands.Loans.Create;
using TekhLoanManagement.Application.CQRS.Queries.Loans.GetLoan;
using TekhLoanManagement.Application.DTOs.Responses.Loans;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async Task<ActionResult<LoanDto>> PostLoans(CreateLoanCommand createLoanCommand)
        {
            var loan = await _mediator.Send(createLoanCommand);
            return CreatedAtAction("GetLoan", new { Id = loan.Id }, loan);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> GetLoan(Guid id)
        {
            var loan = await _mediator.Send(new GetLoanByIdQuery(id));
            return Ok(loan);
        }
    }
}
