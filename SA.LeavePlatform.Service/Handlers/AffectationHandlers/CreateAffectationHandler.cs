using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.AffectationRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.AffectationHandlers
{
    public class CreateAffectationHandler : IRequestHandler<CreateAffectationRequest, Affectation?>
    {
        private readonly IAffectationQueryRepository _repository;

        public CreateAffectationHandler(IAffectationQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Affectation?> Handle(CreateAffectationRequest request, CancellationToken cancellationToken)
        {
            var affectation = new Affectation
            {
                IsSupervisor = request.IsSupervisor,
                DateDebut = request.DateDebut,
                DateFin = request.DateFin,
                ProjetId = request.ProjetId,
                EmployeeId = request.EmployeeId
            };

            await _repository.AddAffectationAsync(affectation);
            return affectation;
        }
    }
}