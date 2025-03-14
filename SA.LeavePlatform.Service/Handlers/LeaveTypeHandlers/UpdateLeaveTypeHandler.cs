using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveTypeHandlers
{
    public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveTypeRequest, LeaveType?>
    {
        private readonly ILeaveTypeQueryRepository _repository;

        public UpdateLeaveTypeHandler(ILeaveTypeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveType?> Handle(UpdateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var leaveType = await _repository.GetByIdAsync(request.Id);

                leaveType.Code = request.Code;
                leaveType.Label = request.Label;
                leaveType.Description = request.Description;

                await _repository.UpdateLeaveTypeAsync(leaveType);
                return leaveType;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}