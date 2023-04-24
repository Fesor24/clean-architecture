﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
	public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
	{
		Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);

		Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
	}
}
