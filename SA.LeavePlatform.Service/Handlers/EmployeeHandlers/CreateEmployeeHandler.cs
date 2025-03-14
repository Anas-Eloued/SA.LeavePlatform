using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.EmployeeHandlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, Employee?>
    {
        private readonly IEmployeeQueryRepository _repository;

        public CreateEmployeeHandler(IEmployeeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee?> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                RoleId = request.RoleId
            };

            await _repository.AddEmployeeAsync(employee);
            return employee;
        }
    }
}
