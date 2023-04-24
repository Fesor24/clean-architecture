using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Command
{
	public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
	{
		private readonly ILeaveAllocationRepository leaveAllocationRepository;
		private readonly IMapper mapper;

		public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			this.leaveAllocationRepository = leaveAllocationRepository;
			this.mapper = mapper;
		}
		public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await leaveAllocationRepository.Get(request.Id);

			if(leaveAllocation is null)
			{
				throw new NotFoundException(nameof(LeaveAllocation), request.Id);
			}

			await leaveAllocationRepository.Delete(leaveAllocation);

			return Unit.Value;
		}
	}
}
