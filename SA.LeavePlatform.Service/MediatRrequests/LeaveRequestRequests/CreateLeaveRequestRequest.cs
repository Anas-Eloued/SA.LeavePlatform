using MediatR;
using SA.LeavePlatform.Domain.Entities;
using System;

namespace SA.LeavePlatform.Service.MediatRrequests.LeaveRequestRequests
{
    public class CreateLeaveRequestRequest : IRequest<LeaveRequest?>
    {
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFIn { get; set; }
        public int StatusId { get; set; }
        public int LeaveTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}