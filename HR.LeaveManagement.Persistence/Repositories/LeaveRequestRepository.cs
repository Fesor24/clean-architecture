using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		private readonly LeaveManagementDbContext context;

		public LeaveRequestRepository(LeaveManagementDbContext context) : base(context)
		{
			this.context = context;
		}
		public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
		{
			leaveRequest.Approved = approvalStatus; ;

			context.Entry(leaveRequest).State = EntityState.Modified;

			await context.SaveChangesAsync();
		}

		public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
		{
			return context.LeaveRequests
				.Include(x => x.LeaveType)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
		{
			return context.LeaveRequests
				.Include(x => x.LeaveType)
				.ToListAsync();
		}
	}
}
