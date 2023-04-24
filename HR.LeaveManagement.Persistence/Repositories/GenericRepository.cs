using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly LeaveManagementDbContext context;

		public GenericRepository(LeaveManagementDbContext context)
		{
			this.context = context;
		}
		public async Task<T> Add(T entity)
		{
			await context.AddAsync(entity);

			await context.SaveChangesAsync();

			return entity;
		}

		public async Task Delete(T entity)
		{
			context.Set<T>().Remove(entity);

			await context.SaveChangesAsync();
		}

		public async Task<bool> Exists(int id)
		{
			var entity = await Get(id);

			return entity != null;
		}

		public async Task<T> Get(int id)
		{
			var entity = await context.Set<T>().FindAsync(id);

			return entity;
		}

		public async Task<IReadOnlyList<T>> GetAll()
		{
			return await context.Set<T>().ToListAsync();
		}

		public async Task Update(T entity)
		{
			context.Entry(entity).State = EntityState.Modified;

			await context.SaveChangesAsync();
		}
	}
}
