using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests
{
    public class GetAllLeaveTypeRequest : IRequest<IEnumerable<LeaveType>>
    {
    }
}