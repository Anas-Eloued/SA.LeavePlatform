using MediatR;
using SA.LeavePlatform.Service.MediatRrequests.AffectationRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.AffectationHandlers
{
    public class DeleteAffectationHandler : IRequestHandler<DeleteAffectationRequest, bool>
    {
        private readonly IAffectationQueryRepository _repository;

        public DeleteAffectationHandler(IAffectationQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteAffectationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteAffectationAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}