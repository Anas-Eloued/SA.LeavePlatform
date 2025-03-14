using MediatR;

namespace SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests
{
    public class DeleteEmployeeRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}