namespace Domain.DTOs;

public class PostDto
{
    public int Id { get; }
    public int SubforumId { get; }
    public string Title { get; }
    public string Context { get; }
    public User Author { get; }

    public PostDto(int id, int subforumId, string title, string context, User author)
    {
        Id = id;
        SubforumId = subforumId;
        Title = title;
        Context = context;
        Author = author;
    }
}