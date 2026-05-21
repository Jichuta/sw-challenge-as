using System.Net;
using System.Net.Http.Json;
using swchallenge1.Presentation.Dtos;

namespace swchallenge1test;

public class GetTaskByIdEndpointTest
{
    [Fact]
    public async Task GetTaskById_WhenTaskExists_ReturnsTask()
    {
        await using var app = await TaskApiTestApp.CreateAsync();
        var createdTask = await app.CreateTaskAsync("Buy groceries", "Milk and bread");

        var response = await app.Client.GetAsync($"/api/tasks/{createdTask.Id}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<TaskItemDto>();
        Assert.NotNull(body);
        Assert.Equal(createdTask.Id, body.Id);
        Assert.Equal("Buy groceries", body.Title);
    }

    [Fact]
    public async Task GetTaskById_WhenTaskDoesNotExist_ReturnsNotFound()
    {
        await using var app = await TaskApiTestApp.CreateAsync();

        var response = await app.Client.GetAsync($"/api/tasks/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetTaskById_WithInvalidId_ReturnsBadRequest()
    {
        await using var app = await TaskApiTestApp.CreateAsync();

        var response = await app.Client.GetAsync("/api/tasks/not-a-guid");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
