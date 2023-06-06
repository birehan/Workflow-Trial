
using MediatR;
using HFC.Application.Features.Tasks.DTOs;
using HFC.Application.Responses;

namespace HFC.Application.Features.Tasks.CQRS.Queries
{
    public class GetTaskListQuery  : IRequest<Result<List<TaskDto>>>

    {
        
    }
}