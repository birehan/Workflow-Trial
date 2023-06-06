// using AutoMapper;
// using HFC.Application.Contracts.Persistence;
// using HFC.Application.Features.Tasks.CQRS.Queries;
// using HFC.Application.Features.Tasks.DTOs;
// using MediatR;
// using HFC.Application.Responses;

// namespace HFC.Application.Features.Tasks.CQRS.Handlers
// {
//     public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, Result<TaskDto>>
//     {
//         private readonly IUnitOfWork _unitOfWork;
//         private readonly IMapper _mapper;

//         public GetTaskDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
//         {
//             _unitOfWork = unitOfWork;
//             _mapper = mapper;
//         }

//         public async Task<Result<TaskDto>> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
//         {
//             var response = new Result<TaskDto>();
//             var task = await _unitOfWork.TaskRepository.Get(request.Id);

//             if (task == null) return null;

//             response.Success = true;
//             response.Message = "Fetch Success";
//             response.Value = _mapper.Map<TaskDto>(task);

//             return response;
//         }
//     }
// }