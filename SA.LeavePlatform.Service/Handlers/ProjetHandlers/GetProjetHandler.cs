using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.ProjetRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.ProjetHandlers
{
    public class GetProjetHandler : IRequestHandler<GetProjetRequest, Projet?>
    {
        private readonly IProjetQueryRepository _repository;

        public GetProjetHandler(IProjetQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Projet?> Handle(GetProjetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.GetByIdAsync(request.Id);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}