using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Queries;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationRequestHandler : IRequestHandler<GetLeaveAllocationRequest, List<LeaveAllocationDto>>
	{
		private readonly ILeaveAllocationRepository leaveAllocationRepository;
		private readonly IMapper mapper;

		public GetLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			this.leaveAllocationRepository = leaveAllocationRepository;
			this.mapper = mapper;
		}
		public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationRequest request, CancellationToken cancellationToken)
		{
			var leaveAllocations = await leaveAllocationRepository.GetAll();

			return mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
		}
	}
}
