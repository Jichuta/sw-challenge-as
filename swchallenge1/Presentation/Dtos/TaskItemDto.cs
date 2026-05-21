namespace swchallenge1.Presentation.Dtos;
public class TaskItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsComplete { get; set; }
}