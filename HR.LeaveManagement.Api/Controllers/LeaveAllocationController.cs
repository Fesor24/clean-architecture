using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Command;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers
{
	[ApiController]
	public class LeaveAllocationController : ControllerBase
	{
		private readonly IMediator mediator;

		public LeaveAllocationController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		// GET: api/<LeaveTypesController>
		[HttpGet("api/leave-allocations/fetch")]
		public async Task<ActionResult<List<LeaveAllocationDto>>> FetchLeaveAllocations()
		{
			var leaveAllocations = await mediator.Send(new GetLeaveAllocationRequest());

			return Ok(leaveAllocations);
		}

		// GET api/<LeaveTypesController>/5
		[HttpGet("api/leave-allocation/{id}")]
		public async Task<ActionResult<LeaveTypeDto>> GetLeaveAllocation([FromRoute] int id)
		{
			var leaveAllocation = await mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });

			return Ok(leaveAllocation);

		}

		// POST api/<LeaveTypesController>
		[HttpPost("api/leave-allocation/create")]
		public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
		{
			var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };

			var response = await mediator.Send(command);

			return Ok(response);
		}

		// PUT api/<LeaveTypesController>/5
		[HttpPut("api/leave-allocation/update")]
		public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation)
		{
			var command = new UpdateLeaveAllocationCommand { LeaveAllocation = leaveAllocation };

			await mediator.Send(command);

			return NoContent();
		}

		// DELETE api/<LeaveTypesController>/5
		[HttpDelete("api/leave-allocation/delete/{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteLeaveAllocationCommand { Id = id };
			await mediator.Send(command);
			return NoContent();
		}
	}
}

