using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests
{
    public class CreateLeaveTypeRequest : IRequest<LeaveType?>
    {
        public string? Code { get; set; }
        public string? Label { get; set; }
        public string? Description { get; set; }
    }
}