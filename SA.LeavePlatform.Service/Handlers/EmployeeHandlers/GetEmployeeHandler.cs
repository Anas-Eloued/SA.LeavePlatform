using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests;
using SA.LeavePlatform.Service.Query;
namespace SA.LeavePlatform.Service.Handlers.EmployeeHandlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeRequest, Employee?>
    {
        private readonly IEmployeeQueryRepository _repository;

        public GetEmployeeHandler(IEmployeeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee?> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.GetByIdAsync(request.Id);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}