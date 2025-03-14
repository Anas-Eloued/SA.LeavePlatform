using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveDocHandlers
{
    public class UpdateLeaveDocHandler : IRequestHandler<UpdateLeaveDocRequest, LeaveDoc?>
    {
        private readonly ILeaveDocQueryRepository _repository;

        public UpdateLeaveDocHandler(ILeaveDocQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveDoc?> Handle(UpdateLeaveDocRequest request, CancellationToken cancellationToken)
        {
            var leaveDoc = await _repository.GetByIdAsync(request.Id);

            if (leaveDoc == null)
            {
                return null;
            }

            leaveDoc.Name = request.Name;
            leaveDoc.Path = request.Path;
            leaveDoc.LeaveRequestId = request.LeaveRequestId;

            await _repository.UpdateLeaveDocAsync(leaveDoc);

            return leaveDoc;
        }
    }
}
