using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeRequestHandler : IRequestHandler<GetLeaveTypeRequest, List<LeaveTypeDto>>
	{
		private readonly ILeaveTypeRepository leaveTypeRepo;
		private readonly IMapper mapper;

		public GetLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepo, IMapper mapper)
		{
			this.leaveTypeRepo = leaveTypeRepo;
			this.mapper = mapper;
		}
		public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeRequest request, CancellationToken cancellationToken)
		{
			var leaveTypes = await leaveTypeRepo.GetAll();

			return mapper.Map<List<LeaveTypeDto>>(leaveTypes);
		}
	}
}
