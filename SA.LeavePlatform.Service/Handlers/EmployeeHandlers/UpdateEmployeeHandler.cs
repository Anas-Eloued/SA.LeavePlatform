using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, Employee?>
    {
        private readonly IEmployeeQueryRepository _repository;

        public UpdateEmployeeHandler(IEmployeeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee?> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _repository.GetByIdAsync(request.Id);

                employee.Name = request.Name;
                employee.LastName = request.LastName;
                employee.Phone = request.Phone;
                employee.Email = request.Email;
                employee.RoleId = request.RoleId;

                await _repository.UpdateEmployeeAsync(employee);
                return employee;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}