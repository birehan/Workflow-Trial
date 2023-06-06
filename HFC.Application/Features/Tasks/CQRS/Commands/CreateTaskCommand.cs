using MediatR;
using HFC.Application.Features.Tasks.DTOs;
using HFC.Application.Responses;

namespace HFC.Application.Features.Tasks.CQRS.Commands
{
    public class CreateTaskCommand: IRequest<Result<int>>
    {
        public CreateTaskDto TaskDto { get; set; }
    }
}
