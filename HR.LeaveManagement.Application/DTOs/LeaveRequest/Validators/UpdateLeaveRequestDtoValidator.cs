using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
	public class UpdateLeaveRequestDtoValidator: AbstractValidator<UpdateLeaveRequestDto>
	{
		private readonly ILeaveRequestRepository leaveRequestRepository;

		public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
		{
			this.leaveRequestRepository = leaveRequestRepository;

			Include(new ILeaveRequestDtoValidator(this.leaveRequestRepository));

			RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must not be null");
		}
	}
}
