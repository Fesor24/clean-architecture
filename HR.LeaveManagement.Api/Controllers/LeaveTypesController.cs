using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
	[ApiController]
	public class LeaveTypesController : ControllerBase
	{
		private readonly IMediator mediator;

		public LeaveTypesController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		// GET: api/<LeaveTypesController>
		[HttpGet("api/leave-types/fetch")]
		public async Task<ActionResult<List<LeaveTypeDto>>> FetchLeaveTypes()
		{
			var leaveTypes = await mediator.Send(new GetLeaveTypeRequest());

			return Ok(leaveTypes);
		}

		// GET api/<LeaveTypesController>/5
		[HttpGet("api/leave-type/{id}")]
		public async Task<ActionResult<LeaveTypeDto>> GetLeaveType([FromRoute] int id)
		{
			var leaveType = await mediator.Send(new GetLeaveTypeDetailRequest { Id = id});

			return Ok(leaveType);

		}

		// POST api/<LeaveTypesController>
		[HttpPost("api/leave-type/create")]
		public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
		{
			var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
			
			var response = await mediator.Send(command);

			return Ok(response);
		}

		// PUT api/<LeaveTypesController>/5
		[HttpPut("api/leave-type/update")]
		public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
		{
			var command = new UpdateLeaveTypeCommand { LeaveType = leaveType };

			await mediator.Send(command);

			return NoContent();
		}

		// DELETE api/<LeaveTypesController>/5
		[HttpDelete("api/leave-type/delete/{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteLeaveTypeCommand { Id = id };
			await mediator.Send(command);
			return NoContent();
		}
	}
}
