using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration config)
		{
			services.Configure<EmailSettings>(config.GetSection("EmailSettings"));

			services.AddTransient<IEmailSender, EmailSender>();

			return services;
		}
	}
}
