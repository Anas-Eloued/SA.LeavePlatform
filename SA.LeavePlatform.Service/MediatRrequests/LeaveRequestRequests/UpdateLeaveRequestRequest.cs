using MediatR;
using SA.LeavePlatform.Domain.Entities;
using System;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests
{
    public class UpdateLeaveRequestRequest : IRequest<LeaveRequest?>
    {
        public int Id { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFIn { get; set; }
        public int StatusId { get; set; }
        public int LeaveTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}