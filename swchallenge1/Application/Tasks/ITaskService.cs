using swchallenge1.Domain.Task;
using swchallenge1.Presentation.Dtos;

namespace swchallenge1.Application.Tasks
{
    public interface ITaskService
    {
        public Task<TaskItem> CreateTaskAsync(CreateTaskRequest request);
        public Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        public Task<TaskItem?> GetTaskByIdAsync(Guid id);
        public Task<TaskItem> UpdateTaskAsync(Guid id, UpdateTaskRequest request);
        public Task DeleteTaskAsync(Guid id);
        public Task<TaskItem> MarkTaskAsCompleteAsync(Guid id);
    }
}
