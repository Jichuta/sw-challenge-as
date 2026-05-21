using Microsoft.EntityFrameworkCore;
using swchallenge1.Domain.Task;


namespace swchallenge1.Infrastructure.Persistance
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}