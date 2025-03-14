using MediatR;

namespace SA.LeavePlatform.Service.MediatRrequests.StatusRequests
{
    public class DeleteStatusRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
