using MediatR;
using SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveDocHandlers
{
    public class DeleteLeaveDocHandler : IRequestHandler<DeleteLeaveDocRequest, bool>
    {
        private readonly ILeaveDocQueryRepository _repository;

        public DeleteLeaveDocHandler(ILeaveDocQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteLeaveDocRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteLeaveDocAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
