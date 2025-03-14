using MediatR;

namespace SA.LeavePlatform.Service.MediatRrequests.AffectationRequests
{
    public class DeleteAffectationRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}