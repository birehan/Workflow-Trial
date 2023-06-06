using MediatR;
using HFC.Application.Responses;

namespace HFC.Application.Features.Tasks.CQRS.Commands
{
    public class DeleteTaskCommand: IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
