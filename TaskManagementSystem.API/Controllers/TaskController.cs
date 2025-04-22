using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Features.Tasks.Commands;
using TaskManagementSystem.Application.Features.Tasks.Queries;

namespace TaskManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/task
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTasks), new { id = taskId }, taskId);
        }

        // GET: api/task?projectId=...&status=...&assignedToId=...
        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] GetTaskListQuery query)
        {
            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }

        // PUT: api/task/{id}/status
        //[HttpPut("{id}/status")]
        //public async Task<IActionResult> UpdateTaskStatus(Guid id, [FromBody] UpdateTaskStatusCommand command)
        //{
        //    if (id != command.TaskId)
        //        return BadRequest("Invalid TaskId");

        //    await _mediator.Send(command);
        //    return NoContent();
        //}
    }
}
