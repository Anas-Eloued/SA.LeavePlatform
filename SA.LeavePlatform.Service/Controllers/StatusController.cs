using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.StatusRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetAllStatus()
        {
            var status = await _mediator.Send(new GetAllStatusRequest());
            return Ok(status);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            var status = await _mediator.Send(new GetStatusRequest { Id = id });

            if (status == null)
                return NotFound();

            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult<Status>> CreateStatus([FromBody] CreateStatusRequest request)
        {
            var createdStatus = await _mediator.Send(request);
                     
            if (createdStatus == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetStatus), new { id = createdStatus.Id }, createdStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Status>> UpdateStatus(int id, [FromBody] UpdateStatusRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID mismatch");

            var updatedStatus = await _mediator.Send(request);
                       
            if (updatedStatus == null)
                return NotFound();

            return Ok(updatedStatus);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStatus(int id)
        {
            var result = await _mediator.Send(new DeleteStatusRequest { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
