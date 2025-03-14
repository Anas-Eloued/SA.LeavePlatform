using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.AffectationRequests
{
    public class UpdateAffectationRequest : IRequest<Affectation?>
    {
        public int Id { get; set; }
        public bool IsSupervisor { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFin { get; set; }
        public int ProjetId { get; set; }
        public int EmployeeId { get; set; }
    }
}