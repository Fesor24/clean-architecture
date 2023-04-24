﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
	public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest>
	{
		Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

		Task<List<LeaveRequest>> GetLeaveRequestWithDetails();

		Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);

		
	}
}
