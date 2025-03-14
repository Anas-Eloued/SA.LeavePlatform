using MediatR;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.MediatRrequests.StatusRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.StatusHandlers
{
    public class DeleteStatusHandler : IRequestHandler<DeleteStatusRequest, bool>
    {
        private readonly IStatusQueryRepository _repository;

        public DeleteStatusHandler(IStatusQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteStatusRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteStatusAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
