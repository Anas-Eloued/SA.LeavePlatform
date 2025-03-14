using MediatR;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetAllLeaveRequests()
        {
            var leaveRequests = await _mediator.Send(new GetAllLeaveRequestRequest());
            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> GetLeaveRequest(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestRequest { Id = id });

            if (leaveRequest == null)
                return NotFound();

            return Ok(leaveRequest);
        }

        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> CreateLeaveRequest([FromBody] CreateLeaveRequestRequest request)
        {
            var createdLeaveRequest = await _mediator.Send(request);

            if (createdLeaveRequest == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetLeaveRequest), new { id = createdLeaveRequest.Id }, createdLeaveRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LeaveRequest>> UpdateLeaveRequest(int id, [FromBody] UpdateLeaveRequestRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID mismatch");

            var updatedLeaveRequest = await _mediator.Send(request);

            if (updatedLeaveRequest == null)
                return NotFound();

            return Ok(updatedLeaveRequest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveRequest(int id)
        {
            var result = await _mediator.Send(new DeleteLeaveRequestRequest { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}