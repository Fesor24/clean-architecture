using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Command;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers
{
	[ApiController]
	public class LeaveRequestsController : ControllerBase
	{
		private readonly IMediator mediator;

		public LeaveRequestsController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		// GET: api/<LeaveTypesController>
		[HttpGet("api/leave-requests/fetch")]
		public async Task<ActionResult<List<LeaveTypeDto>>> FetchLeaveRequests()
		{
			var leaveTypes = await mediator.Send(new GetLeaveRequest());

			return Ok(leaveTypes);
		}

		// GET api/<LeaveTypesController>/5
		[HttpGet("api/leave-request/{id}")]
		public async Task<ActionResult<LeaveTypeDto>> GetLeaveRequest([FromRoute] int id)
		{
			var leaveRequest = await mediator.Send(new GetLeaveRequestDetail { Id = id });

			return Ok(leaveRequest);

		}

		// POST api/<LeaveTypesController>
		[HttpPost("api/leave-request/create")]
		public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
		{
			var command = new CreateLeaveRequestCommand { CreateLeaveRequest = leaveRequest };

			var response = await mediator.Send(command);

			return Ok(response);
		}

		// PUT api/<LeaveTypesController>/5
		[HttpPut("api/leave-request/update/{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequestDto)
		{
			var command = new UpdateLeaveRequestCommand {Id = id, LeaveRequestDto = leaveRequestDto };

			await mediator.Send(command);

			return NoContent();
		}

		[HttpPut("api/leave-request/update-approval/{id}")]
		public async Task<ActionResult> UpdateApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto approvalDto)
		{
			var command = new UpdateLeaveRequestCommand {Id = id, ChangeLeaveRequest = approvalDto };

			await mediator.Send(command);

			return NoContent();
		}

		// DELETE api/<LeaveTypesController>/5
		[HttpDelete("api/leave-request/delete/{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteLeaveRequestCommand { Id = id };
			await mediator.Send(command);
			return NoContent();
		}
	}
}
