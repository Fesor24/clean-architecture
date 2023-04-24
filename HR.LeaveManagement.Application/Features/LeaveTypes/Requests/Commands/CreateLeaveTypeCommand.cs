using System;
using System.Collections.Generic;
using System.Text;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Response;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
	public class CreateLeaveTypeCommand: IRequest<ApiResponse>
	{
		public CreateLeaveTypeDto LeaveTypeDto { get; set; }	
	}
}
