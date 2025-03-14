using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests
{
    public class UpdateLeaveDocRequest : IRequest<LeaveDoc?>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public int LeaveRequestId { get; set; }
    }
}