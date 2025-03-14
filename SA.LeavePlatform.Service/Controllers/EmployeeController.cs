using MediatR;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests;

namespace SA.LeavePlatform.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await _mediator.Send(new GetAllEmployeeRequest());
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeRequest { Id = id });

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            var createdEmployee = await _mediator.Send(request);

            if (createdEmployee == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] UpdateEmployeeRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID mismatch");

            var updatedEmployee = await _mediator.Send(request);

            if (updatedEmployee == null)
                return NotFound();

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeRequest { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}