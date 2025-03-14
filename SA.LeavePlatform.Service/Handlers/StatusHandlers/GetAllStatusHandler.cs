using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.MediatRrequests.StatusRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.StatusHandlers
{
    public class GetAllStatusHandler : IRequestHandler<GetAllStatusRequest, IEnumerable<Status>>
    {
        private readonly IStatusQueryRepository _repository;

        public GetAllStatusHandler(IStatusQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Status>> Handle(GetAllStatusRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
