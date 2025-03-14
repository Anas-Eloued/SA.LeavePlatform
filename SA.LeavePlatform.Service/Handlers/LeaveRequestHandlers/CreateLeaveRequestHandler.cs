using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveRequestHandlers
{
    public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequestRequest, LeaveRequest?>
    {
        private readonly ILeaveRequestQueryRepository _repository;

        public CreateLeaveRequestHandler(ILeaveRequestQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveRequest?> Handle(CreateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = new LeaveRequest
            {
                DateDebut = request.DateDebut,
                DateFIn = request.DateFIn,
                StatusId = request.StatusId,
                LeaveTypeId = request.LeaveTypeId,
                EmployeeId = request.EmployeeId
            };

            await _repository.AddLeaveRequestAsync(leaveRequest);
            return leaveRequest;
        }
    }
}