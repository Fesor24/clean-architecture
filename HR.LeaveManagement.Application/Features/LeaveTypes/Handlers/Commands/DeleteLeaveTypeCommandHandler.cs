using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
	public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
	{
		private readonly ILeaveTypeRepository leaveTypeRepository;
		private readonly IMapper mapper;

		public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			this.leaveTypeRepository = leaveTypeRepository;
			this.mapper = mapper;
		}
		public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var leaveType = await leaveTypeRepository.Get(request.Id);

			if (leaveType is null)
			{
				throw new NotFoundException(nameof(LeaveTypes), request.Id);
			}

			await leaveTypeRepository.Delete(leaveType);

			return Unit.Value;
		}
	}
}
