using MediatR;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests
{
    public class DeleteLeaveDocRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
