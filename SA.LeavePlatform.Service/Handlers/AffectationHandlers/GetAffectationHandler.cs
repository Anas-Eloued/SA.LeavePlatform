using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.AffectationRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.AffectationHandlers
{
    public class GetAffectationHandler : IRequestHandler<GetAffectationRequest, Affectation?>
    {
        private readonly IAffectationQueryRepository _repository;

        public GetAffectationHandler(IAffectationQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Affectation?> Handle(GetAffectationRequest request, CancellationToken cancellationToken)
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
