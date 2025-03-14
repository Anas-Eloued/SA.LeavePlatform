using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.StatusRequests
{
    public class GetAllStatusRequest : IRequest<IEnumerable<Status>>
    {
    }
}
