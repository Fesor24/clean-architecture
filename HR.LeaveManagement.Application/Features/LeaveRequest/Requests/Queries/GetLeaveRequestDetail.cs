﻿using System;
using System.Collections.Generic;
using System.Text;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Queries
{
	public class GetLeaveRequestDetail : IRequest<LeaveRequestDto>
	{
		public int Id { get; set; }
	}
}
