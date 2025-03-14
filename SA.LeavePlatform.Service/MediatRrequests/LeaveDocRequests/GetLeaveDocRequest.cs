using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests
{
    public class GetLeaveDocRequest : IRequest<LeaveDoc?>
    {
        public int Id { get; set; }
    }
}