using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Response;
using HR.LeaveManagement.Domain;
using MediatR;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Command
{
	public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, ApiResponse>
	{
		private readonly ILeaveRequestRepository leaveRequestRepository;
		
		private readonly IMapper mapper;
		private readonly IEmailSender emailSender;

		public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender emailSender)
		{
			this.leaveRequestRepository = leaveRequestRepository;
			this.mapper = mapper;
			this.emailSender = emailSender;
		}
		public async Task<ApiResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveRequestDtoValidator(leaveRequestRepository);

			var validatorResult = await validator.ValidateAsync(request.CreateLeaveRequest, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new ApiResponse
				{
					ErrorMessage = "Validator error",
					ErrorResult = validatorResult.Errors.Select(x => x.ErrorMessage).ToList()
				};
			}
				

			var leaveRequest = mapper.Map<HR.LeaveManagement.Domain.LeaveRequest>(request.CreateLeaveRequest);

			leaveRequest = await leaveRequestRepository.Add(leaveRequest);

			var email = new Email
			{
				Body = $"Your leave request from {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been submitted",
				To = "employee@org.com",
				Subject = "Leave request submitted"
			};

			try
			{
				await emailSender.SendEmailAsync(email);
			}

			catch (Exception)
			{

			}

			return new ApiResponse
			{
				Result = new {Message = "Leave request successfully added"}
			};
		}
	}
}
