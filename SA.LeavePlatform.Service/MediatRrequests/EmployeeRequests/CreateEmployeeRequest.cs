using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests
{
    public class CreateEmployeeRequest : IRequest<Employee?>
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
    }
}