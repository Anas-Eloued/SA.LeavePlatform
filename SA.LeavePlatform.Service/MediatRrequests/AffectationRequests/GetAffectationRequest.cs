using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.AffectationRequests
{
    public class GetAffectationRequest : IRequest<Affectation?>
    {
        public int Id { get; set; }
    }
}
