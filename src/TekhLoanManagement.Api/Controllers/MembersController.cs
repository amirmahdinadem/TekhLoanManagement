using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TekhLoanManagement.Application.CQRS.Commands.Members;
using TekhLoanManagement.Application.CQRS.Queries.Members;
using TekhLoanManagement.Application.DTOs.Responses.Members;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberResponseDto>>>GetMembers(CancellationToken cancellationToken)
        {
            var members = await _mediator.Send(new GetAllMembersQuery());
            return Ok(members);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberResponseDto>>GetMembers(Guid id,CancellationToken cancellationToken)
        {
            var member= await _mediator.Send(new GetMemberByIdQuery { Id = id});
            if(member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembers(Guid id, UpdateMemberCommand command, CancellationToken cancellationToken) 
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<MemberResponseDto>> PostMembers(CreateMemberCommand command,CancellationToken cancellationToken)
        {
            var member=await _mediator.Send(command);
            return CreatedAtAction("GetMembers",new {id=member.Id},member);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembers(Guid id, CancellationToken cancellationToken)
        {
            var member = await _mediator.Send(new GetMemberByIdQuery { Id = id });
            if(member == null)
            {
                return NotFound();
            }
            await _mediator.Send(new DeleteMemberCommand { Id = id});
            return NoContent();
        }

    }
}
