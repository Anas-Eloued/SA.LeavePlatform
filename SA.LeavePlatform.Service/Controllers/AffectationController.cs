using MediatR;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.AffectationRequests;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AffectationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AffectationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Affectation>>> GetAllAffectations()
        {
            var affectations = await _mediator.Send(new GetAllAffectationRequest());
            return Ok(affectations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Affectation>> GetAffectation(int id)
        {
            var affectation = await _mediator.Send(new GetAffectationRequest { Id = id });

            if (affectation == null)
                return NotFound();

            return Ok(affectation);
        }

        [HttpPost]
        public async Task<ActionResult<Affectation>> CreateAffectation([FromBody] CreateAffectationRequest request)
        {
            var createdAffectation = await _mediator.Send(request);

            if (createdAffectation == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetAffectation), new { id = createdAffectation.Id }, createdAffectation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Affectation>> UpdateAffectation(int id, [FromBody] UpdateAffectationRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID mismatch");

            var updatedAffectation = await _mediator.Send(request);

            if (updatedAffectation == null)
                return NotFound();

            return Ok(updatedAffectation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAffectation(int id)
        {
            var result = await _mediator.Send(new DeleteAffectationRequest { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}