using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveRequestHandlers
{
    public class GetLeaveRequestHandler : IRequestHandler<GetLeaveRequestRequest, LeaveRequest?>
    {
        private readonly ILeaveRequestQueryRepository _repository;

        public GetLeaveRequestHandler(ILeaveRequestQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeaveRequest?> Handle(GetLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.GetByIdAsync(request.Id);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}