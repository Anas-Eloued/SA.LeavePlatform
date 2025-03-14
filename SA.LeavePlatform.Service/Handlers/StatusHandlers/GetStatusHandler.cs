using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.MediatRrequests.StatusRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.StatusHandlers
{
    public class GetStatusHandler : IRequestHandler<GetStatusRequest, Status?>
    {
        private readonly IStatusQueryRepository _repository;

        public GetStatusHandler(IStatusQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Status?> Handle(GetStatusRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
