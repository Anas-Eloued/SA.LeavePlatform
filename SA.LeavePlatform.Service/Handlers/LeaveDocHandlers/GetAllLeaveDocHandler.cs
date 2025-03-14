using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.LeaveDocRequests;
using SA.LeavePlatform.Service.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.LeaveDocHandlers
{
    public class GetAllLeaveDocHandler : IRequestHandler<GetAllLeaveDocRequest, IEnumerable<LeaveDoc>>
    {
        private readonly ILeaveDocQueryRepository _repository;

        public GetAllLeaveDocHandler(ILeaveDocQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeaveDoc>> Handle(GetAllLeaveDocRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}