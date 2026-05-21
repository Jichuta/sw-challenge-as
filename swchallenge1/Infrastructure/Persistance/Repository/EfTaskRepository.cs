using Microsoft.EntityFrameworkCore;
using swchallenge1.Domain.Task;

namespace swchallenge1.Infrastructure.Persistance.Repository;

public class EfTaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public EfTaskRepository(TaskDbContext context)
    {
        _context = context;
    }
    public async Task<TaskItem> CreateTaskAsync(TaskItem task)
    {
        var itemSaved = await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return itemSaved.Entity;
    }

     public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
    {
        var taskList = await _context.Tasks.ToListAsync();
        return taskList.ToList();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
    {
        var task = await _context.Tasks.FindAsync(id);
        return task;
    }

    public async Task<TaskItem> UpdateTaskAsync(TaskItem task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem> DeleteTaskAsync(Guid id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            throw new Exception("Task not found");
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return task;
    }
}
