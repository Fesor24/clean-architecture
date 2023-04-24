using System;
using System.Collections.Generic;
using System.Text;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Response;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Command
{
	public class UpdateLeaveAllocationCommand : IRequest<ApiResponse>
	{
		public UpdateLeaveAllocationDto LeaveAllocation { get; set; }
	}
}
