using MediatR;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SA.LeavePlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveDocController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveDocController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveDoc>> GetLeaveDoc(int id)
        {
            var leaveDoc = await _mediator.Send(new GetLeaveDocRequest { Id = id });

            if (leaveDoc == null)
            {
                return NotFound();
            }

            return Ok(leaveDoc);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveDoc>>> GetAllLeaveDocs()
        {
            var leaveDocs = await _mediator.Send(new GetAllLeaveDocRequest());
            return Ok(leaveDocs);
        }

     

        [HttpPost]
        public async Task<ActionResult<LeaveDoc>> CreateLeaveDoc(CreateLeaveDocRequest request)
        {
            var leaveDoc = await _mediator.Send(request);

            if (leaveDoc == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetLeaveDoc), new { id = leaveDoc.Id }, leaveDoc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveDoc(int id, UpdateLeaveDocRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var leaveDoc = await _mediator.Send(request);

            if (leaveDoc == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveDoc(int id)
        {
            var result = await _mediator.Send(new DeleteLeaveDocRequest { Id = id });

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}