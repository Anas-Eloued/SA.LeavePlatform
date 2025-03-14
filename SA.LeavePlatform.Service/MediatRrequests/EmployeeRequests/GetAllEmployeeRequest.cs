using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests
{
    public class GetAllEmployeeRequest : IRequest<IEnumerable<Employee>>
    {
    }
}