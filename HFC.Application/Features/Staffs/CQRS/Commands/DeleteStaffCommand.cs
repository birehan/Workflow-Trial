using MediatR;
using HFC.Application.Responses;

namespace HFC.Application.Features.Staffs.CQRS.Commands
{
    public class DeleteStaffCommand: IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
