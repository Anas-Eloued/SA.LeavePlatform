using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.EmployeeHandlers
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequest, IEnumerable<Employee>>
    {
        private readonly IEmployeeQueryRepository _repository;

        public GetAllEmployeeHandler(IEmployeeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}