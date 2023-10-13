namespace Domain.DTOs;

public class PostDto
{
    public int Id { get; }
    public int SubforumId { get; }
    public string Title { get; }
    public string Context { get; }
    public string Author { get; }

    public PostDto(int id, int subforumId, string title, string context, string author)
    {
        Id = id;
        SubforumId = subforumId;
        Title = title;
        Context = context;
        Author = author;
    }
}