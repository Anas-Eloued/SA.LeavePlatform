using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveRequestHandlers
{
    public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequestRequest, LeaveRequest?>
    {
        private readonly ILeaveRequestQueryRepository _repository;

        public UpdateLeaveRequestHandler(ILeaveRequestQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveRequest?> Handle(UpdateLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var leaveRequest = await _repository.GetByIdAsync(request.Id);

                leaveRequest.DateDebut = request.DateDebut;
                leaveRequest.DateFIn = request.DateFIn;
                leaveRequest.StatusId = request.StatusId;
                leaveRequest.LeaveTypeId = request.LeaveTypeId;
                leaveRequest.EmployeeId = request.EmployeeId;

                await _repository.UpdateLeaveRequestAsync(leaveRequest);
                return leaveRequest;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}