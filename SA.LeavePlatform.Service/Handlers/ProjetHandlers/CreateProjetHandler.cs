using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.ProjetRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.ProjetHandlers
{
    public class CreateProjetHandler : IRequestHandler<CreateProjetRequest, Projet?>
    {
        private readonly IProjetQueryRepository _repository;

        public CreateProjetHandler(IProjetQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Projet?> Handle(CreateProjetRequest request, CancellationToken cancellationToken)
        {
            var projet = new Projet
            {
                Name = request.Name,
                Code = request.Code,
                Label = request.Label,
                Description = request.Description
            };

            await _repository.AddProjetAsync(projet);
            return projet;
        }
    }
}