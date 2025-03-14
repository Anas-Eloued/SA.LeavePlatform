using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveTypeRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveTypeHandlers
{
    public class GetAllLeaveTypeHandler : IRequestHandler<GetAllLeaveTypeRequest, IEnumerable<LeaveType>>
    {
        private readonly ILeaveTypeQueryRepository _repository;

        public GetAllLeaveTypeHandler(ILeaveTypeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeaveType>> Handle(GetAllLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}