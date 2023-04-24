using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
	public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
	{
		private readonly ILeaveRequestRepository leaveRequestRepository;

		public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
		{
			this.leaveRequestRepository = leaveRequestRepository;

			RuleFor(x => x.StartDate)
				.LessThan(x => x.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

			RuleFor(x => x.EndDate)
				.GreaterThan(x => x.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

			RuleFor(x => x.LeaveTypeId)
				.GreaterThan(0)
			.MustAsync(async (id, token) =>
				{
					var leaveTypeIdExists = await this.leaveRequestRepository.Exists(id);
					return leaveTypeIdExists;
				})
				.WithMessage("{PropertyName does not exist}");

			
		}
	}
}
