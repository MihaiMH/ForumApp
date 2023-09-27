using Domain.DTOs;

namespace Domain;

public class Post
{
    public int Id { get; set; }
    public Subforum Subforum { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public User Author { get; set; }


    public Post(string title, Subforum subforum, string context, User author)
    {
        Subforum = subforum;
        Title = title;
        Context = context;
        Author = author;
    }
}