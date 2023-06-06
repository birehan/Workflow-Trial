
using MediatR;
using HFC.Application.Features.Tasks.DTOs;
using HFC.Application.Responses;

namespace HFC.Application.Features.Tasks.CQRS.Commands
{
    public class UpdateTaskCommand: IRequest<Result<Unit>>
    {
        public UpdateTaskDto TaskDto { get; set; }

    }
}
