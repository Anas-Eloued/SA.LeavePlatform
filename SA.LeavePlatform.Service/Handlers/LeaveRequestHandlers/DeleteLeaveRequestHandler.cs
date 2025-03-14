using MediatR;
using SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveRequestHandlers
{
    public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequestRequest, bool>
    {
        private readonly ILeaveRequestQueryRepository _repository;

        public DeleteLeaveRequestHandler(ILeaveRequestQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteLeaveRequestAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
