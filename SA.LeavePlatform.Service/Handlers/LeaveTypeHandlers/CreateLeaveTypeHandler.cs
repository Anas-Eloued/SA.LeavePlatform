using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveTypeHandlers
{
    public class CreateLeaveTypeHandler : IRequestHandler<CreateLeaveTypeRequest, LeaveType?>
    {
        private readonly ILeaveTypeQueryRepository _repository;

        public CreateLeaveTypeHandler(ILeaveTypeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveType?> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = new LeaveType
            {
                Code = request.Code,
                Label = request.Label,
                Description = request.Description
            };

            await _repository.AddLeaveTypeAsync(leaveType);
            return leaveType;
        }
    }
}