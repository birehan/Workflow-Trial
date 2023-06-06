
using MediatR;
using HFC.Application.Features.Tasks.DTOs;
using HFC.Application.Responses;

namespace HFC.Application.Features.Tasks.CQRS.Queries
{
    public class GetTaskDetailQuery : IRequest<Result<TaskDto>>
    {
        public int Id { get; set; }
    }
}