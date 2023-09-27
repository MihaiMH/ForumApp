namespace Domain.DTOs;

public class PostDto
{
    public int Id { get; }
    public Subforum Subforum { get; }
    public string Title { get; }
    public string Context { get; }
    public User Author { get; }

    public PostDto(int id, Subforum subforum, string title, string context, User author)
    {
        Id = id;
        Subforum = subforum;
        Title = title;
        Context = context;
        Author = author;
    }
}