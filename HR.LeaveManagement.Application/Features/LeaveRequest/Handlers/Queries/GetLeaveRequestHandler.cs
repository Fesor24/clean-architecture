using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Queries;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Queries
{
	public class GetLeaveRequestHandler : IRequestHandler<GetLeaveRequest, List<LeaveRequestListDto>>
	{
		private readonly ILeaveRequestRepository leaveRequestRepository;
		private readonly IMapper mapper;

		public GetLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			this.leaveRequestRepository = leaveRequestRepository;
			this.mapper = mapper;
		}
		public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequest request, CancellationToken cancellationToken)
		{
			var leaveRequests = await leaveRequestRepository.GetLeaveRequestWithDetails();

			return mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
		}
	}
}
