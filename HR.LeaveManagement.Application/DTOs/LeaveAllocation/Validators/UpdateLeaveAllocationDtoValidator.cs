using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
	public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
	{
		private readonly ILeaveAllocationRepository leaveAllocationRepository;

		public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
		{
			this.leaveAllocationRepository = leaveAllocationRepository;

			Include(new ILeaveAllocationDtoValidator(this.leaveAllocationRepository));
		}
	}
}
