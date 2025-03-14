using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.ProjetRequests;
using SA.LeavePlatform.Service.Query;


namespace SA.LeavePlatform.Service.Handlers.ProjetHandlers
{
    public class UpdateProjetHandler : IRequestHandler<UpdateProjetRequest, Projet?>
    {
        private readonly IProjetQueryRepository _repository;

        public UpdateProjetHandler(IProjetQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Projet?> Handle(UpdateProjetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var projet = await _repository.GetByIdAsync(request.Id);

                projet.Name = request.Name;
                projet.Code = request.Code;
                projet.Label = request.Label;
                projet.Description = request.Description;

                await _repository.UpdateProjetAsync(projet);
                return projet;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}