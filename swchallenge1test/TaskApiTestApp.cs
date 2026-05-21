using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using swchallenge1;
using swchallenge1.Infrastructure.Persistance;
using swchallenge1.Presentation.Dtos;

namespace swchallenge1test;

public sealed class TaskApiTestApp : IAsyncDisposable
{
    private readonly SqliteConnection _connection;
    private readonly WebApplicationFactory<Program> _factory;

    private TaskApiTestApp(SqliteConnection connection, WebApplicationFactory<Program> factory)
    {
        _connection = connection;
        _factory = factory;
        Client = factory.CreateClient();
    }

    public HttpClient Client { get; }

    public static async Task<TaskApiTestApp> CreateAsync()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll<DbContextOptions<TaskDbContext>>();
                    services.AddDbContext<TaskDbContext>(options => options.UseSqlite(connection));
                });
            });

        using var scope = factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
        await dbContext.Database.MigrateAsync();

        return new TaskApiTestApp(connection, factory);
    }

    public async Task<TaskItemDto> CreateTaskAsync(
        string title = "Buy groceries",
        string? description = "Milk and bread")
    {
        var response = await Client.PostAsJsonAsync("/api/tasks", new
        {
            title,
            description
        });

        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<TaskItemDto>())!;
    }

    public async ValueTask DisposeAsync()
    {
        Client.Dispose();
        await _factory.DisposeAsync();
        await _connection.DisposeAsync();
    }
}
