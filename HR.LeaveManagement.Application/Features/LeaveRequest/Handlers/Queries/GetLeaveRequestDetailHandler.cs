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
	public class GetLeaveRequestDetailHandler : IRequestHandler<GetLeaveRequestDetail, LeaveRequestDto>
	{
		private readonly ILeaveRequestRepository leaveRequestRepository;
		private readonly IMapper mapper;

		public GetLeaveRequestDetailHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			this.leaveRequestRepository = leaveRequestRepository;
			this.mapper = mapper;
		}
		public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetail request, CancellationToken cancellationToken)
		{
			var leaveRequestDetail = await leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);

			return mapper.Map<LeaveRequestDto>(leaveRequestDetail);
		}
	}
}
