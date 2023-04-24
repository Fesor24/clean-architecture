using System;
using System.Collections.Generic;
using System.Text;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Response;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Command
{
	public class CreateLeaveAllocationCommand : IRequest<ApiResponse>
	{
		public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
	}
}
