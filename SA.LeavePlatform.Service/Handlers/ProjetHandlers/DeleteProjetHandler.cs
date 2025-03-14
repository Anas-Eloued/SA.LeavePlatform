using MediatR;
using SA.LeavePlatform.Service.MediatRrequests.ProjetRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.ProjetHandlers
{
    public class DeleteProjetHandler : IRequestHandler<DeleteProjetRequest, bool>
    {
        private readonly IProjetQueryRepository _repository;

        public DeleteProjetHandler(IProjetQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProjetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteProjetAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}