using swchallenge1.Domain.Task;
using swchallenge1.Presentation.Dtos;

namespace swchallenge1.Application.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ILogger<TaskService> _logger;
        private readonly ITaskRepository _taskRepository;

        public TaskService(ILogger<TaskService> logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _taskRepository = taskRepository;
        }

        public async Task<TaskItem> CreateTaskAsync(CreateTaskRequest request)
        {
            _logger.LogInformation("Creating task: {Request}", request);
            // Here you would add logic to save the task to a database or other storage
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description
            };
            return await _taskRepository.CreateTaskAsync(task);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task<TaskItem> UpdateTaskAsync(Guid id, UpdateTaskRequest request)
        {
            var existingTask = await _taskRepository.GetTaskByIdAsync(id);
            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }

            existingTask.Title = request.Title;
            existingTask.Description = request.Description;
            existingTask.IsComplete = request.IsComplete;

            var result = await _taskRepository.UpdateTaskAsync(existingTask);

            return result;
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var existingTask = await _taskRepository.GetTaskByIdAsync(id);
            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }

            await _taskRepository.DeleteTaskAsync(existingTask.Id);

            return;
        }

        public async Task<TaskItem> MarkTaskAsCompleteAsync(Guid id)
        {
            var existingTask = await _taskRepository.GetTaskByIdAsync(id);
            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }

            existingTask.IsComplete = true;

            var result = await _taskRepository.UpdateTaskAsync(existingTask);

            return result;
        }
    }
}