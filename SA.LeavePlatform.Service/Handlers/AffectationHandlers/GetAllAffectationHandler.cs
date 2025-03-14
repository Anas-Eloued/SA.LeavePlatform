using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.AffectationRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.AffectationHandlers
{
    public class GetAllAffectationHandler : IRequestHandler<GetAllAffectationRequest, IEnumerable<Affectation>>
    {
        private readonly IAffectationQueryRepository _repository;

        public GetAllAffectationHandler(IAffectationQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Affectation>> Handle(GetAllAffectationRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}