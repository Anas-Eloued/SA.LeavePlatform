using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveRequestHandlers
{
    public class GetAllLeaveRequestHandler : IRequestHandler<GetAllLeaveRequestRequest, IEnumerable<LeaveRequest>>
    {
        private readonly ILeaveRequestQueryRepository _repository;

        public GetAllLeaveRequestHandler(ILeaveRequestQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeaveRequest>> Handle(GetAllLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}