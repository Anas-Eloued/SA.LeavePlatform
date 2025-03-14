using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.ProjetRequests
{
    public class GetAllProjetRequest : IRequest<IEnumerable<Projet>>
    {
    }
}