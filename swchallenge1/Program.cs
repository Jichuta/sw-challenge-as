using swchallenge1.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using swchallenge1.Domain.Task;
using swchallenge1.Infrastructure.Persistance.Repository;
using swchallenge1.Application.Tasks;

namespace swchallenge1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<ITaskRepository, EfTaskRepository>();
        builder.Services.AddScoped<ITaskService, TaskService>();

        builder.Services.AddDbContext<TaskDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
