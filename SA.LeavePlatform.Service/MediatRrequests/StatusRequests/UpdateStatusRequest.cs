using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.StatusRequests
{
    public class UpdateStatusRequest : IRequest<Status?>
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Label { get; set; }
        public string? Description { get; set; }
    }
}
