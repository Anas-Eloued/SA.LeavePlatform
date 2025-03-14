using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests
{
    public class GetEmployeeRequest : IRequest<Employee?>
    {
        public int Id { get; set; }
    }
}