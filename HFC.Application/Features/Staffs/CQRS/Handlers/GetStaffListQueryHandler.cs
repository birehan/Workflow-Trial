using AutoMapper;
using HFC.Application.Contracts.Persistence;
using HFC.Application.Features.Staffs.CQRS.Queries;
using HFC.Application.Features.Staffs.DTOs;
using HFC.Application.Responses;
using MediatR;

namespace HFC.Application.Features.Staffs.CQRS.Handlers
{
    public class GetStaffListQueryHandler : IRequestHandler<GetStaffListQuery, Result<List<StaffDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStaffListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<StaffDto>>> Handle(GetStaffListQuery request, CancellationToken cancellationToken)
        {
            var Staffs = await _unitOfWork.StaffRepository.GetAll();
            return Result<List<StaffDto>>.Success(_mapper.Map<List<StaffDto>>(Staffs));
        }
    }
}
