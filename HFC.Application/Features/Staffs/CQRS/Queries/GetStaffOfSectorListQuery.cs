
using MediatR;
using HFC.Application.Features.Staffs.DTOs;
using HFC.Application.Responses;
using static HFC.Domain.Staff;

namespace HFC.Application.Features.Staffs.CQRS.Queries
{
    public class GetStaffOfSectorListQuery : IRequest<Result<StaffDto>>
    {
        public Sector Sector { get; set; }
    }
}