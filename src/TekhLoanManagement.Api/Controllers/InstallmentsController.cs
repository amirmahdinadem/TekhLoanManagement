using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TekhLoanManagement.Application.CQRS.Queries.Installments.GetById;
using TekhLoanManagement.Application.CQRS.Queries.Installments.GetByLoanId;
using TekhLoanManagement.Application.CQRS.Queries.Installments.GetByMemberId;
using TekhLoanManagement.Application.DTOs.Responses.Installments;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstallmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{loanId}")]
        public async Task<ActionResult<IEnumerable<InstallmentDto>>> GetByLoan(Guid loanId)
        {
            var installmens = await _mediator.Send(new GetByLoanIdInstallmentsQuery(loanId));
            return Ok(installmens);
        }
        [HttpGet("{memberId}")]
        public async Task<ActionResult<IEnumerable<InstallmentDto>>> GetByMemeber(Guid memberId)
        {
            var installmens = await _mediator.Send(new GetByMemberIdInstallmentQuery(memberId));
            return Ok(installmens);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<InstallmentDto>>> GetById(Guid id)
        {
            var installmens = await _mediator.Send(new GetByIdInstallmentQuery(id));
            return Ok(installmens);
        }

    }
}
