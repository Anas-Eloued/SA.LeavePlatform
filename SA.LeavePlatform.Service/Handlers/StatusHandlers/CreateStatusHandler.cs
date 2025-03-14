using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.MediatRrequests.StatusRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.StatusHandlers
{
    public class CreateStatusHandler : IRequestHandler<CreateStatusRequest, Status?>
    {
        private readonly IStatusQueryRepository _repository;

        public CreateStatusHandler(IStatusQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Status?> Handle(CreateStatusRequest request, CancellationToken cancellationToken)
        {
            var status = new Status
            {
                Code = request.Code,
                Label = request.Label,
                Description = request.Description
            };

            await _repository.AddStatusAsync(status);
            return status;
        }
    }
}
