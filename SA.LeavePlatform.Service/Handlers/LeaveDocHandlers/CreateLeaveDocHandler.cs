using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveDocHandlers
{
    public class CreateLeaveDocHandler : IRequestHandler<CreateLeaveDocRequest, LeaveDoc?>
    {
        private readonly ILeaveDocQueryRepository _repository;

        public CreateLeaveDocHandler(ILeaveDocQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveDoc?> Handle(CreateLeaveDocRequest request, CancellationToken cancellationToken)
        {
            var leaveDoc = new LeaveDoc
            {
                Name = request.Name,
                Path = request.Path,
                LeaveRequestId = request.LeaveRequestId
            };

            await _repository.AddLeaveDocAsync(leaveDoc);
            return leaveDoc;
        }
    }
}