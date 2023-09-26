namespace Domain.DTOs;

public class PostDto
{
    public string Title { get; }
    public string Context { get; }
    public User Author { get; }

    public PostDto(string title, string context, User author)
    {
        Title = title;
        Context = context;
        Author = author;
    }
}