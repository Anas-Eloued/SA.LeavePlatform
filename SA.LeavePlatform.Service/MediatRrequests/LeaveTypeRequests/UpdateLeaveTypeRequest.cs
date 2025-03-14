using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests
{
    public class UpdateLeaveTypeRequest : IRequest<LeaveType?>
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Label { get; set; }
        public string? Description { get; set; }
    }
}