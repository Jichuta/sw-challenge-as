using System.Net;
using System.Net.Http.Json;
using swchallenge1.Presentation.Dtos;

namespace swchallenge1test;

public class CompleteTaskEndpointTest
{
    [Fact]
    public async Task PatchCompleteTask_WhenTaskExists_ReturnsCompletedTask()
    {
        await using var app = await TaskApiTestApp.CreateAsync();
        var createdTask = await app.CreateTaskAsync();

        var response = await app.Client.PatchAsync($"/api/tasks/{createdTask.Id}/complete", null);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<TaskItemDto>();
        Assert.NotNull(body);
        Assert.Equal(createdTask.Id, body.Id);
        Assert.True(body.IsComplete);
    }

    [Fact]
    public async Task PatchCompleteTask_WhenTaskDoesNotExist_ReturnsNotFound()
    {
        await using var app = await TaskApiTestApp.CreateAsync();

        var response = await app.Client.PatchAsync($"/api/tasks/{Guid.NewGuid()}/complete", null);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task PatchCompleteTask_WithInvalidId_ReturnsBadRequest()
    {
        await using var app = await TaskApiTestApp.CreateAsync();

        var response = await app.Client.PatchAsync("/api/tasks/not-a-guid/complete", null);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
