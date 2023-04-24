using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Command
{
	public class DeleteLeaveAllocationCommand : IRequest<Unit>
	{
		public int Id { get;set; }
	}
}
