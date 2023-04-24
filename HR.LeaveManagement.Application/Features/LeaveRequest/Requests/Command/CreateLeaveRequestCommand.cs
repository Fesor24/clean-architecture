using System;
using System.Collections.Generic;
using System.Text;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Response;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Command
{
	public class CreateLeaveRequestCommand: IRequest<ApiResponse>
	{
		public CreateLeaveRequestDto CreateLeaveRequest { get;set; }
	}
}
