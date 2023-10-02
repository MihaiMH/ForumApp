namespace Domain.DTOs;

public class PostUpdateDto
{
    public int Id { get; }
    public string Title { get; }
    public string Context { get; }

    public int SubForumId { get; set; }

    public PostUpdateDto(int id, string title, string context, int subForumId)
    {
        Id = id;
        Title = title;
        Context = context;
        SubForumId = subForumId;
    }
}