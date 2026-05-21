using System.Net;
using System.Net.Http.Json;
using swchallenge1.Presentation.Dtos;

namespace swchallenge1test
{
    public class CreateTaskEndpointTest
    {
        [Fact]
        public async Task PostTask_WithValidData_ReturnCreateTask()
        {
            await using var app = await TaskApiTestApp.CreateAsync();

            var response = await app.Client.PostAsJsonAsync("/api/tasks", new
            {
                title = "Buy groceries",
                description = "Milk and bread"
            });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var body = await response.Content.ReadFromJsonAsync<TaskItemDto>();

            Assert.NotNull(body);
            Assert.NotEqual(Guid.Empty, body.Id);
            Assert.Equal("Buy groceries", body.Title);
            Assert.Equal("Milk and bread", body.Description);
            //Assert.False(body.IsCompleted);
        }

        [Fact]
        public async Task PostTask_WithoutTitle_ReturnsBadRequest()
        {
            await using var app = await TaskApiTestApp.CreateAsync();

            var response = await app.Client.PostAsJsonAsync("/api/tasks", new
            {
                description = "Missing title"
            });

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostTask_WithTooLongTitle_ReturnsBadRequest()
        {
            await using var app = await TaskApiTestApp.CreateAsync();

            var response = await app.Client.PostAsJsonAsync("/api/tasks", new
            {
                title = new string('a', 101),
                description = "Title is too long"
            });

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
