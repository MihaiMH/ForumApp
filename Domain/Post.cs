namespace Domain;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public User Author { get; set; }
    

    public Post(string title, string context, User author)
    {
        Title = title;
        Context = context;
        Author = author;
    }
}