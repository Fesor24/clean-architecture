using System;
using System.Collections.Generic;
using System.Text;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Response;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
	public class UpdateLeaveTypeCommand : IRequest<ApiResponse>
	{
		public LeaveTypeDto LeaveType { get;set; }
	}
}
