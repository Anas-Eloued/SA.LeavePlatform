using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveDocHandlers
{
    public class GetLeaveDocHandler : IRequestHandler<GetLeaveDocRequest, LeaveDoc?>
    {
        private readonly ILeaveDocQueryRepository _repository;

        public GetLeaveDocHandler(ILeaveDocQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveDoc?> Handle(GetLeaveDocRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}