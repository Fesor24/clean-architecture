using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
	public class ILeaveAllocationDtoValidator: AbstractValidator<ILeaveAllocationDto>
	{
		private readonly ILeaveAllocationRepository leaveAllocationRepository;

		public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
		{
			this.leaveAllocationRepository = leaveAllocationRepository;

			RuleFor(x => x.Period)
				.GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

			RuleFor(x => x.NumberOfDays)
				.GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

			RuleFor(x => x.LeaveTypeId)
				.GreaterThan(0)
			.MustAsync(async (id, token) =>
			{
					var leaveTypeExists = await this.leaveAllocationRepository.Exists(id);
					return leaveTypeExists;
				})
				.WithMessage("{PropertyName} does not exist");
			
		}
	}
}
