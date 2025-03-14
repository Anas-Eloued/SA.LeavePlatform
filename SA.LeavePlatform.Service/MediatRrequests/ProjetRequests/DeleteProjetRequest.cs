using MediatR;

namespace SA.LeavePlatform.Service.MediatRrequests.ProjetRequests
{
    public class DeleteProjetRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}