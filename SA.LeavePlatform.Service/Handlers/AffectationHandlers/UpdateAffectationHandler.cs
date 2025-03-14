using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.AffectationRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.AffectationHandlers
{
    public class UpdateAffectationHandler : IRequestHandler<UpdateAffectationRequest, Affectation?>
    {
        private readonly IAffectationQueryRepository _repository;

        public UpdateAffectationHandler(IAffectationQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Affectation?> Handle(UpdateAffectationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var affectation = await _repository.GetByIdAsync(request.Id);

                affectation.IsSupervisor = request.IsSupervisor;
                affectation.DateDebut = request.DateDebut;
                affectation.DateFin = request.DateFin;
                affectation.ProjetId = request.ProjetId;
                affectation.EmployeeId = request.EmployeeId;

                await _repository.UpdateAffectationAsync(affectation);
                return affectation;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}