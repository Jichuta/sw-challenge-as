using System.Net;

namespace swchallenge1test;

public class DeleteTaskEndpointTest
{
    [Fact]
    public async Task DeleteTask_WhenTaskExists_ReturnsNoContent()
    {
        await using var app = await TaskApiTestApp.CreateAsync();
        var createdTask = await app.CreateTaskAsync();

        var response = await app.Client.DeleteAsync($"/api/tasks/{createdTask.Id}");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task DeleteTask_WhenTaskExists_RemovesTask()
    {
        await using var app = await TaskApiTestApp.CreateAsync();
        var createdTask = await app.CreateTaskAsync();

        await app.Client.DeleteAsync($"/api/tasks/{createdTask.Id}");
        var response = await app.Client.GetAsync($"/api/tasks/{createdTask.Id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteTask_WhenTaskDoesNotExist_ReturnsNotFound()
    {
        await using var app = await TaskApiTestApp.CreateAsync();

        var response = await app.Client.DeleteAsync($"/api/tasks/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
