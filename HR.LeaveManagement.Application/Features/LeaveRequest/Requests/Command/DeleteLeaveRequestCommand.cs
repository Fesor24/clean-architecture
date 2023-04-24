using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Command
{
	public class DeleteLeaveRequestCommand : IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
