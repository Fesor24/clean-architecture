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
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Command
{
	public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, ApiResponse>
	{
		private readonly ILeaveAllocationRepository leaveAllocationRepository;
		private readonly IMapper mapper;

		public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			this.leaveAllocationRepository = leaveAllocationRepository;
			this.mapper = mapper;
		}
		public async Task<ApiResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveAllocationDtoValidator(leaveAllocationRepository);

			var validatorResult = await validator.ValidateAsync(request.LeaveAllocationDto);

			if (!validatorResult.IsValid)
			{
				return new ApiResponse
				{
					ErrorMessage = "Validation error",
					ErrorResult = validatorResult.Errors.Select(x => x.ErrorMessage).ToList(),
				};
			}
				

			var leaveAllocation = mapper.Map<HR.LeaveManagement.Domain.LeaveAllocation>(request.LeaveAllocationDto);

			leaveAllocation = await leaveAllocationRepository.Add(leaveAllocation);

			return new ApiResponse
			{
				Result = new {Message = "Leave Allocation successfully created"}
			};
		}
	}
}
