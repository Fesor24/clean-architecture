using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Response;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Command
{ 
	public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, ApiResponse>
	{
		private readonly ILeaveAllocationRepository leaveAllocationRepository;
		private readonly IMapper mapper;

		public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			this.leaveAllocationRepository = leaveAllocationRepository;
			this.mapper = mapper;
		}
		public async Task<ApiResponse> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateLeaveAllocationDtoValidator(leaveAllocationRepository);

			var validatorResult = await validator.ValidateAsync(request.LeaveAllocation);

			if (!validatorResult.IsValid)
			{
				return new ApiResponse
				{
					ErrorMessage = "Validation error",
					ErrorResult = validatorResult.Errors.Select(x => x.ErrorMessage).ToList()
				};
			}
			

			var leaveAllocation = await leaveAllocationRepository.Get(request.LeaveAllocation.Id);

			mapper.Map(request.LeaveAllocation, leaveAllocation);

			await leaveAllocationRepository.Update(leaveAllocation);

			return new ApiResponse
			{
				Result = new {Message = "Leave allocation successfully updated"}
			};
		}
	}
}
