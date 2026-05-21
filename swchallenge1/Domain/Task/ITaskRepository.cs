namespace swchallenge1.Domain.Task
{
    public interface ITaskRepository
    {
        public Task<TaskItem> CreateTaskAsync(TaskItem task);
        public Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        public Task<TaskItem?> GetTaskByIdAsync(Guid id);
        public Task<TaskItem> UpdateTaskAsync(TaskItem task);
        public Task<TaskItem> DeleteTaskAsync(Guid id);
    }
}