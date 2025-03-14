using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests
{
    public class GetLeaveTypeRequest : IRequest<LeaveType?>
    {
        public int Id { get; set; }
    }
}