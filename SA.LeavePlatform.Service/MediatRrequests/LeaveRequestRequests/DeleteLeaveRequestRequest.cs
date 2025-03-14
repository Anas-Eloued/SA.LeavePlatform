using MediatR;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests
{
    public class DeleteLeaveRequestRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}