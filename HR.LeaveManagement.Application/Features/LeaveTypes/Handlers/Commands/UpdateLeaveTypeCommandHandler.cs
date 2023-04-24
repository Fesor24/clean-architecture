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
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
	public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, ApiResponse>
	{
		private readonly ILeaveTypeRepository leaveTypeRepository;
		private readonly IMapper mapper;

		public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			this.leaveTypeRepository = leaveTypeRepository;
			this.mapper = mapper;
		}
		public async Task<ApiResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateLeaveTypeDtoValidator();

			var validatorResult = await validator.ValidateAsync(request.LeaveType, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new ApiResponse
				{
					ErrorMessage = "Validation error",
					ErrorResult = validatorResult.Errors.Select(x => x.ErrorMessage).ToList()
				};
			}

			var leaveType = await leaveTypeRepository.Get(request.LeaveType.Id);

			mapper.Map(request.LeaveType, leaveType);

			await leaveTypeRepository.Update(leaveType);

			return new ApiResponse
			{
				Result = new {Message = "Leave type successfully updated"}
			};
		}
	}
}
