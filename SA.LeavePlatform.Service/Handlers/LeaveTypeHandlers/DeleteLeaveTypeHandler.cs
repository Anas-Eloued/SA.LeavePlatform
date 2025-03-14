using MediatR;
using SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveTypeHandlers
{
    public class DeleteLeaveTypeHandler : IRequestHandler<DeleteLeaveTypeRequest, bool>
    {
        private readonly ILeaveTypeQueryRepository _repository;

        public DeleteLeaveTypeHandler(ILeaveTypeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteLeaveTypeAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}