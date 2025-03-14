using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.ProjetRequests
{
    public class CreateProjetRequest : IRequest<Projet?>
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Label { get; set; }
        public string? Description { get; set; }
    }
}