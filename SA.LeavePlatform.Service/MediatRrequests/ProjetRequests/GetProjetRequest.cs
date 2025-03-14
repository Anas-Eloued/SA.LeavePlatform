using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.ProjetRequests
{
    public class GetProjetRequest : IRequest<Projet?>
    {
        public int Id { get; set; }
    }
}