// using AutoMapper;
// using HFC.Application.Contracts.Persistence;
// using HFC.Application.Features.Tasks.CQRS.Commands;
// using HFC.Application.Features.Tasks.DTOs.Validators;
// using MediatR;
// using HFC.Application.Responses;

// namespace HFC.Application.Features.Tasks.CQRS.Handlers
// {
//     public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Result<Unit>>
//     {
//         private readonly IUnitOfWork _unitOfWork;
//         private readonly IMapper _mapper;

//         public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//         {
//             _unitOfWork = unitOfWork;
//             _mapper = mapper;
//         }

//         public async Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
//         {
//             var response = new Result<Unit>();

//             var validator = new UpdateTaskDtoValidator();
//             var validationResult = await validator.ValidateAsync(request.TaskDto);

//             if (!validationResult.IsValid)
//             {
//                 response.Success = false;
//                 response.Message = "Update Failed";
//                 response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
//             }
//             else
//             {
//                 var task = await _unitOfWork.TaskRepository.Get(request.TaskDto.Id);

//                 if (task == null)
//                 {
//                     return null;
//                 }

//                 _mapper.Map(request.TaskDto, task);

//                 await _unitOfWork.TaskRepository.Update(task);

//                 if (await _unitOfWork.Save() > 0)
//                 {
//                     response.Success = true;
//                     response.Message = "Updated Successfully";
//                     response.Value = Unit.Value;
//                 }
//                 else
//                 {
//                     response.Success = false;
//                     response.Message = "Update Failed";
//                 }
//             }

//             return response;
//         }
//     }
// }
