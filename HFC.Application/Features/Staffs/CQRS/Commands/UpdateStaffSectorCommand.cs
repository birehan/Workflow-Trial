using HFC.Application.Responses;
using MediatR;
using static HFC.Domain.Staff;

namespace HFC.Application.Features.Staffs.CQRS.Commands
{
    public class UpdateStaffSectorCommand : IRequest<Result<Unit>>
    {
        public string Id { get; set; }
        public Sector Sector { get; set; }
    }
}
