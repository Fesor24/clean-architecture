using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
	public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
	{
		public ILeaveTypeDtoValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("{PropertyName} can ne be empty")
				.NotNull()
				.MaximumLength(300).WithMessage("{PropertyName} has a maximum length of 300");

			RuleFor(x => x.DefaultDays)
					.GreaterThan(0).WithMessage("{PropertyName} must be at least 1");
		}
		
	}
}
