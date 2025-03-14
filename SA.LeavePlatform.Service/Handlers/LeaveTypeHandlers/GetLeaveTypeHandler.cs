using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveTypeHandlers
{
    public class GetLeaveTypeHandler : IRequestHandler<GetLeaveTypeRequest, LeaveType?>
    {
        private readonly ILeaveTypeQueryRepository _repository;

        public GetLeaveTypeHandler(ILeaveTypeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveType?> Handle(GetLeaveTypeRequest request, CancellationToken cancellationToken)
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