using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.ProjetRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.ProjetHandlers
{
    public class GetAllProjetHandler : IRequestHandler<GetAllProjetRequest, IEnumerable<Projet>>
    {
        private readonly IProjetQueryRepository _repository;

        public GetAllProjetHandler(IProjetQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Projet>> Handle(GetAllProjetRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
