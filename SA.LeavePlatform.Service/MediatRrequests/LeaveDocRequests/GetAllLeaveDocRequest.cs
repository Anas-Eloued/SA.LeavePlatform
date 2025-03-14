using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests
{
    public class GetAllLeaveDocRequest : IRequest<IEnumerable<LeaveDoc>>
    {
    }
}
