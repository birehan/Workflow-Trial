
using MediatR;
using HFC.Application.Features.Staffs.DTOs;
using HFC.Application.Responses;

namespace HFC.Application.Features.Staffs.CQRS.Queries
{
    public class GetStaffListQuery : IRequest<Result<List<StaffDto>>>

    {

    }
}