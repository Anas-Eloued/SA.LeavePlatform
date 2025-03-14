using MediatR;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.ProjetRequests;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projet>>> GetAllProjets()
        {
            var projets = await _mediator.Send(new GetAllProjetRequest());
            return Ok(projets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projet>> GetProjet(int id)
        {
            var projet = await _mediator.Send(new GetProjetRequest { Id = id });

            if (projet == null)
                return NotFound();

            return Ok(projet);
        }

        [HttpPost]
        public async Task<ActionResult<Projet>> CreateProjet([FromBody] CreateProjetRequest request)
        {
            var createdProjet = await _mediator.Send(request);

            if (createdProjet == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetProjet), new { id = createdProjet.Id }, createdProjet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Projet>> UpdateProjet(int id, [FromBody] UpdateProjetRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID mismatch");

            var updatedProjet = await _mediator.Send(request);

            if (updatedProjet == null)
                return NotFound();

            return Ok(updatedProjet);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjet(int id)
        {
            var result = await _mediator.Send(new DeleteProjetRequest { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}