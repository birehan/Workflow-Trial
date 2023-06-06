using MediatR;
using HFC.Application.Features.Staffs.DTOs;
using HFC.Application.Responses;

namespace HFC.Application.Features.Staffs.CQRS.Commands
{
    public class CreateStaffCommand : IRequest<Result<Guid>>
    {
        public CreateStaffDto StaffDto { get; set; }
    }
}
