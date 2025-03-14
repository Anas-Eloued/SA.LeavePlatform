using MediatR;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests
{
    public class DeleteLeaveTypeRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}