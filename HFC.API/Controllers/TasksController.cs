// using API.Controllers;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using HFC.Application.Features.Tasks.CQRS.Commands;
// using HFC.Application.Features.Tasks.CQRS.Queries;
// using HFC.Application.Features.Tasks.DTOs;

// namespace TasksManagement.API.Controllers
// {
//     public class TasksController : BaseApiController
//     {
//         private readonly IMediator _mediator;

//         public TasksController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         [HttpGet]
//         public async Task<ActionResult<List<TaskDto>>> Get()
//         {
//             return HandleResult(await _mediator.Send(new GetTaskListQuery()));
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> Get(int id)
//         {
//             return HandleResult(await _mediator.Send(new GetTaskDetailQuery { Id = id }));
//         }

//         [HttpPost]
//         public async Task<IActionResult> Post([FromBody] CreateTaskDto createTask)
//         {
//             var command = new CreateTaskCommand { TaskDto = createTask };
//             return HandleResult(await _mediator.Send(command));
//         }

//         [Authorize(Policy = "IsTaskCreator")]
//         [HttpPut("{id}")]
//         public async Task<IActionResult> Put([FromBody] UpdateTaskDto taskDto, int id)
//         {
//             taskDto.Id = id;
//             var command = new UpdateTaskCommand { TaskDto = taskDto };
//             return HandleResult(await _mediator.Send(command));
//         }

//         [Authorize(Policy = "IsTaskCreator")]
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> Delete(int id)
//         {
//             var command = new DeleteTaskCommand { Id = id };
//             return HandleResult(await _mediator.Send(command));
//         }

//     }
// }