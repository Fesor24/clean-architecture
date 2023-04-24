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
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>
	{
		private readonly ILeaveAllocationRepository leaveAllocationRepository;
		private readonly IMapper mapper;

		public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			this.leaveAllocationRepository = leaveAllocationRepository;
			this.mapper = mapper;
		}
		public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
		{
			var leaveAllocationDetail = await leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

			return mapper.Map<LeaveAllocationDto>(leaveAllocationDetail);
		}
	}
}
