using System.Net;
using System.Net.Http.Json;
using swchallenge1.Presentation.Dtos;

namespace swchallenge1test;

public class UpdateTaskEndpointTest
{
    [Fact]
    public async Task PutTask_WithValidData_ReturnsUpdatedTask()
    {
        await using var app = await TaskApiTestApp.CreateAsync();
        var createdTask = await app.CreateTaskAsync();

        var response = await app.Client.PutAsJsonAsync($"/api/tasks/{createdTask.Id}", new
        {
            title = "Buy fruit",
            description = "Apples and bananas",
            isComplete = false
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<TaskItemDto>();
        Assert.NotNull(body);
        Assert.Equal(createdTask.Id, body.Id);
        Assert.Equal("Buy fruit", body.Title);
        Assert.Equal("Apples and bananas", body.Description);
    }

    [Fact]
    public async Task PutTask_WithoutTitle_ReturnsBadRequest()
    {
        await using var app = await TaskApiTestApp.CreateAsync();
        var createdTask = await app.CreateTaskAsync();

        var response = await app.Client.PutAsJsonAsync($"/api/tasks/{createdTask.Id}", new
        {
            description = "Missing title",
            isComplete = false
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task PutTask_WhenTaskDoesNotExist_ReturnsNotFound()
    {
        await using var app = await TaskApiTestApp.CreateAsync();

        var response = await app.Client.PutAsJsonAsync($"/api/tasks/{Guid.NewGuid()}", new
        {
            title = "Buy fruit",
            description = "Apples and bananas",
            isComplete = false
        });

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
