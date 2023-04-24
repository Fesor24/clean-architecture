using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Response;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Command
{
	public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, ApiResponse>
	{
		private readonly ILeaveRequestRepository leaveRequestRepository;
		private readonly IMapper mapper;

		public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			this.leaveRequestRepository = leaveRequestRepository;
			this.mapper = mapper;
		}
		public async Task<ApiResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateLeaveRequestDtoValidator(leaveRequestRepository);

			var validatorResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new ApiResponse
				{
					ErrorMessage = "Validation error",
					ErrorResult = validatorResult.Errors.Select(x => x.ErrorMessage).ToList()
				};
			}

			var leaveRequest = await leaveRequestRepository.Get(request.Id);

			if (request.LeaveRequestDto != null)
			{
				mapper.Map(request.LeaveRequestDto, leaveRequest);

				await leaveRequestRepository.Update(leaveRequest);
			}

			else if(request.ChangeLeaveRequest != null)
			{
				await leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequest.Approved);
			}

			

			return new ApiResponse
			{
				Result = new {Message = "Update successful"}
			};
		}
	}
}
