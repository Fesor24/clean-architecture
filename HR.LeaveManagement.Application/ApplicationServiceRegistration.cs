using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Application
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddMediatR(options =>
			{
				options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			});

			return services;
		}
	}
}
