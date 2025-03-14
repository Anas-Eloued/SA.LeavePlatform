using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.AffectationRequests
{
    public class GetAllAffectationRequest : IRequest<IEnumerable<Affectation>>
    {
    }
}