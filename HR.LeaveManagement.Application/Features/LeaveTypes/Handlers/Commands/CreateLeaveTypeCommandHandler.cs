using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Response;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, ApiResponse>
	{
		private readonly ILeaveTypeRepository leaveTypeRepository;
		private readonly IMapper mapper;

		public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			this.leaveTypeRepository = leaveTypeRepository;
			this.mapper = mapper;
		}
		public async Task<ApiResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveTypeDtoValidator();

			var validatorResult = await validator.ValidateAsync(request.LeaveTypeDto);

			if (!validatorResult.IsValid)
			{
				return new ApiResponse
				{
					ErrorMessage = "Validation error",
					ErrorResult = validatorResult.Errors.Select(x => x.ErrorMessage).ToList()
				};
			}

			var leaveType = mapper.Map<LeaveType>(request.LeaveTypeDto);

			leaveType = await leaveTypeRepository.Add(leaveType);

			return new ApiResponse
			{
				Result = new {Message = "Leave type repository successfully added"}
			};
		}
	}
}
