using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests
{
    public class GetAllLeaveRequestRequest : IRequest<IEnumerable<LeaveRequest>>
    {
    }
}