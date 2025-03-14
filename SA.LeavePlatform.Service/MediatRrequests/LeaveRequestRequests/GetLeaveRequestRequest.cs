using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests
{
    public class GetLeaveRequestRequest : IRequest<LeaveRequest?>
    {
        public int Id { get; set; }
    }
}