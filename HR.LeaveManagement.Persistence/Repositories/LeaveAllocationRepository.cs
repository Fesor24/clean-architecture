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
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		private readonly LeaveManagementDbContext context;

		public LeaveAllocationRepository(LeaveManagementDbContext context): base(context)
		{
			this.context = context;
		}
		public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
		{
			return await context.LeaveAllocations
				.Include(x => x.LeaveType)
				.FirstOrDefaultAsync(x => x.Id== id);
		}

		public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
		{
			return await context.LeaveAllocations
				.Include(x => x.LeaveType)
				.ToListAsync();
		}
	}
}
