using Microsoft.AspNetCore.Mvc;
using swchallenge1.Application.Tasks;
using swchallenge1.Domain.Task;
using swchallenge1.Presentation.Dtos;
using swchallenge1.Presentation.validation;

namespace swchallenge1.Presentation.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> Get()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return tasks.Select(t => new TaskItemDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsComplete = t.IsComplete
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskRequest value)
        {
            _logger.LogInformation("Task created: {Value}", value);
            if (!CreateTaskRequestValidation.Validate(value, out var errorMessage))
            {
                _logger.LogWarning("Validation failed: {ErrorMessage}", errorMessage);
                return BadRequest(errorMessage);
            }

            var createdTask = await _taskService.CreateTaskAsync(value);
            return Created($"/api/tasks/{createdTask.Id}", createdTask);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            var taskItemDto = new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsComplete = task.IsComplete
            };

            return Ok(taskItemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskRequest request)
        {
            if (!UpdateTaskRequestValidation.Validate(request, out var errorMessage))
            {
                _logger.LogWarning("Validation failed: {ErrorMessage}", errorMessage);
                return BadRequest(errorMessage);
            }

            try
            {
                var result = await _taskService.UpdateTaskAsync(id, request);
                return Ok(result);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating task with id {Id}", id);
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            try
            {
                await _taskService.DeleteTaskAsync(id);
                return NoContent();
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting task with id {Id}", id);
                return NotFound();
            }
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> MarkTaskAsComplete(Guid id)
        {
            try
            {
                var result = await _taskService.MarkTaskAsCompleteAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking task as complete with id {Id}", id);
                return NotFound();
            }
        }
    }
}
