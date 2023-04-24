using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Command
{
	public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
	{
		private readonly ILeaveRequestRepository leaveRequestRepository;
		private readonly IMapper mapper;

		public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			this.leaveRequestRepository = leaveRequestRepository;
			this.mapper = mapper;
		}
		public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await leaveRequestRepository.Get(request.Id);

			if (leaveRequest is null)
			{
				throw new NotFoundException(nameof(LeaveRequest), request.Id);
			}

			await leaveRequestRepository.Delete(leaveRequest);

			return Unit.Value;
		}
	}
}
