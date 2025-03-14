using MediatR;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveType>>> GetAllLeaveTypes()
        {
            var leaveTypes = await _mediator.Send(new GetAllLeaveTypeRequest());
            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveType>> GetLeaveType(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeRequest { Id = id });

            if (leaveType == null)
                return NotFound();

            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<ActionResult<LeaveType>> CreateLeaveType([FromBody] CreateLeaveTypeRequest request)
        {
            var createdLeaveType = await _mediator.Send(request);

            if (createdLeaveType == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetLeaveType), new { id = createdLeaveType.Id }, createdLeaveType);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LeaveType>> UpdateLeaveType(int id, [FromBody] UpdateLeaveTypeRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID mismatch");

            var updatedLeaveType = await _mediator.Send(request);

            if (updatedLeaveType == null)
                return NotFound();

            return Ok(updatedLeaveType);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var result = await _mediator.Send(new DeleteLeaveTypeRequest { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}