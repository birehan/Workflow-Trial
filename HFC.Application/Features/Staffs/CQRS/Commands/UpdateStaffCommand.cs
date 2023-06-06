
using MediatR;
using HFC.Application.Features.Staffs.DTOs;
using HFC.Application.Responses;

namespace HFC.Application.Features.Staffs.CQRS.Commands
{
    public class UpdateStaffCommand : IRequest<Result<Unit>>
    {
        public UpdateStaffDto StaffDto { get; set; }

    }
}
