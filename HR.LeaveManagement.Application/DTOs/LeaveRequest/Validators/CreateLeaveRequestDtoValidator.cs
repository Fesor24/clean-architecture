using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
	public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
	{
		private readonly ILeaveRequestRepository leaveRequestRepository;

		public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
		{
			this.leaveRequestRepository = leaveRequestRepository;

			Include(new ILeaveRequestDtoValidator(this.leaveRequestRepository));
		}

	}
}
