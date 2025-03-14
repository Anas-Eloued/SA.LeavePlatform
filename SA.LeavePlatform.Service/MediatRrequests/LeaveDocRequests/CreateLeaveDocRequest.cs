using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests
{
    public class CreateLeaveDocRequest : IRequest<LeaveDoc?>
    {
        public string? Name { get; set; }
        public string? Path { get; set; }
        public int LeaveRequestId { get; set; }
    }
}