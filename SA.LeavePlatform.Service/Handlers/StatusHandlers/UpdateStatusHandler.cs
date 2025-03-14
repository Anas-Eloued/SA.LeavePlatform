using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.MediatRrequests.StatusRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.StatusHandlers
{
    public class UpdateStatusHandler : IRequestHandler<UpdateStatusRequest, Status?>
    {
        private readonly IStatusQueryRepository _repository;

        public UpdateStatusHandler(IStatusQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Status?> Handle(UpdateStatusRequest request, CancellationToken cancellationToken)
        {
            var status = await _repository.GetByIdAsync(request.Id);
            if (status == null)
                return null;

            status.Code = request.Code;
            status.Label = request.Label;
            status.Description = request.Description;

            // You'll need to add an update method to your repository
            await _repository.UpdateStatusAsync(status);
            return status;
        }
    }
}
