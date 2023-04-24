using System;
using System.Collections.Generic;
using System.Text;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationRequest: IRequest<List<LeaveAllocationDto>>
	{
	}
}
