using System.Net;
using System.Net.Http.Json;
using swchallenge1.Presentation.Dtos;

namespace swchallenge1test;

public class GetTasksEndpointTest
{
    [Fact]
    public async Task GetTasks_WhenNoTasksExist_ReturnsEmptyList()
    {
        await using var app = await TaskApiTestApp.CreateAsync();

        var response = await app.Client.GetAsync("/api/tasks");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<List<TaskItemDto>>();
        Assert.NotNull(body);
        Assert.Empty(body);
    }

    [Fact]
    public async Task GetTasks_WhenTasksExist_ReturnsCreatedTasks()
    {
        await using var app = await TaskApiTestApp.CreateAsync();
        await app.CreateTaskAsync("Buy groceries", "Milk and bread");

        var response = await app.Client.GetAsync("/api/tasks");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<List<TaskItemDto>>();
        Assert.NotNull(body);
        Assert.Single(body);
        Assert.Equal("Buy groceries", body[0].Title);
        Assert.Equal("Milk and bread", body[0].Description);
    }
}
